using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CapaControlador_Consultas;

namespace CapaVista_Consultas
{
    public partial class UsrTabla : Componentes.UsrBaseConsultas, IEstadoVistaConsultas
    {
        /*Inicio del código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
        private IContextoConsulta _Controlador;
        private ClsPaginaConsulta _Resultado;
        private string _CampoOrden;
        private bool _Descendente;
        private int _RegistrosPorPagina = 15;
        private bool _AjustarFilasContenido;
        private long _InicioPaginas = 1;
        private bool _ActualizandoPaginas;
        public event EventHandler<ClsSeleccionConsulta> ConsultasEvtFilaSeleccionada;

        public UsrTabla()
        {
            InitializeComponent();
            ConsultasFlpPaginas.SizeChanged += (Sender, Evento) => ConsultasProcActualizarPaginas();
            ConsultasFlpPaginas.PaddingChanged += (Sender, Evento) => ConsultasProcActualizarPaginas();
            ConsultasUsrResultados.ResaltarFilasAlPasar = true;
            ConsultasBtnAnterior.Enabled = false;
            ConsultasBtnSiguiente.Enabled = false;
            ConsultasBtnAnterior.Click += (Sender, Evento) => ConsultasProcNavegar(-1);
            ConsultasBtnSiguiente.Click += (Sender, Evento) => ConsultasProcNavegar(1);
            ConsultasUsrResultados.CellDoubleClick += (Sender, Evento) =>
            {
                if (Evento.RowIndex >= 0)
                {
                    ConsultasProcSeleccionar(Evento.RowIndex);
                }
            };
            ConsultasUsrResultados.KeyDown += (Sender, Evento) =>
            {
                if (Evento.KeyCode == Keys.Enter)
                {
                    Evento.SuppressKeyPress = true;
                    ConsultasProcSeleccionar();
                }
            };
            ConsultasUsrResultados.Tabla.ColumnHeaderMouseClick += ConsultasMetOrdenar;
        }

        private long ConsultasFuncTotalPaginas(ClsPaginaConsulta Resultado)
        {
            return Resultado == null ? 0 : Math.Max(1, (Resultado.TotalRegistros + _RegistrosPorPagina - 1) / _RegistrosPorPagina);
        }

        void IEstadoVistaConsultas.ConsultasProcMostrarError(ClsErrorValidacion Error)
        {
            MessageBox.Show(this, Error.Message, "Consultas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        void IEstadoVistaConsultas.ConsultasProcActualizarEstado()
        {
            ConsultasProcActualizarEstado();
        }

        internal void ConsultasProcActualizarEstado()
        {
            long Paginas = ConsultasFuncTotalPaginas(_Resultado);
            ConsultasBtnAnterior.Enabled = _Resultado != null && _Resultado.Pagina > 1;
            ConsultasBtnSiguiente.Enabled = _Resultado != null && _Resultado.Pagina < Paginas;
        }

        private void ConsultasProcNavegar(int Desplazamiento)
        {
            if (_Resultado == null)
            {
                return;
            }
            long Paginas = ConsultasFuncTotalPaginas(_Resultado);
            int Destino = _Resultado.Pagina + Desplazamiento;
            if (Destino >= 1 && Destino <= Paginas)
            {
                ConsultasProcCargarPagina(Destino);
            }
        }

        internal void ConsultasProcUniformarFilas()
        {
            ConsultasUsrResultados.ConsultasFilasUniformes = true;
            ConsultasProcAjustarFilasContenido(false);
        }

        public void ConsultasProcAjustarFilasContenido(bool Ajustar)
        {
            _AjustarFilasContenido = Ajustar;
            DataGridView Tabla = ConsultasUsrResultados.Tabla;
            Tabla.DefaultCellStyle.WrapMode = Ajustar ? DataGridViewTriState.True : DataGridViewTriState.False;
            Tabla.AutoSizeRowsMode = Ajustar ? DataGridViewAutoSizeRowsMode.AllCells : DataGridViewAutoSizeRowsMode.None;
            if (Ajustar && Tabla.Rows.Count > 0) Tabla.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }

        public void ConsultasProcConfigurar(ClsControladorConsultas Controlador, int RegistrosPorPagina)
        {
            ConsultasProcConfigurarContexto(Controlador, RegistrosPorPagina);
        }

        public void ConsultasProcConfigurarContexto(IContextoConsulta Controlador, int RegistrosPorPagina)
        {
            _Controlador = Controlador ?? throw new ArgumentNullException(nameof(Controlador));
            _RegistrosPorPagina = RegistrosPorPagina;
            _CampoOrden = null;
            _Descendente = false;
            ConsultasProcLimpiar();
        }

        public void ConsultasProcLimpiar()
        {
            _InicioPaginas = 1;
            _Resultado = null;
            ConsultasUsrResultados.DataSource = null;
            ConsultasBtnAnterior.Enabled = false;
            ConsultasBtnSiguiente.Enabled = false;
            ConsultasUsrPaginacion.Texto = "Sin resultados";
            while (ConsultasFlpPaginas.Controls.Count > 0) ConsultasFlpPaginas.Controls[0].Dispose();
        }

        internal ClsPaginaConsulta ConsultasFuncCargarPrimeraPagina()
        {
            ClsPaginaConsulta Resultado = _Controlador.ConsultasFuncEjecutar(1, _RegistrosPorPagina, _CampoOrden, _Descendente);
            _InicioPaginas = 1;
            ConsultasProcMostrarPagina(Resultado);
            return Resultado;
        }

        public void ConsultasProcCargarPagina(int Pagina = 1)
        {
            ClsInteraccionConsultas.ConsultasProcEjecutar(this, () =>
            {
                if (_Controlador == null)
                {
                    throw new InvalidOperationException("Configure el contexto de búsqueda.");
                }
                if (_Resultado != null && (Pagina < 1 || Pagina > ConsultasFuncTotalPaginas(_Resultado)))
                {
                    throw new ArgumentException("La página solicitada está fuera de los límites.");
                }
                ClsPaginaConsulta Resultado = _Controlador.ConsultasFuncEjecutar(Pagina, _RegistrosPorPagina, _CampoOrden, _Descendente);
                if (Pagina == 1) _InicioPaginas = 1;
                ConsultasProcMostrarPagina(Resultado);
            });
        }

        public void ConsultasProcMostrarPagina(ClsPaginaConsulta Resultado, bool ReiniciarOrden = false)
        {
            if (ReiniciarOrden)
            {
                _InicioPaginas = 1;
                _CampoOrden = null;
                _Descendente = false;
            }
            _Resultado = Resultado;
            ConsultasUsrResultados.DataSource = Resultado.Datos;
            foreach (DataGridViewColumn Columna in ConsultasUsrResultados.Columns)
            {
                Columna.SortMode = DataGridViewColumnSortMode.Programmatic;
                
                if (Columna.ValueType == typeof(DateTime))
                {
                    Columna.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                }
                
                Columna.HeaderCell.SortGlyphDirection = Columna.Name == _CampoOrden ? (_Descendente ? SortOrder.Descending : SortOrder.Ascending) : SortOrder.None;
            }
            if (_AjustarFilasContenido) ConsultasUsrResultados.Tabla.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            ConsultasUsrResultados.ConsultasProcLimpiarSeleccion();
            ConsultasUsrResultados.CurrentCell = null;
            long Paginas = ConsultasFuncTotalPaginas(Resultado);
            ConsultasUsrPaginacion.Texto = "Página " + Resultado.Pagina + " de " + Paginas + " — " + Resultado.TotalRegistros + " registros";
            ConsultasBtnAnterior.Enabled = Resultado.Pagina > 1;
            ConsultasBtnSiguiente.Enabled = Resultado.Pagina < Paginas;
            ConsultasProcActualizarPaginas();
        }

        private void ConsultasProcActualizarPaginas()
        {
            if (_ActualizandoPaginas) return;
            _ActualizandoPaginas = true;
            ConsultasFlpPaginas.SuspendLayout();
            try
            {
                long Paginas = _Resultado == null || _Resultado.TotalRegistros == 0 ? 0 : ConsultasFuncTotalPaginas(_Resultado);
                int Ancho;
                int Espacio;
                using (Componentes.ClsTableButtonConsultas Modelo = new Componentes.ClsTableButtonConsultas())
                {
                    Ancho = Math.Max(Modelo.Width, TextRenderer.MeasureText(new string('8', Math.Max(1, Paginas.ToString().Length)), Modelo.Font).Width + 10);
                    Espacio = Ancho + Modelo.Margin.Horizontal;
                }
                int Capacidad = Math.Max(0, ConsultasFlpPaginas.ClientSize.Width - ConsultasFlpPaginas.Padding.Horizontal) / Espacio;
                int Cantidad = (int)Math.Min(Paginas, Capacidad);
                if (Cantidad > 0)
                {
                    _InicioPaginas = Math.Max(1, Math.Min(_InicioPaginas, Paginas - Cantidad + 1));
                    if (_Resultado.Pagina < _InicioPaginas) _InicioPaginas = _Resultado.Pagina;
                    if (_Resultado.Pagina >= _InicioPaginas + Cantidad) _InicioPaginas = _Resultado.Pagina - Cantidad + 1;
                }
                bool Conservar = ConsultasFlpPaginas.Controls.Count == Cantidad;
                for (int Indice = 0; Conservar && Indice < Cantidad; Indice++)
                {
                    Control Boton = ConsultasFlpPaginas.Controls[Indice];
                    Conservar = Boton.Name == "ConsultasBtnPagina" + (_InicioPaginas + Indice) && Boton.Width == Ancho;
                }
                if (!Conservar)
                {
                    while (ConsultasFlpPaginas.Controls.Count > 0) ConsultasFlpPaginas.Controls[0].Dispose();
                    for (long Numero = _InicioPaginas; Numero < _InicioPaginas + Cantidad; Numero++)
                    {
                        int PaginaDestino = (int)Numero;
                        Componentes.ClsTableButtonConsultas Boton = new Componentes.ClsTableButtonConsultas { Name = "ConsultasBtnPagina" + Numero, Text = Numero.ToString(), Width = Ancho };
                        Boton.Click += (Sender, Evento) => ConsultasProcCargarPagina(PaginaDestino);
                        ConsultasFlpPaginas.Controls.Add(Boton);
                    }
                }
                int AlturaUtil = Math.Max(0, ConsultasFlpPaginas.ClientSize.Height - ConsultasFlpPaginas.Padding.Vertical);
                foreach (Componentes.ClsTableButtonConsultas Boton in ConsultasFlpPaginas.Controls)
                {
                    int EspacioVertical = Math.Max(0, AlturaUtil - Boton.Height);
                    Padding Margen = new Padding(Boton.Margin.Left, EspacioVertical / 2, Boton.Margin.Right, EspacioVertical - EspacioVertical / 2);
                    if (Boton.Margin != Margen) Boton.Margin = Margen;
                    Boton.EsActivo = _Resultado != null && Boton.Name == "ConsultasBtnPagina" + _Resultado.Pagina;
                }
            }
            finally
            {
                ConsultasFlpPaginas.ResumeLayout(true);
                _ActualizandoPaginas = false;
            }
        }

        private void ConsultasMetOrdenar(object Sender, DataGridViewCellMouseEventArgs Evento)
        {
            if (_Resultado == null || Evento.ColumnIndex < 0)
            {
                return;
            }
            string Campo = ConsultasUsrResultados.Columns[Evento.ColumnIndex].DataPropertyName;
            _Descendente = _CampoOrden == Campo && !_Descendente;
            _CampoOrden = Campo;
            ConsultasProcCargarPagina();
        }

        public void ConsultasProcSeleccionar(int IndiceFila = -1)
        {
            ClsInteraccionConsultas.ConsultasProcEjecutar(this, () =>
            {
                DataGridViewRow Fila = IndiceFila >= 0 && IndiceFila < ConsultasUsrResultados.Rows.Count ? ConsultasUsrResultados.Rows[IndiceFila] : ConsultasUsrResultados.CurrentRow;
                DataRowView Registro = Fila?.DataBoundItem as DataRowView;
                if (Registro == null || (IndiceFila < 0 && ConsultasUsrResultados.SelectedRows.Count == 0))
                {
                    throw new InvalidOperationException("Seleccione un registro.");
                }
                object Valor = _Controlador.ConsultasFuncSeleccionar(Registro.Row);
                string Pk = _Controlador.ConsultasFuncObtenerPk(Registro.Row);
                var Campos = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                foreach (DataColumn Columna in Registro.Row.Table.Columns)
                {
                    Campos.Add(Columna.ColumnName, Registro.Row[Columna]);
                }
                ConsultasEvtFilaSeleccionada?.Invoke(this, new ClsSeleccionConsulta(Valor, Pk, Campos));
            });
        }
        /*Fin del código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
    }
}
