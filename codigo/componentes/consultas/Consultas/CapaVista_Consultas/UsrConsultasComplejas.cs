using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CapaControlador_Consultas;
using CapaVista_Consultas.Componentes;

// Inicio código José Cano - 0901-23-1727
// Fecha: 06/10/2026

namespace CapaVista_Consultas
{
    public partial class UsrConsultasComplejas : UsrBaseConsultas, IEstadoVistaConsultas
    {
        public event EventHandler SolicitarSimples;
        public event EventHandler SolicitarSalir;
        public event EventHandler<ClsSeleccionConsulta> ConsultasEvtSeleccion;
        private const int _RegistrosPorPagina = 10;
        private ClsControladorConsultasComplejas _Controlador;
        private IContextoConsulta _Contexto;
        private bool _InicializandoMantenimiento = true;
        private readonly DataTable _Condiciones = new DataTable();
        public UsrConsultasComplejas()
        {
            InitializeComponent();
            ConsultasProcRegistrarDiseno();
            ConsultasUsrTabla.ConsultasProcUniformarFilas();
            ConsultasUsrConsultas.ResaltarFilasAlPasar = true;

            ConsultasProcLimpiarErrorValor();
            ConsultasProcLimpiarErrorNombreConsulta();

            foreach (string Nombre in new[] { "Campo", "Operador", "Valor", "Orden", "Conector" })
            {
                _Condiciones.Columns.Add(Nombre);
            }
            ConsultasUsrMantenimiento.DataSource = _Condiciones;
            ConsultasUsrNombreConsulta.MaxLength = 50;
            ConsultasCboOrden.Items.AddRange(new[] { "", "ASC", "DESC" });
            ConsultasCboOrden.SelectedIndex = 0;
            ConsultasCboConector.Items.AddRange(new[] { "AND", "OR" });
            ConsultasCboConector.SelectedIndex = -1;
            ConsultasUsrConsultas.Tabla.CellClick += (Sender, Evento) =>
            {
                if (!_CargandoDefinicion && Evento.RowIndex >= 0)
                {
                    DataRowView Fila = ConsultasUsrConsultas.Rows[Evento.RowIndex].DataBoundItem as DataRowView;
                    _IdSeleccionado = Fila == null ? 0 : Convert.ToInt32(Fila.Row["Id"]);
                    ConsultasProcActualizarEstado();
                }
            };
            ConsultasUsrConsultas.DataBindingComplete += (Sender, Evento) =>
            {
                ConsultasUsrConsultas.ConsultasProcLimpiarSeleccion();
                ConsultasUsrConsultas.CurrentCell = null;
            };
            ConsultasUsrMantenimiento.ReadOnly = true;
            ConsultasUsrMantenimiento.DataBindingComplete += (Sender, Evento) =>
            {
                if (_FilaFiltroSeleccionada == null)
                {
                    ConsultasUsrMantenimiento.ConsultasProcLimpiarSeleccion();
                    ConsultasUsrMantenimiento.CurrentCell = null;
                }
            };
            ConsultasBtnIngresar.Click += ConsultasMetIngresar;
            ConsultasBtnModificar.Click += ConsultasMetModificar;
            ConsultasUsrMantenimiento.Tabla.CellClick += ConsultasMetSeleccionarFiltro;
            ConsultasUsrNombreConsulta.TextChanged += (Sender, Evento) => { ConsultasProcLimpiarErrorNombreConsulta(); ConsultasProcActualizarEstado(); };
            ConsultasUsrValor.TextChanged += (Sender, Evento) => { ConsultasProcLimpiarErrorValor(); ConsultasProcActualizarEstado(); };
            ConsultasCboOrden.SelectedIndexChanged += (Sender, Evento) => ConsultasProcActualizarEstado();
            ConsultasCboConector.SelectedIndexChanged += (Sender, Evento) => ConsultasProcActualizarEstado();
            ConsultasCboCampo.SelectedIndexChanged += ConsultasMetCambiarCampo;
            ConsultasCboOperador.SelectedIndexChanged += (Sender, Evento) =>
            {
                ConsultasProcLimpiarErrorValor();
                ConsultasProcActualizarEstado();
            };
            ConsultasBtnIngresarFiltro.Click += ConsultasMetIngresarFiltro;
            ConsultasBtnModificarFiltro.Click += ConsultasMetModificarFiltro;
            ConsultasBtnEliminarFiltro.Click += ConsultasMetEliminarFiltro;
            ConsultasBtnGuardarConsulta.Click += ConsultasMetGuardar;
            ConsultasBtnEliminarConsulta.Click += ConsultasMetEliminarConsulta;
            ConsultasBtnRefrescar.Click += ConsultasMetRefrescar;
            ConsultasBtnSalir.Click += (Sender, Evento) => SolicitarSalir?.Invoke(this, EventArgs.Empty);
            ConsultasBtnAyuda.Click += (Sender, Evento) => ClsInteraccionConsultas.ConsultasProcAyuda(this, "ConsultaCompleja.html");
            ConsultasUsrTabla.ConsultasEvtFilaSeleccionada += (Sender, Evento) => ConsultasEvtSeleccion?.Invoke(this, Evento);
            ConsultasUsrConsultas.CellDoubleClick += (Sender, Evento) =>
            {
                if (Evento.RowIndex >= 0)
                {
                    DataRowView Fila = ConsultasUsrConsultas.Rows[Evento.RowIndex].DataBoundItem as DataRowView;
                    if (Fila != null) ConsultasProcAbrir(Convert.ToInt32(Fila.Row["Id"]), false);
                }
            };
            ConsultasProcActualizarEstado();
            ConsultasProcMostrarOrientacionInicial();
            _InicializandoMantenimiento = false;
        }

        internal override System.Drawing.Size ConsultasFuncTamanoNecesario()
        {
            int Extra = Math.Max(0, (int)Math.Ceiling(ConsultasTlpNuevoFiltro.RowStyles[1].Height) - ConsultasFuncEscalarAltura(45)) + Math.Max(0, (int)Math.Ceiling(ConsultasTlpNuevoFiltro.RowStyles[3].Height) - ConsultasFuncEscalarAltura(45));
            return new System.Drawing.Size(ConsultasTamanoDiseno.Width, ConsultasTamanoDiseno.Height + ConsultasFuncEscalarAltura(2) + Extra);
        }

        private void ConsultasProcMostrarOrientacionInicial()
        {
            ConsultasProcActualizarError(ConsultasUsrNombreConsulta, 1, "Presione Ingresar para crear una consulta o seleccione un registro y presione Modificar.", true);
        }

        private void ConsultasProcLimpiarErrorNombreConsulta()
        {
            ConsultasProcActualizarError(ConsultasUsrNombreConsulta, 1, null);
        }

        private void ConsultasProcMostrarErrorNombreConsulta(string Mensaje)
        {
            ConsultasProcActualizarError(ConsultasUsrNombreConsulta, 1, Mensaje);
        }

        private void ConsultasProcLimpiarErrorValor()
        {
            ConsultasProcActualizarError(ConsultasUsrValor, 3, null);
        }

        private void ConsultasProcMostrarErrorValor(string Mensaje)
        {
            ConsultasProcActualizarError(ConsultasUsrValor, 3, Mensaje);
        }

        private void ConsultasProcActualizarError(UsrTextBoxConsultas Entrada, int Fila, string Mensaje, bool Ampliar = false)
        {
            int Altura = ConsultasFuncEscalarAltura(string.IsNullOrWhiteSpace(Mensaje) ? 45 : 65);
            if (Ampliar) Altura = Entrada.ConsultasFuncAlturaError(Mensaje);
            int Extra = Math.Max(0, Altura - ConsultasFuncEscalarAltura(45));
            Extra += Math.Max(0, (int)Math.Ceiling(ConsultasTlpNuevoFiltro.RowStyles[Fila == 1 ? 3 : 1].Height) - ConsultasFuncEscalarAltura(45));
            int AlturaPrincipal = ConsultasFuncEscalarAltura(277) + Extra;
            using (new ClsActualizacionDisenoConsultas(ConsultasTlpNuevoFiltro, _InicializandoMantenimiento ? null : ConsultasTlpMantenimiento))
            {
                if (string.IsNullOrWhiteSpace(Mensaje)) Entrada.ConsultasProcLimpiarError();
                else
                {
                    if (Entrada == ConsultasUsrNombreConsulta) Entrada.ConsultasProcLimpiarError();
                    Entrada.ConsultasProcMostrarError(Mensaje);
                }
                if (Ampliar) Entrada.ConsultasProcAmpliarError(Altura);
                ClsActualizacionDisenoConsultas.ConsultasProcAltura(ConsultasTlpNuevoFiltro.RowStyles[Fila], Altura);
                ClsActualizacionDisenoConsultas.ConsultasProcAltura(ConsultasTlpMain.RowStyles[1], AlturaPrincipal);
                ConsultasProcNotificarTamano();
            }
        }

        private enum ConsultasEstadoMantenimiento { Inicial, Visualizacion, Agregar, Modificar }
        private ConsultasEstadoMantenimiento _Estado;
        private bool _CargandoDefinicion;
        private int _IdSeleccionado;
        private int _IdMantenimiento;
        private int _IdEdicion;
        private DataRow _FilaFiltroSeleccionada;
        private bool _CargandoFiltro;
        private bool _SolicitandoConectorIngreso;
        private string _OperadorNoDisponible;
        private bool ConsultasFuncEditable => _Estado == ConsultasEstadoMantenimiento.Agregar || _Estado == ConsultasEstadoMantenimiento.Modificar;

        void IEstadoVistaConsultas.ConsultasProcMostrarError(ClsErrorValidacion Error)
        {
            ConsultasProcMostrarError(Error);
        }

        void IEstadoVistaConsultas.ConsultasProcActualizarEstado()
        {
            ConsultasProcActualizarEstado();
        }

        internal void ConsultasProcMostrarError(ClsErrorValidacion Error)
        {
            if (Error.Campo == "Nombre") ConsultasProcMostrarErrorNombreConsulta(Error.Message);
            else ConsultasProcMostrarErrorValor(Error.Message);
        }

        internal void ConsultasProcActualizarEstado()
        {
            if (_CargandoFiltro) return;
            using (_InicializandoMantenimiento ? null : new ClsActualizacionDisenoConsultas(ConsultasTlpNuevoFiltro, ConsultasTlpMantenimiento))
            {
                bool Editable = _Controlador != null && ConsultasFuncEditable;
                int Indice = ConsultasFuncIndiceFiltro();
                bool TieneFiltroPrevio = Indice < 0 ? _Condiciones.AsEnumerable().Any(Fila => Convert.ToString(Fila["Operador"]) != "") : _Condiciones.AsEnumerable().Take(Indice).Any(Fila => Convert.ToString(Fila["Operador"]) != "");
                bool ConectorHabilitado = Editable && ConsultasCboOperador.SelectedIndex > 0 && (TieneFiltroPrevio || _SolicitandoConectorIngreso);
                if (!ConectorHabilitado && ConsultasCboConector.SelectedIndex >= 0) ConsultasCboConector.SelectedIndex = -1;
                ConsultasBtnIngresar.Enabled = _Controlador != null;
                ConsultasBtnModificar.Enabled = _Controlador != null && _IdSeleccionado > 0;
                ConsultasBtnEliminarConsulta.Enabled = _Controlador != null && _IdSeleccionado > 0;
                ConsultasBtnRefrescar.Enabled = _Controlador != null;
                ConsultasUsrMantenimiento.Enabled = Editable;
                ConsultasUsrNombreConsulta.Enabled = Editable;
                ConsultasCboCampo.Enabled = Editable;
                ConsultasCboOperador.Enabled = Editable;
                ConsultasCboOrden.Enabled = Editable;
                ConsultasCboConector.Enabled = ConectorHabilitado;
                ConsultasUsrValor.Enabled = Editable;
                ConsultasBtnGuardarConsulta.Enabled = Editable && _Condiciones.Rows.Count > 0 && !string.IsNullOrWhiteSpace(ConsultasUsrNombreConsulta.Text);
                bool CapturaValida = ConsultasCboCampo.SelectedIndex >= 0 && ConsultasCboOperador.SelectedIndex >= 0 && (ConsultasCboOperador.Text != "" ? !string.IsNullOrWhiteSpace(ConsultasUsrValor.Text) : ConsultasCboOrden.Text != "");
                ConsultasBtnIngresarFiltro.Enabled = Editable && CapturaValida && _Condiciones.Rows.Count < 100;
                ConsultasBtnModificarFiltro.Enabled = Editable && Indice >= 0;
                ConsultasBtnEliminarFiltro.Enabled = Editable && Indice > 0;
            }
        }

        private bool ConsultasFuncConfirmarDescarte(bool SoloEdicion)
        {
            if (SoloEdicion ? !ConsultasFuncEditable : _Estado == ConsultasEstadoMantenimiento.Inicial) return true;
            return MessageBox.Show(this, "¿Desea descartar el contenido actual de Mantenimiento?", "Consultas", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        private void ConsultasProcLimpiarMantenimiento()
        {
            using (_InicializandoMantenimiento ? null : new ClsActualizacionDisenoConsultas(ConsultasTlpNuevoFiltro, ConsultasTlpMantenimiento))
            {
                _Condiciones.Clear();
                ConsultasUsrNombreConsulta.Text = "";
                ConsultasProcLimpiarCaptura();
                ConsultasProcLimpiarErrorNombreConsulta();
            }
        }

        private void ConsultasProcInicializar()
        {
            _Contexto.ConsultasProcLimpiarFiltro();
            using (new ClsActualizacionDisenoConsultas(ConsultasTlpNuevoFiltro, ConsultasTlpMantenimiento))
            {
                _Estado = ConsultasEstadoMantenimiento.Inicial;
                _IdSeleccionado = 0;
                _IdMantenimiento = 0;
                _IdEdicion = 0;
                ConsultasProcLimpiarMantenimiento();
                ConsultasProcMostrarOrientacionInicial();
            }
            ConsultasUsrTabla.ConsultasProcConfigurarContexto(_Contexto, _RegistrosPorPagina);
            ConsultasUsrTabla.ConsultasProcCargarPagina();
            ConsultasUsrConsultas.ConsultasProcLimpiarSeleccion();
            ConsultasUsrConsultas.CurrentCell = null;
            ConsultasProcActualizarEstado();
        }

        private void ConsultasMetIngresar(object Sender, EventArgs Evento)
        {
            if (!ConsultasFuncConfirmarDescarte(false)) return;
            ClsInteraccionConsultas.ConsultasProcEjecutar(this, () =>
            {
                ConsultasProcInicializar();
                _Estado = ConsultasEstadoMantenimiento.Agregar;
                ConsultasProcLimpiarErrorNombreConsulta();
            });
        }

        private void ConsultasMetModificar(object Sender, EventArgs Evento)
        {
            ClsInteraccionConsultas.ConsultasProcEjecutar(this, () => ConsultasProcAbrirDefinicion(ConsultasFuncIdSeleccionado(), true));
        }

        private void ConsultasProcAbrir(int Id, bool Modificar)
        {
            ClsInteraccionConsultas.ConsultasProcEjecutar(this, () => ConsultasProcAbrirDefinicion(Id, Modificar));
        }

        private void ConsultasProcAbrirDefinicion(int Id, bool Modificar)
        {
            if (!ConsultasFuncConfirmarDescarte(!Modificar)) return;
            string Nombre;
            DataTable Filas = _Controlador.Guardadas.ConsultasFuncCargarMantenimiento(Id, out Nombre);
            ClsPaginaConsulta Pagina = _Controlador.ConsultasFuncVistaPrevia(Filas, Id, _RegistrosPorPagina);
            _Estado = Modificar ? ConsultasEstadoMantenimiento.Modificar : ConsultasEstadoMantenimiento.Visualizacion;
            _IdMantenimiento = Id;
            _IdEdicion = Modificar ? Id : 0;
            ConsultasProcLimpiarMantenimiento();
            foreach (DataRow Fila in Filas.Rows) _Condiciones.Rows.Add(Fila.ItemArray);
            ConsultasProcLimpiarCaptura();
            ConsultasUsrNombreConsulta.Text = Nombre;
            ConsultasUsrTabla.ConsultasProcMostrarPagina(Pagina, true);
            ConsultasProcActualizarErrorResultados(Pagina);
        }

        private void ConsultasProcActualizarErrorResultados(ClsPaginaConsulta Pagina)
        {
            using (_InicializandoMantenimiento ? null : new ClsActualizacionDisenoConsultas(ConsultasTlpNuevoFiltro, ConsultasTlpMantenimiento))
            {
                ConsultasProcLimpiarErrorValor();
                DataRow[] Filtros = _Condiciones.AsEnumerable().Where(Fila => Convert.ToString(Fila["Operador"]) != "").ToArray();
                if (Pagina.TotalRegistros != 0 || Filtros.Length == 0) return;
                ConsultasProcMostrarErrorValor(Filtros.Length > 1 ? "Sin resultados. Verifique los campos, operadores y formatos de los filtros." : _Contexto.ConsultasFuncMensajeSinResultados(Convert.ToString(Filtros[0]["Campo"])));
            }
        }

        private void ConsultasProcVistaPrevia()
        {
            ConsultasProcActualizarEstado();
            ClsInteraccionConsultas.ConsultasProcEjecutar(ConsultasUsrTabla, () =>
            {
                ClsPaginaConsulta Pagina = _Controlador.ConsultasFuncVistaPrevia(_Condiciones, _IdEdicion, _RegistrosPorPagina);
                ConsultasUsrTabla.ConsultasProcMostrarPagina(Pagina, true);
                ConsultasProcActualizarErrorResultados(Pagina);
            });
        }

        public void ConsultasProcConfigurar(ClsControladorConsultas Controlador)
        {
            ConsultasProcConfigurarComplejas(Controlador?.Complejas);
        }

        internal void ConsultasProcConfigurarComplejas(ClsControladorConsultasComplejas Controlador)
        {
            _Controlador = Controlador ?? throw new ArgumentNullException(nameof(Controlador));
            _Contexto = Controlador.Contexto;
            ConsultasUsrTabla.ConsultasProcConfigurarContexto(_Contexto, _RegistrosPorPagina);
            ConsultasCboCampo.Items.Clear();
            ConsultasCboCampo.Items.AddRange(_Contexto.ConsultasFuncObtenerCampos());
            ConsultasCboCampo.SelectedIndex = -1;
            ConsultasMetRefrescar(this, EventArgs.Empty);
        }

        private void ConsultasMetCambiarCampo(object Sender, EventArgs Evento)
        {
            if (_CargandoFiltro) return;
            ConsultasProcLimpiarErrorValor();
            if (_Controlador == null || ConsultasCboCampo.SelectedIndex < 0)
            {
                ConsultasProcActualizarEstado();
                return;
            }
            ClsInteraccionConsultas.ConsultasProcEjecutar(this, () =>
            {
                ConsultasUsrValor.Text = "";
                ConsultasProcLimpiarErrorValor();
                ConsultasCboOperador.Items.Clear();
                ConsultasCboOperador.Items.Add("");
                ConsultasCboOperador.Items.AddRange(_Contexto.ConsultasFuncObtenerOperadores(ConsultasCboCampo.Text));
                ConsultasCboOperador.SelectedIndex = 1;
            });
        }

        private int ConsultasFuncIndiceFiltro()
        {
            return _FilaFiltroSeleccionada == null || _FilaFiltroSeleccionada.RowState == DataRowState.Detached || _FilaFiltroSeleccionada.RowState == DataRowState.Deleted ? -1 : _Condiciones.Rows.IndexOf(_FilaFiltroSeleccionada);
        }

        private void ConsultasProcLimpiarCaptura()
        {
            using (_InicializandoMantenimiento ? null : new ClsActualizacionDisenoConsultas(ConsultasTlpNuevoFiltro, ConsultasTlpMantenimiento))
            {
                _CargandoFiltro = true;
                try
                {
                    _FilaFiltroSeleccionada = null;
                    _OperadorNoDisponible = null;
                    _SolicitandoConectorIngreso = false;
                    ConsultasCboCampo.SelectedIndex = -1;
                    ConsultasCboOperador.Items.Clear();
                    ConsultasUsrValor.Text = "";
                    ConsultasCboOrden.SelectedIndex = 0;
                    ConsultasCboConector.SelectedIndex = -1;
                    ConsultasUsrMantenimiento.ConsultasProcLimpiarSeleccion();
                    ConsultasUsrMantenimiento.CurrentCell = null;
                    ConsultasProcLimpiarErrorValor();
                }
                finally { _CargandoFiltro = false; }
                ConsultasProcActualizarEstado();
            }
        }

        private void ConsultasMetSeleccionarFiltro(object Sender, DataGridViewCellEventArgs Evento)
        {
            if (_CargandoFiltro || !ConsultasFuncEditable || Evento.RowIndex < 0 || Evento.RowIndex >= ConsultasUsrMantenimiento.Rows.Count) return;
            DataRowView Seleccionada = ConsultasUsrMantenimiento.Rows[Evento.RowIndex].DataBoundItem as DataRowView;
            if (Seleccionada == null) return;
            _CargandoFiltro = true;
            try
            {
                _FilaFiltroSeleccionada = Seleccionada.Row;
                _SolicitandoConectorIngreso = false;
                ConsultasCboCampo.SelectedItem = Convert.ToString(Seleccionada.Row["Campo"]);
                ConsultasCboOperador.Items.Clear();
                ConsultasCboOperador.Items.Add("");
                ConsultasCboOperador.Items.AddRange(_Contexto.ConsultasFuncObtenerOperadores(ConsultasCboCampo.Text));
                string Operador = Convert.ToString(Seleccionada.Row["Operador"]);
                ConsultasCboOperador.SelectedIndex = ConsultasCboOperador.Items.IndexOf(Operador);
                _OperadorNoDisponible = ConsultasCboOperador.SelectedIndex < 0 ? Operador : null;
                ConsultasUsrValor.Text = Convert.ToString(Seleccionada.Row["Valor"]);
                ConsultasCboOrden.SelectedItem = Convert.ToString(Seleccionada.Row["Orden"]);
                ConsultasCboConector.SelectedIndex = ConsultasCboConector.Items.IndexOf(Convert.ToString(Seleccionada.Row["Conector"]));
                ConsultasProcLimpiarErrorValor();
            }
            finally { _CargandoFiltro = false; }
            ConsultasProcActualizarEstado();
            if (_OperadorNoDisponible != null) ConsultasProcMostrarErrorValor("La fila usa " + _OperadorNoDisponible + ", que solo se admite en consultas antiguas. Para modificarla, elija un operador disponible y un valor; la fila original se conserva.");
        }

        private object[] ConsultasFuncCaptura()
        {
            if (!ConsultasFuncEditable || _Controlador == null) throw new ClsErrorValidacion("Valor", "Use Agregar o Modificar para editar filtros.");
            if (_OperadorNoDisponible != null && ConsultasCboOperador.SelectedIndex < 0) throw new ClsErrorValidacion("Valor", "El operador antiguo " + _OperadorNoDisponible + " no puede editarse. Elija explícitamente un operador disponible y su valor.");
            if (ConsultasCboOperador.SelectedIndex < 0) throw new ClsErrorValidacion("Valor", "Seleccione un operador o un ordenamiento.");
            return new object[] { ConsultasCboCampo.Text, ConsultasCboOperador.Text, ConsultasUsrValor.Text, ConsultasCboOrden.Text, ConsultasCboConector.Text };
        }

        private static void ConsultasProcNormalizarFilas(DataTable Filas)
        {
            bool TieneFiltro = false;
            foreach (DataRow Fila in Filas.Rows)
            {
                if (Convert.ToString(Fila["Operador"]) == "") Fila["Conector"] = "";
                else
                {
                    if (!TieneFiltro) Fila["Conector"] = "";
                    TieneFiltro = true;
                }
            }
        }

        private void ConsultasProcValidarCaptura(object[] Datos, bool TieneFiltroPrevio)
        {
            _Controlador.ConsultasProcValidarFila(Convert.ToString(Datos[0]), Convert.ToString(Datos[1]), Convert.ToString(Datos[2]), Convert.ToString(Datos[3]), Convert.ToString(Datos[4]), TieneFiltroPrevio);
        }

        private void ConsultasMetIngresarFiltro(object Sender, EventArgs Evento)
        {
            ClsInteraccionConsultas.ConsultasProcEjecutar(this, () =>
            {
                object[] Datos = ConsultasFuncCaptura();
                if (ConsultasFuncIndiceFiltro() >= 0 && _FilaFiltroSeleccionada.ItemArray.SequenceEqual(Datos)) throw new ClsErrorValidacion("Valor", "Cambie algún dato de la fila seleccionada antes de ingresar una nueva; use Modificar para reemplazarla.");
                if (_Condiciones.Rows.Count >= 100) throw new ClsErrorValidacion("Valor", "Se permiten hasta 100 condiciones.");
                bool TieneFiltro = _Condiciones.AsEnumerable().Any(Fila => Convert.ToString(Fila["Operador"]) != "");
                if (TieneFiltro && Convert.ToString(Datos[1]) != "" && Convert.ToString(Datos[4]) == "")
                {
                    _SolicitandoConectorIngreso = true;
                    throw new ClsErrorValidacion("Valor", "Elija AND u OR para la nueva fila y vuelva a presionar Ingresar.");
                }
                if (!TieneFiltro || Convert.ToString(Datos[1]) == "") Datos[4] = "";
                ConsultasProcValidarCaptura(Datos, TieneFiltro);
                DataTable Candidata = _Condiciones.Copy();
                Candidata.Rows.Add(Datos);
                ConsultasProcNormalizarFilas(Candidata);
                _Controlador.ConsultasProcValidarMantenimiento(Candidata, _IdEdicion);
                _Condiciones.Rows.Add(Datos);
                ConsultasProcNormalizarFilas(_Condiciones);
                ConsultasProcLimpiarCaptura();
                ConsultasProcVistaPrevia();
            });
        }

        private void ConsultasMetModificarFiltro(object Sender, EventArgs Evento)
        {
            ClsInteraccionConsultas.ConsultasProcEjecutar(this, () =>
            {
                int Indice = ConsultasFuncIndiceFiltro();
                if (Indice < 0) throw new ClsErrorValidacion("Valor", "Seleccione una fila de Mantenimiento para modificarla.");
                object[] Datos = ConsultasFuncCaptura();
                bool TieneFiltroPrevio = _Condiciones.AsEnumerable().Take(Indice).Any(Fila => Convert.ToString(Fila["Operador"]) != "");
                if (!TieneFiltroPrevio || Convert.ToString(Datos[1]) == "") Datos[4] = "";
                ConsultasProcValidarCaptura(Datos, TieneFiltroPrevio);
                DataTable Candidata = _Condiciones.Copy();
                Candidata.Rows[Indice].ItemArray = Datos;
                ConsultasProcNormalizarFilas(Candidata);
                _Controlador.ConsultasProcValidarMantenimiento(Candidata, _IdEdicion);
                _FilaFiltroSeleccionada.ItemArray = Datos;
                ConsultasProcNormalizarFilas(_Condiciones);
                ConsultasProcLimpiarCaptura();
                ConsultasProcVistaPrevia();
            });
        }

        private void ConsultasMetEliminarFiltro(object Sender, EventArgs Evento)
        {
            ClsInteraccionConsultas.ConsultasProcEjecutar(this, () =>
            {
                if (!ConsultasFuncEditable) throw new ClsErrorValidacion("Valor", "Use Agregar o Modificar para editar filtros.");
                int Indice = ConsultasFuncIndiceFiltro();
                if (Indice < 0) throw new ClsErrorValidacion("Valor", "Seleccione una fila de Mantenimiento.");
                if (Indice == 0) throw new ClsErrorValidacion("Valor", "La primera fila de Mantenimiento no se puede eliminar.");
                _Condiciones.Rows.Remove(_FilaFiltroSeleccionada);
                ConsultasProcNormalizarFilas(_Condiciones);
                ConsultasProcLimpiarCaptura();
                ConsultasProcVistaPrevia();
            });
        }

        private int ConsultasFuncIdSeleccionado()
        {
            if (_IdSeleccionado <= 0) throw new ArgumentException("Seleccione una consulta guardada.");
            return _IdSeleccionado;
        }

        private void ConsultasProcRefrescarCatalogo()
        {
            _CargandoDefinicion = true;
            try
            {
                _IdSeleccionado = 0;
                ConsultasUsrConsultas.DataSource = _Controlador.Guardadas.ConsultasFuncListarGuardadas();
                ConsultasUsrConsultas.Columns["Id"].Visible = false;
                ConsultasUsrConsultas.ConsultasProcLimpiarSeleccion();
                ConsultasUsrConsultas.CurrentCell = null;
            }
            finally
            {
                _CargandoDefinicion = false;
                ConsultasProcActualizarEstado();
            }
        }

        private void ConsultasMetGuardar(object Sender, EventArgs Evento)
        {
            ClsInteraccionConsultas.ConsultasProcEjecutar(this, () =>
            {
                if (_Controlador == null)
                {
                    throw new InvalidOperationException("Configure el contexto de búsqueda.");
                }
                if (!ConsultasFuncEditable) throw new InvalidOperationException("Inicie Agregar o Modificar antes de guardar.");
                _Controlador.Guardadas.ConsultasProcValidarGuardado(ConsultasUsrNombreConsulta.Text, _Condiciones, _IdEdicion);
                if (_Estado == ConsultasEstadoMantenimiento.Modificar && MessageBox.Show(this, "¿Desea guardar los cambios de esta consulta?", "Consultas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
                int Id = _Controlador.Guardadas.ConsultasFuncGuardar(ConsultasUsrNombreConsulta.Text, _Condiciones, _IdEdicion);
                _IdMantenimiento = Id;
                _IdEdicion = 0;
                _Estado = ConsultasEstadoMantenimiento.Visualizacion;
                ConsultasUsrNombreConsulta.Text = ConsultasUsrNombreConsulta.Text.Trim();
                ConsultasProcLimpiarErrorNombreConsulta();
                ConsultasProcLimpiarErrorValor();
                ConsultasProcRefrescarCatalogo();
                MessageBox.Show(this, "Consulta guardada correctamente.", "Consultas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private void ConsultasMetEliminarConsulta(object Sender, EventArgs Evento)
        {
            ClsInteraccionConsultas.ConsultasProcEjecutar(this, () =>
            {
                int Id = ConsultasFuncIdSeleccionado();
                if (MessageBox.Show(this, ConsultasFuncEditable ? "¿Desea eliminar la definición seleccionada y descartar la sesión de edición actual?" : "¿Desea eliminar la definición seleccionada?", "Consultas", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return;
                }
                _Controlador.Guardadas.ConsultasProcEliminarGuardada(Id);
                if (Id == _IdMantenimiento || ConsultasFuncEditable) ConsultasProcInicializar();
                ConsultasProcRefrescarCatalogo();
            });
        }

        private void ConsultasMetRefrescar(object Sender, EventArgs Evento)
        {
            if (!ConsultasFuncConfirmarDescarte(true)) return;
            ClsInteraccionConsultas.ConsultasProcEjecutar(this, () =>
            {
                if (_Controlador == null) throw new InvalidOperationException("Configure el contexto de búsqueda.");
                DataTable Catalogo = _Controlador.Guardadas.ConsultasFuncListarGuardadas();
                ConsultasProcInicializar();
                _CargandoDefinicion = true;
                try
                {
                    ConsultasUsrConsultas.DataSource = Catalogo;
                    ConsultasUsrConsultas.Columns["Id"].Visible = false;
                    ConsultasUsrConsultas.ConsultasProcLimpiarSeleccion();
                    ConsultasUsrConsultas.CurrentCell = null;
                }
                finally { _CargandoDefinicion = false; }
            });
        }

        private void ConsultasMetMostrarSimples(object Sender, EventArgs Evento)
        {
            SolicitarSimples?.Invoke(this, EventArgs.Empty);
        }
    }

    // Fin código José Cano - 0901-23-1727
    // Fecha: 06/10/2026


}
