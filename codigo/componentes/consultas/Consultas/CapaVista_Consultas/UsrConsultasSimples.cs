using System;
using System.Windows.Forms;
using CapaControlador_Consultas;
using CapaVista_Consultas.Componentes;
// Inicio codigo Pedro José Gómez Villalobos 0901-23-4868 5/10/2026
namespace CapaVista_Consultas
{
    public partial class UsrConsultasSimples : UsrBaseConsultas, IEstadoVistaConsultas
    {
        public event EventHandler SolicitarComplejas;
        public event EventHandler SolicitarSalir;
        public event EventHandler<ClsSeleccionConsulta> ConsultasEvtSeleccion;
        private ClsControladorConsultasSimples _Controlador;
        private IContextoConsulta _Contexto;
        public UsrConsultasSimples()
        {
            InitializeComponent();
            ConsultasProcRegistrarDiseno();

            ConsultasProcLimpiarErrorValor();

            ConsultasUsrValor.TextChanged += (Sender, Evento) => { ConsultasProcLimpiarErrorValor(); ConsultasProcActualizarEstado(); };
            ConsultasBtnBuscar.Click += ConsultasMetBuscar;
            ConsultasBtnRefrescar.Click += ConsultasMetLimpiar;
            ConsultasBtnSalir.Click += (Sender, Evento) => SolicitarSalir?.Invoke(this, EventArgs.Empty);
            ConsultasBtnAyuda.Click += (Sender, Evento) => ClsInteraccionConsultas.ConsultasProcAyuda(this, "ConsultaSimple.html");
            ConsultasCboCampo.SelectedIndexChanged += ConsultasMetCambiarCampo;
            ConsultasCboOperador.SelectedIndexChanged += (Sender, Evento) =>
            {
                ConsultasProcLimpiarErrorValor();
                ConsultasProcActualizarEstado();
            };
            ConsultasUsrValor.ConsultasTxtEntrada.MouseClick += (Sender, Evento) => ConsultasUsrValor.ConsultasTxtEntrada.SelectAll();
            ConsultasUsrValor.TextoKeyDown += (Sender, Evento) =>
            {
                if (Evento.KeyCode == Keys.Enter)
                {
                    Evento.Handled = true;
                    Evento.SuppressKeyPress = true;
                    RichTextBox Entrada = ConsultasUsrValor.ConsultasTxtEntrada;
                    int Inicio = Entrada.SelectionStart;
                    int Longitud = Entrada.SelectionLength;
                    ConsultasMetBuscar(Sender, EventArgs.Empty);
                    ConsultasProcRestaurarFocoValor(Inicio, Longitud);
                    if (Entrada.IsHandleCreated && !Entrada.IsDisposed)
                    {
                        Entrada.BeginInvoke(new Action(() => ConsultasProcRestaurarFocoValor(Inicio, Longitud)));
                    }
                }
            };
            ConsultasUsrTabla.ConsultasEvtFilaSeleccionada += (Sender, Evento) => ConsultasEvtSeleccion?.Invoke(this, Evento);
            ConsultasProcActualizarEstado();
        }

        internal override System.Drawing.Size ConsultasFuncTamanoNecesario()
        {
            int Extra = Math.Max(0, (int)Math.Ceiling(ConsultasTlpAgregarFiltro.RowStyles[2].Height) - ConsultasFuncEscalarAltura(45));
            return new System.Drawing.Size(ConsultasTamanoDiseno.Width, ConsultasTamanoDiseno.Height + Extra);
        }

        private void ConsultasProcRestaurarFocoValor(int Inicio, int Longitud)
        {
            RichTextBox Entrada = ConsultasUsrValor.ConsultasTxtEntrada;
            if (Entrada.IsDisposed || !Entrada.Enabled) return;
            Entrada.Focus();
            int Posicion = Math.Min(Inicio, Entrada.TextLength);
            Entrada.Select(Posicion, Math.Min(Longitud, Entrada.TextLength - Posicion));
        }

        private void ConsultasProcLimpiarErrorValor()
        {
            ConsultasProcActualizarError(ConsultasUsrValor, 2, null);
        }

        private void ConsultasProcMostrarErrorValor(string Mensaje)
        {
            ConsultasProcActualizarError(ConsultasUsrValor, 2, Mensaje);
        }

        private void ConsultasProcActualizarError(UsrTextBoxConsultas Entrada, int Fila, string Mensaje)
        {
            int Altura = ConsultasFuncEscalarAltura(string.IsNullOrWhiteSpace(Mensaje) ? 45 : 65);
            int Extra = Math.Max(0, Altura - ConsultasFuncEscalarAltura(45));
            int AlturaPrincipal = ConsultasFuncEscalarAltura(145) + Extra;
            using (new ClsActualizacionDisenoConsultas(ConsultasTlpAgregarFiltro))
            {
                if (string.IsNullOrWhiteSpace(Mensaje)) Entrada.ConsultasProcLimpiarError();
                else Entrada.ConsultasProcMostrarError(Mensaje);
                ClsActualizacionDisenoConsultas.ConsultasProcAltura(ConsultasTlpAgregarFiltro.RowStyles[Fila], Altura);
                ClsActualizacionDisenoConsultas.ConsultasProcAltura(ConsultasTlpPrincipal.RowStyles[0], AlturaPrincipal);
                ConsultasProcNotificarTamano();
            }
        }

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
            ConsultasProcMostrarErrorValor(Error.Message);
        }

        internal void ConsultasProcActualizarEstado()
        {
            ConsultasCboCampo.Enabled = true;
            ConsultasCboOperador.Enabled = true;
            ConsultasBtnBuscar.Enabled = _Controlador != null && ConsultasCboCampo.SelectedIndex >= 0 && ConsultasCboOperador.SelectedIndex >= 0 && !string.IsNullOrWhiteSpace(ConsultasUsrValor.Text);
            ConsultasBtnRefrescar.Enabled = _Controlador != null && (ConsultasCboCampo.SelectedIndex >= 0 || ConsultasUsrValor.Text != "");
            ConsultasUsrValor.Enabled = true;
        }

        public void ConsultasProcConfigurar(ClsControladorConsultas Controlador)
        {
            ConsultasProcConfigurarSimples(Controlador?.Simples);
        }

        internal void ConsultasProcConfigurarSimples(ClsControladorConsultasSimples Controlador)
        {
            _Controlador = Controlador ?? throw new ArgumentNullException(nameof(Controlador));
            _Contexto = Controlador.Contexto;
            ConsultasUsrTabla.ConsultasProcConfigurarContexto(_Contexto, 15);
            ConsultasCboCampo.Items.Clear();
            ConsultasCboCampo.Items.AddRange(_Contexto.ConsultasFuncObtenerCampos());
            ConsultasCboCampo.SelectedIndex = -1;
            ConsultasCboOperador.Items.Clear();
            ConsultasUsrValor.Text = "";
            ConsultasUsrTabla.ConsultasProcCargarPagina();
        }

        private void ConsultasMetCambiarCampo(object Sender, EventArgs Evento)
        {
            ConsultasProcLimpiarErrorValor();
            if (_Controlador == null || ConsultasCboCampo.SelectedIndex < 0)
            {
                ConsultasProcActualizarEstado();
                return;
            }
            ClsInteraccionConsultas.ConsultasProcEjecutar(this, () =>
            {
                ConsultasUsrValor.Text = "";
                ConsultasCboOperador.Items.Clear();
                ConsultasCboOperador.Items.AddRange(_Contexto.ConsultasFuncObtenerOperadores(ConsultasCboCampo.Text));
                ConsultasCboOperador.SelectedIndex = 0;
                ConsultasProcLimpiarErrorValor();
            });
        }

        private void ConsultasMetBuscar(object Sender, EventArgs Evento)
        {
            ConsultasProcLimpiarErrorValor();
            ClsInteraccionConsultas.ConsultasProcEjecutar(this, () =>
            {
                if (_Controlador == null)
                {
                    throw new InvalidOperationException("Configure el contexto de búsqueda.");
                }
                _Controlador.ConsultasProcFiltrar(ConsultasCboCampo.Text, ConsultasCboOperador.Text, ConsultasUsrValor.Text);
                ConsultasUsrTabla.ConsultasProcLimpiar();
                ClsPaginaConsulta Pagina = ConsultasUsrTabla.ConsultasFuncCargarPrimeraPagina();
                if (Pagina.TotalRegistros == 0) ConsultasProcMostrarErrorValor(_Contexto.ConsultasFuncMensajeSinResultados(ConsultasCboCampo.Text));
            });
        }

        private void ConsultasMetLimpiar(object Sender, EventArgs Evento)
        {
            ClsInteraccionConsultas.ConsultasProcEjecutar(this, () =>
            {
                if (_Controlador == null)
                {
                    throw new InvalidOperationException("Configure el contexto de búsqueda.");
                }
                _Contexto.ConsultasProcLimpiarFiltro();
                ConsultasCboCampo.SelectedIndex = -1;
                ConsultasCboOperador.Items.Clear();
                ConsultasUsrValor.Text = "";
                ConsultasProcLimpiarErrorValor();
                ConsultasUsrTabla.ConsultasProcLimpiar();
                ConsultasUsrTabla.ConsultasProcCargarPagina();
            });
        }

        private void ConsultasMetMostrarComplejas(object Sender, EventArgs Evento)
        {
            SolicitarComplejas?.Invoke(this, EventArgs.Empty);
        }
    }
}

// Fin código Pedro José Gómez Villalobos 0901-23-4868 5/10/2026
