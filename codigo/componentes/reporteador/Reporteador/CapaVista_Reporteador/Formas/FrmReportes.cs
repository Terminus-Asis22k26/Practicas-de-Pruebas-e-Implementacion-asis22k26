/*
    VELVETH SARAI CHAVEZ MEJIA 0901 23 6269
*/

using CapaControlador_Reporteador;
using CapaModelo_Reporteador.Entidades;
using CapaVista_Reporteador.Formas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CapaVista_Reporteador
{
    public partial class FrmReportes : Form
    {
        private ClsModeloReporteador _ModeloReporteador;

        private bool _ModoEdicion = false;

        private int _NumeroReporteEdicion = 0;

        private int _IdAplicacionSeleccionada = 0;

        private string _RutaReporteAplicacion = string.Empty;

        private FrmVistaReportes _FrmVistaReportesPreparado;

        private Dictionary<string, object> _FuentesDeDatosReporteador;

        public FrmReportes()
        {
            InitializeComponent();

            _ModeloReporteador = new ClsModeloReporteador();

            ReporteadorBtnGuardar.MetodoGuardarReporte = "ReporteadorMetGuardarReporte";

            ReporteadorBtnLimpiar.MetodoLimpiarFormulario = "ReporteadorMetLimpiarCampos";

            // ============================================================
            // CONFIGURACIÓN DE LOS CAMPOS
            // ============================================================

            ReporteadorTxtNombreReporte.Enabled = true;
            ReporteadorTxtNombreReporte.ReadOnly = false;
            ReporteadorTxtNombreReporte.TabStop = true;

            ReporteadorTxtFiltroNombreReporte.Enabled = true;
            ReporteadorTxtFiltroNombreReporte.ReadOnly = false;
            ReporteadorTxtFiltroNombreReporte.TabStop = true;

            ReporteadorTxtRutaReporte.Enabled = true;
            ReporteadorTxtRutaReporte.ReadOnly = true;
            ReporteadorTxtRutaReporte.TabStop = false;

            // ============================================================
            // BOTÓN RUTA
            // ============================================================

            if (ReporteadorBtnRuta != null)
            {
                ReporteadorBtnRuta.CampoTextoRuta = ReporteadorTxtRutaReporte;
            }

            // ============================================================
            // BOTÓN BÚSQUEDA
            // ============================================================

            if (ReporteadorBtnBusqueda != null)
            {
                ReporteadorBtnBusqueda.TxtNombreReporte = ReporteadorTxtFiltroNombreReporte;

                ReporteadorBtnBusqueda.DtpFechaReporte = ReporteadorDtpFechaReporte;

                ReporteadorBtnBusqueda.ChkNombreReporte = ReporteadorChkNombreReporte;

                ReporteadorBtnBusqueda.ChkFechaReporte = ReporteadorChkFechaReporte;

                ReporteadorBtnBusqueda.DgvReportes = ReporteadorDgvReportes;
            }

            // ============================================================
            // BOTÓN ACTUALIZAR
            // ============================================================

            if (ReporteadorBtnActualizar != null)
            {
                ReporteadorBtnActualizar.DgvReportes = ReporteadorDgvReportes;
            }

            // ============================================================
            // BOTÓN EDITAR
            // ============================================================

            if (ReporteadorBtnEditar != null)
            {
                ReporteadorBtnEditar.ReporteadorTxtNombreReporte = ReporteadorTxtNombreReporte;

                ReporteadorBtnEditar.ReporteadorTxtRutaReporte = ReporteadorTxtRutaReporte;

                ReporteadorBtnEditar.MetodoEditarFormulario = "ReporteadorMetPrepararEdicion";
            }

            // ============================================================
            // BOTÓN LIMPIAR
            // ============================================================

            if (ReporteadorBtnLimpiar != null)
            {
                ReporteadorBtnLimpiar.Click += ReporteadorMetLimpiarClick;
            }

            // ============================================================
            // LOAD
            // ============================================================

            Load += ReporteadorMetCargarFormulario;
        }

        // ================================================================
        // LOAD DEL FORMULARIO
        // ================================================================

        private void ReporteadorMetCargarFormulario(object Sender, EventArgs E)
        {
            try
            {
                ReporteadorMetCargarTabla();

                ReporteadorMetCargarAplicaciones();

                _ModoEdicion = false;

                _NumeroReporteEdicion = 0;

                ReporteadorMetPrepararNuevoRegistro();

                ReporteadorTxtNombreReporte.Focus();
            }
            catch (Exception)
            {
                ReporteadorMetMostrarError("No se pudo cargar el formulario.");
            }
        }

        // ================================================================
        // GUARDAR REPORTE
        // ================================================================

        public void ReporteadorMetGuardarReporte()
        {
            try
            {
                int IdAplicacionReporte;

                if (_ModoEdicion)
                {
                    IdAplicacionReporte = _IdAplicacionSeleccionada;
                }
                else
                {
                    if (ReporteadorCboAplicacionReporte.SelectedValue == null)
                    {
                        ReporteadorMetMostrarError(
                            "Debe seleccionar una aplicación antes de guardar el reporte."
                        );

                        ReporteadorCboAplicacionReporte.Focus();

                        return;
                    }

                    IdAplicacionReporte = Convert.ToInt32(
                        ReporteadorCboAplicacionReporte.SelectedValue
                    );

                    _IdAplicacionSeleccionada = IdAplicacionReporte;
                }

                string NombreReporte = ReporteadorTxtNombreReporte.Text.Trim();

                string RutaReporte = ReporteadorTxtRutaReporte.Text.Trim();

                // --------------------------------------------------------
                // VALIDAR NOMBRE
                // --------------------------------------------------------

                if (string.IsNullOrWhiteSpace(NombreReporte))
                {
                    ReporteadorMetMostrarError("Debe ingresar el nombre del reporte.");

                    ReporteadorTxtNombreReporte.Focus();

                    return;
                }

                // --------------------------------------------------------
                // VALIDAR RUTA
                // --------------------------------------------------------

                if (string.IsNullOrWhiteSpace(RutaReporte))
                {
                    ReporteadorMetMostrarError("Debe seleccionar el archivo .rdlc del reporte.");

                    return;
                }

                // --------------------------------------------------------
                // VALIDAR EXTENSIÓN
                // --------------------------------------------------------

                string ExtensionArchivo = Path.GetExtension(RutaReporte);

                if (!ExtensionArchivo.Equals(".rdlc", StringComparison.OrdinalIgnoreCase))
                {
                    ReporteadorMetMostrarError("Solo se permiten archivos de tipo .rdlc.");

                    return;
                }

                // --------------------------------------------------------
                // VALIDAR EXISTENCIA
                // --------------------------------------------------------

                if (!File.Exists(RutaReporte))
                {
                    ReporteadorMetMostrarError("El archivo seleccionado no existe.");

                    return;
                }

                if (_ModeloReporteador == null)
                {
                    _ModeloReporteador = new ClsModeloReporteador();
                }

                // --------------------------------------------------------
                // OBTENER REPORTES EXISTENTES
                // --------------------------------------------------------

                var ReportesExistentes = _ModeloReporteador.ReporteadorMetObtenerTodos(
                    _IdAplicacionSeleccionada
                );

                // --------------------------------------------------------
                // VALIDAR NOMBRE DUPLICADO
                // --------------------------------------------------------

                bool NombreRepetido = ReportesExistentes.Any(Reporte =>
                    !string.IsNullOrWhiteSpace(Reporte.NombreReporte)
                    && Reporte
                        .NombreReporte.Trim()
                        .Equals(NombreReporte, StringComparison.OrdinalIgnoreCase)
                    && (!_ModoEdicion || Reporte.NumeroReporte != _NumeroReporteEdicion)
                );

                if (NombreRepetido)
                {
                    ReporteadorMetMostrarError(
                        "No se puede guardar el reporte porque el nombre ya existe."
                    );

                    ReporteadorTxtNombreReporte.Focus();

                    return;
                }

                // --------------------------------------------------------
                // VALIDAR RUTA DUPLICADA
                // --------------------------------------------------------

                bool RutaRepetida = ReportesExistentes.Any(Reporte =>
                    !string.IsNullOrWhiteSpace(Reporte.RutaReporte)
                    && Reporte
                        .RutaReporte.Trim()
                        .Equals(RutaReporte, StringComparison.OrdinalIgnoreCase)
                    && (!_ModoEdicion || Reporte.NumeroReporte != _NumeroReporteEdicion)
                );

                if (RutaRepetida)
                {
                    ReporteadorMetMostrarError(
                        "No se puede guardar el reporte porque la ruta del archivo .rdlc ya está registrada."
                    );

                    return;
                }

                // --------------------------------------------------------
                // NÚMERO DEL REPORTE
                // --------------------------------------------------------

                if (_ModoEdicion)
                {
                    // Mantener el número del registro editado.
                    _ModeloReporteador.NumeroReporte = _NumeroReporteEdicion;
                }
                else
                {
                    _ModeloReporteador.NumeroReporte = ReporteadorMetObtenerSiguienteNumeroReporte();
                }

                // --------------------------------------------------------
                // ASIGNAR DATOS
                // --------------------------------------------------------

                _ModeloReporteador.NombreReporte = NombreReporte;

                _ModeloReporteador.RutaReporte = RutaReporte;

                _ModeloReporteador.FechaReporte = ReporteadorDtpFechaReporte.Value.Date;

                _ModeloReporteador.IdAplicacion = IdAplicacionReporte;

                _ModeloReporteador.Estado = _ModoEdicion
                    ? ClsEstadoEntidad.Modified
                    : ClsEstadoEntidad.Added;

                // --------------------------------------------------------
                // GUARDAR
                // --------------------------------------------------------

                string Resultado = _ModeloReporteador.ReporteadorMetGuardarReporte();

                // --------------------------------------------------------
                // NUEVO REGISTRO
                // --------------------------------------------------------

                if (Resultado == "Grabación exitosa")
                {
                    ReporteadorMetMostrarExito("El reporte se guardó correctamente.");

                    _ModoEdicion = false;

                    _NumeroReporteEdicion = 0;

                    ReporteadorMetLimpiarFormulario();

                    ReporteadorMetCargarAplicaciones();

                    ReporteadorMetCargarTabla();

                    ReporteadorMetPrepararNuevoRegistro();

                    return;
                }

                // --------------------------------------------------------
                // EDICIÓN
                // --------------------------------------------------------

                if (Resultado == "Actualización exitosa")
                {
                    ReporteadorMetMostrarExito("El reporte se actualizó correctamente.");

                    _ModoEdicion = false;

                    _NumeroReporteEdicion = 0;

                    ReporteadorMetLimpiarFormulario();

                    ReporteadorMetCargarAplicaciones();

                    ReporteadorMetCargarTabla();

                    ReporteadorMetPrepararNuevoRegistro();

                    return;
                }

                ReporteadorMetMostrarError(Resultado);
            }
            catch (Exception)
            {
                ReporteadorMetMostrarError("Ocurrió un error al guardar el reporte.");
            }
        }

        // ================================================================
        // CARGAR TABLA
        // ================================================================

        private void ReporteadorMetCargarTabla()
        {
            try
            {
                if (_ModeloReporteador == null)
                {
                    _ModeloReporteador = new ClsModeloReporteador();
                }

                ReporteadorDgvReportes.DataSource = _ModeloReporteador.ReporteadorMetObtenerTodos(_IdAplicacionSeleccionada);

                ReporteadorDgvReportes.Refresh();
            }
            catch (Exception)
            {
                ReporteadorMetMostrarError("No se pudo cargar la lista de reportes.");
            }
        }

        private void ReporteadorMetCargarAplicaciones()
        {
            ReporteadorCboAplicacionReporte.DataSource =
                _ModeloReporteador.ReporteadorMetObtenerAplicaciones().ToList();
            ReporteadorCboAplicacionReporte.DisplayMember = "NombreAplicacionMostrar";
            ReporteadorCboAplicacionReporte.ValueMember = "IdAplicacion";
            ReporteadorCboAplicacionReporte.SelectedIndex = -1;
        }

        // ================================================================
        // BOTÓN EDITAR
        // ================================================================

        private void ReporteadorMetPrepararEdicion()
        {
            try
            {
                if (ReporteadorDgvReportes.CurrentRow == null)
                {
                    ReporteadorMetMostrarError("Debe seleccionar un reporte para editar.");

                    return;
                }

                object Numero = ReporteadorDgvReportes.CurrentRow.Cells["NumeroReporte"].Value;

                object Nombre = ReporteadorDgvReportes.CurrentRow.Cells["NombreReporte"].Value;

                object Ruta = ReporteadorDgvReportes.CurrentRow.Cells["RutaReporte"].Value;

                object Fecha = ReporteadorDgvReportes.CurrentRow.Cells["FechaReporte"].Value;

                if (Numero == null || Numero == DBNull.Value)
                {
                    ReporteadorMetMostrarError("El reporte seleccionado no tiene número.");

                    return;
                }

                _NumeroReporteEdicion = Convert.ToInt32(Numero);

                ReporteadorTxtNombreReporte.Text = Nombre == null || Nombre == DBNull.Value ? string.Empty : Nombre.ToString();

                ReporteadorTxtRutaReporte.Text = Ruta == null || Ruta == DBNull.Value ? string.Empty : Ruta.ToString();

                if (Fecha != null && Fecha != DBNull.Value)
                {
                    ReporteadorDtpFechaReporte.Value = Convert.ToDateTime(Fecha);
                }

                _ModoEdicion = true;

                ReporteadorTxtNombreReporte.Focus();
            }
            catch (Exception)
            {
                ReporteadorMetMostrarError("No se pudo preparar el reporte para editar.");
            }
        }

        // ================================================================
        // LIMPIAR
        // ================================================================

        public void ReporteadorMetLimpiarCampos()
        {
            ReporteadorMetLimpiarFormulario();
        }

        private void ReporteadorMetLimpiarFormulario()
        {
            ReporteadorTxtNombreReporte.Clear();

            ReporteadorCboAplicacionReporte.SelectedIndex = -1;

            ReporteadorTxtRutaReporte.Clear();

            ReporteadorTxtFiltroNombreReporte.Clear();

            ReporteadorDtpFechaReporte.Value = DateTime.Now;

            if (ReporteadorChkNombreReporte != null)
            {
                ReporteadorChkNombreReporte.Checked = false;
            }

            if (ReporteadorChkFechaReporte != null)
            {
                ReporteadorChkFechaReporte.Checked = false;
            }

            ReporteadorTxtNombreReporte.Focus();
        }

        private void ReporteadorMetLimpiarClick(object Sender, EventArgs E)
        {
            try
            {
                ReporteadorMetLimpiarFormulario();

                _ModoEdicion = false;

                _NumeroReporteEdicion = 0;

                ReporteadorMetPrepararNuevoRegistro();

                ReporteadorMetCargarTabla();
            }
            catch (Exception)
            {
                ReporteadorMetMostrarError("No se pudo limpiar el formulario.");
            }
        }

        // ================================================================
        // OBTENER SIGUIENTE NÚMERO
        // ================================================================

        private int ReporteadorMetObtenerSiguienteNumeroReporte()
        {
            try
            {
                if (_ModeloReporteador == null)
                {
                    _ModeloReporteador = new ClsModeloReporteador();
                }

                return _ModeloReporteador.ReporteadorMetObtenerMaximoNumeroReporteGlobal() + 1;
            }
            catch (Exception)
            {
                return 3001;
            }
        }

        // ================================================================
        // PREPARAR NUEVO REGISTRO
        // ================================================================

        private void ReporteadorMetPrepararNuevoRegistro()
        {
            if (_ModeloReporteador == null)
            {
                _ModeloReporteador = new ClsModeloReporteador();
            }

            _ModeloReporteador.NumeroReporte = ReporteadorMetObtenerSiguienteNumeroReporte();

            _ModeloReporteador.FechaReporte = DateTime.Now.Date;

            ReporteadorDtpFechaReporte.Value = DateTime.Now;
        }

        // ================================================================
        // DIÁLOGO DE ÉXITO
        // ================================================================

        private void ReporteadorMetMostrarExito(string Mensaje)
        {
            Form Ventana = new Form();

            Ventana.Text = "Operación exitosa";

            Ventana.StartPosition = FormStartPosition.CenterParent;

            Ventana.FormBorderStyle = FormBorderStyle.FixedDialog;

            Ventana.MaximizeBox = false;

            Ventana.MinimizeBox = false;

            Ventana.ShowInTaskbar = false;

            Ventana.ClientSize = new Size(360, 125);

            Label Icono = new Label();

            Icono.Text = "✓";

            Icono.ForeColor = Color.White;

            Icono.BackColor = Color.FromArgb(40, 167, 69);

            Icono.Font = new Font("Segoe UI", 20, FontStyle.Bold);

            Icono.TextAlign = ContentAlignment.MiddleCenter;

            Icono.Size = new Size(45, 45);

            Icono.Location = new Point(20, 25);

            System.Drawing.Drawing2D.GraphicsPath Circulo = new System.Drawing.Drawing2D.GraphicsPath();

            Circulo.AddEllipse(0, 0, Icono.Width, Icono.Height);

            Icono.Region = new Region(Circulo);

            Label Texto = new Label();

            Texto.Text = Mensaje;

            Texto.AutoSize = false;

            Texto.TextAlign = ContentAlignment.MiddleLeft;

            Texto.Font = new Font("Segoe UI", 9);

            Texto.Location = new Point(80, 25);

            Texto.Size = new Size(250, 45);

            Button BotonAceptar = new Button();

            BotonAceptar.Text = "Aceptar";

            BotonAceptar.Size = new Size(80, 28);

            BotonAceptar.Location = new Point(250, 85);

            BotonAceptar.Click += (Sender, ArgumentosEvento) =>
            {
                Ventana.Close();
            };

            Ventana.Controls.Add(Icono);

            Ventana.Controls.Add(Texto);

            Ventana.Controls.Add(BotonAceptar);

            Ventana.AcceptButton = BotonAceptar;

            Ventana.ShowDialog(this);
        }

        // ================================================================
        // DIÁLOGO DE ERROR
        // ================================================================

        private void ReporteadorMetMostrarError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ================================================================
        // CARGAR AYUDA DEL REPORTEADOR
        // ================================================================
        private void ReporteadorMetMostrarAyuda(object Sender, EventArgs E)
        {
            DirectoryInfo DirectorioActual = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            while (DirectorioActual != null)
            {
                string RutaAyuda = Path.Combine(
                    DirectorioActual.FullName,
                    "ayuda",
                    "componentes",
                    "reporteador",
                    "AyudaReporteador.chm"
                );

                if (File.Exists(RutaAyuda))
                {
                    Help.ShowHelp(this, RutaAyuda, "Ayuda_General_Reporteador.html");
                    return;
                }

                DirectorioActual = DirectorioActual.Parent;
            }

            ReporteadorMetMostrarError("No se encontró el archivo de ayuda del Reporteador.");
        }

        // ================================================================
        // CARGAR REPORTES ASOCIADOS A IDAPLICACIÓN
        // ================================================================
        public void ReporteadorMetCargarReportes(int IdAplicacion, Dictionary<string, object> FuentesDeDatos)
        {
            _IdAplicacionSeleccionada = IdAplicacion;
            _RutaReporteAplicacion = _ModeloReporteador.ReporteadorMetObtenerRutaPrimerReporte(_IdAplicacionSeleccionada);
            _FuentesDeDatosReporteador = FuentesDeDatos;

            _FrmVistaReportesPreparado = new FrmVistaReportes(_RutaReporteAplicacion, _FuentesDeDatosReporteador);

            ReporteadorMetCargarTabla();
        }
    }
}