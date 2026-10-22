using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CapaControlador_Consultas;

namespace CapaVista_Consultas
{
    //Inicio Diego Fernando Santizo Samayoa 0901-22-15950 05/10/2026
    public partial class FrmConsultas : Form
    {
        private readonly UsrConsultasSimples _ConsultasSimples;
        private readonly UsrConsultasComplejas _ConsultasComplejas;
        private ClsControladorConsultas _ControladorSimples;
        private Componentes.UsrBaseConsultas _VistaActiva;
        private bool _AjustandoTamano;
        private int _TransicionesVista;
        private int _VersionVista;
        private bool _Cargado;
        private bool _ComplejasCargadas;
        private ClsControladorConsultas _ControladorComplejas;
        private string _LlavePrimaria;
        internal ClsSeleccionConsulta Seleccion { get; private set; }
        public string CampoSeleccionado { get; private set; }
        public object ValorSeleccionado { get; private set; }
        public bool SeleccionRealizada { get; private set; }
        public Exception ErrorCarga { get; private set; }
        public FrmConsultas()
        {
            InitializeComponent();
            _ConsultasSimples = new UsrConsultasSimples();
            _ConsultasComplejas = new UsrConsultasComplejas();
            MinimumSize = Size.Empty;
            MaximumSize = Size.Empty;
            ConsultasPnlTarjeta.AutoScroll = true;
            _ConsultasSimples.ConsultasEvtTamanoNecesario += ConsultasMetAjustarTamano;
            _ConsultasComplejas.ConsultasEvtTamanoNecesario += ConsultasMetAjustarTamano;
            Shown += ConsultasMetAjustarTamano;
            Disposed += (Sender, Evento) => { _ConsultasSimples.Dispose(); _ConsultasComplejas.Dispose(); };

            _ConsultasSimples.SolicitarComplejas += ConsultasMetMostrarComplejas;
            _ConsultasComplejas.SolicitarSimples += (Sender, Evento) => ConsultasProcMostrarPanel(_ConsultasSimples);
            _ConsultasSimples.ConsultasEvtSeleccion += ConsultasMetSeleccionar;
            _ConsultasComplejas.ConsultasEvtSeleccion += ConsultasMetSeleccionar;
            _ConsultasSimples.SolicitarSalir += ConsultasMetSalir;
            _ConsultasComplejas.SolicitarSalir += ConsultasMetSalir;
            Load += ConsultasMetCargar;
            FormClosing += (Sender, Evento) =>
            {
                if (!SeleccionRealizada)
                {
                    DialogResult = DialogResult.Cancel;
                }
            };

            ConsultasProcMostrarPanel(_ConsultasSimples);
        }

        public FrmConsultas(string Tabla, string CampoId) : this(new[] { Tabla }, CampoId)
        {
        }

        public FrmConsultas(string[] Tablas, string CampoId) : this(ConsultasFuncPreparar(Tablas, CampoId))
        {
        }

        internal FrmConsultas(ClsControladorConsultas[] Controladores) : this()
        {
            _ControladorSimples = Controladores[0];
            _ControladorComplejas = Controladores[1];
        }

        internal static ClsControladorConsultas[] ConsultasFuncPreparar(string[] Tablas, string CampoId, ClsControladorConsultas Simple = null, ClsControladorConsultas Compleja = null)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return new ClsControladorConsultas[2];
            Simple = Simple ?? new ClsControladorConsultas();
            Compleja = Compleja ?? new ClsControladorConsultas();
            Simple.ConsultasProcValidarConfiguracion(Tablas, CampoId);
            Compleja.ConsultasProcValidarConfiguracion(Tablas, CampoId);
            return new[] { Simple, Compleja };
        }

        public void ConsultasProcConfigurar(string[] Tablas, string CampoId)
        {
            if (_Cargado)
            {
                throw new InvalidOperationException("El contexto debe configurarse antes de abrir la búsqueda.");
            }
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            _ControladorSimples = null;
            _ControladorComplejas = null;
            try
            {
                ClsControladorConsultas[] Controladores = ConsultasFuncPreparar(Tablas, CampoId);
                _ControladorSimples = Controladores[0];
                _ControladorComplejas = Controladores[1];
                ErrorCarga = null;
            }
            catch (Exception Excepcion)
            {
                ErrorCarga = Excepcion;
                throw;
            }
        }

        protected override void SetVisibleCore(bool Visible)
        {
            if (Visible && !DesignMode && LicenseManager.UsageMode != LicenseUsageMode.Designtime && _ControladorSimples == null)
            {
                ErrorCarga = ErrorCarga ?? new InvalidOperationException("Configure la tabla y el campo de retorno antes de abrir Consultas.");
                throw ErrorCarga;
            }
            if (Visible) ConsultasProcAjustarTamano();
            base.SetVisibleCore(Visible);
        }

        private void ConsultasMetCargar(object Sender, EventArgs Evento)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }
            ClsInteraccionConsultas.ConsultasProcEjecutar(this, () =>
            {
                _Cargado = true;
                try
                {
                    _ConsultasSimples.ConsultasProcConfigurarSimples(_ControladorSimples.Simples);
                }
                catch (Exception Excepcion)
                {
                    ErrorCarga = Excepcion;
                    throw;
                }
            });
        }

        private void ConsultasMetMostrarComplejas(object Sender, EventArgs Evento)
        {
            ClsInteraccionConsultas.ConsultasProcEjecutar(this, () =>
            {
                if (!_ComplejasCargadas)
                {
                    if (_ControladorComplejas == null)
                    {
                        throw new InvalidOperationException("Configure el contexto de búsqueda.");
                    }
                    _ConsultasComplejas.ConsultasProcConfigurarComplejas(_ControladorComplejas.Complejas);
                    _ComplejasCargadas = true;
                }
                ConsultasProcMostrarPanel(_ConsultasComplejas);
            });
        }


        public string ConsultasFuncObtenerCampoSeleccionado(string Campo)
        {
            if (!SeleccionRealizada) throw new InvalidOperationException("Seleccione un registro antes de obtener sus campos.");
            return Seleccion.ConsultasFuncObtenerCampoSeleccionado(Campo);
        }

        public object ConsultasFuncObtenerValorSeleccionado(string Campo)
        {
            if (!SeleccionRealizada) throw new InvalidOperationException("Seleccione un registro antes de obtener sus campos.");
            return Seleccion.ConsultasFuncObtenerValorSeleccionado(Campo);
        }

        public string ConsultasFuncObtenerLlavePrimaria()
        {
            return _LlavePrimaria;
        }

        private void ConsultasMetSeleccionar(object Sender, ClsSeleccionConsulta Evento)
        {
            if (SeleccionRealizada) return;
            Seleccion = Evento;
            ValorSeleccionado = Evento.Valor;
            _LlavePrimaria = Evento.Pk;
            CampoSeleccionado = Convert.ToString(Evento.Valor, System.Globalization.CultureInfo.InvariantCulture);
            SeleccionRealizada = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ConsultasMetSalir(object Sender, EventArgs Evento)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ConsultasMetAjustarTamano(object Sender, EventArgs Evento)
        {
            if (_TransicionesVista != 0) return;
            if (Sender == this) ConsultasProcAjustarTamano();
            else if (ReferenceEquals(Sender, _VistaActiva)) ConsultasProcAplicarTamano(Location, Screen.FromRectangle(Bounds).WorkingArea, false);
        }

        private void ConsultasProcAjustarTamano()
        {
            if (_TransicionesVista != 0) return;
            ConsultasProcAplicarTamano(Location, Screen.FromRectangle(Bounds).WorkingArea);
        }

        private void ConsultasProcAplicarTamano(Point PosicionSolicitada, Rectangle Area, bool AjustarPosicion = true)
        {
            if (_AjustandoTamano || _VistaActiva == null || IsDisposed || DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            _AjustandoTamano = true;
            try
            {
                Size Contenido = _VistaActiva.ConsultasFuncTamanoNecesario();
                Padding Margen = _VistaActiva.Margin;
                Size Interior = new Size(Contenido.Width + Margen.Horizontal + ConsultasPnlTarjeta.Padding.Horizontal, Contenido.Height + Margen.Vertical + ConsultasPnlTarjeta.Padding.Vertical);
                Size Necesario = new Size(Interior.Width + Padding.Horizontal + ConsultasPnlTarjeta.Margin.Horizontal, Interior.Height + Padding.Vertical + ConsultasPnlTarjeta.Margin.Vertical);
                foreach (Control Otro in Controls)
                {
                    if (Otro == ConsultasPnlTarjeta || Otro is MdiClient || !Otro.Visible) continue;
                    if (Otro.Dock == DockStyle.Top || Otro.Dock == DockStyle.Bottom) Necesario.Height += Otro.Height + Otro.Margin.Vertical;
                    if (Otro.Dock == DockStyle.Left || Otro.Dock == DockStyle.Right) Necesario.Width += Otro.Width + Otro.Margin.Horizontal;
                }
                Size Borde = SizeFromClientSize(Size.Empty);
                Size Disponible = new Size(Math.Max(1, Area.Width - Borde.Width), Math.Max(1, Area.Height - Borde.Height));
                bool Vertical = Necesario.Height > Disponible.Height;
                bool Horizontal = Necesario.Width > Disponible.Width;
                if (Vertical) Necesario.Width += SystemInformation.VerticalScrollBarWidth;
                if (Horizontal || Necesario.Width > Disponible.Width) Necesario.Height += SystemInformation.HorizontalScrollBarHeight;
                Size Cliente = new Size(Math.Min(Necesario.Width, Disponible.Width), Math.Min(Necesario.Height, Disponible.Height));
                Point Desplazamiento = ConsultasPnlTarjeta.AutoScrollPosition;
                Point PosicionVista = new Point(ConsultasPnlTarjeta.Padding.Left + Margen.Left + Desplazamiento.X, ConsultasPnlTarjeta.Padding.Top + Margen.Top + Desplazamiento.Y);
                Size Exterior = SizeFromClientSize(Cliente);
                Point Posicion = new Point(Math.Max(Area.Left, Math.Min(PosicionSolicitada.X, Area.Right - Exterior.Width)), Math.Max(Area.Top, Math.Min(PosicionSolicitada.Y, Area.Bottom - Exterior.Height)));
                using (new Componentes.ClsActualizacionDisenoConsultas(_VistaActiva))
                {
                    if (_VistaActiva.Size != Contenido) _VistaActiva.Size = Contenido;
                    if (_VistaActiva.Location != PosicionVista) _VistaActiva.Location = PosicionVista;
                    if (ConsultasPnlTarjeta.AutoScrollMinSize != Interior) ConsultasPnlTarjeta.AutoScrollMinSize = Interior;
                    if (ClientSize != Cliente) ClientSize = Cliente;
                    if (ConsultasPnlTarjeta.AutoScrollPosition != Desplazamiento) ConsultasPnlTarjeta.AutoScrollPosition = new Point(-Desplazamiento.X, -Desplazamiento.Y);
                    if (AjustarPosicion && Location != Posicion) Location = Posicion;
                }
            }
            finally
            {
                _AjustandoTamano = false;
            }
        }

        private void ConsultasProcMostrarPanel(UserControl Panel)
        {
            if (ReferenceEquals(_VistaActiva, Panel)) return;
            Point PosicionAnterior = Location;
            int Desplazamiento = ReferenceEquals(_VistaActiva, _ConsultasSimples) && ReferenceEquals(Panel, _ConsultasComplejas) ? -150 : ReferenceEquals(_VistaActiva, _ConsultasComplejas) && ReferenceEquals(Panel, _ConsultasSimples) ? 150 : 0;
            int DesplazamientoVertical = Desplazamiento < 0 ? -25 : Desplazamiento > 0 ? 25 : 0;
            Rectangle Area = Screen.FromRectangle(Bounds).WorkingArea;
            int Version = ++_VersionVista;
            _TransicionesVista++;
            try
            {
                using (new Componentes.ClsActualizacionDisenoConsultas(ConsultasPnlTarjeta))
                {
                    foreach (Control ControlActual in ConsultasPnlTarjeta.Controls)
                    {
                        if (ControlActual != Panel && (_VistaActiva == null || ReferenceEquals(ControlActual, _VistaActiva))) ControlActual.Visible = false;
                    }

                    if (!ConsultasPnlTarjeta.Controls.Contains(Panel))
                    {
                        if (Panel.Dock != DockStyle.None) Panel.Dock = DockStyle.None;
                        if (Panel.Anchor != (AnchorStyles.Top | AnchorStyles.Left)) Panel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                        ConsultasPnlTarjeta.Controls.Add(Panel);
                    }

                    if (ConsultasPnlTarjeta.AutoScrollPosition != Point.Empty) ConsultasPnlTarjeta.AutoScrollPosition = Point.Empty;
                    _VistaActiva = Panel as Componentes.UsrBaseConsultas;
                    ConsultasProcAplicarTamano(PosicionAnterior, Area, Desplazamiento == 0);
                    if (!Panel.Visible) Panel.Visible = true;
                    Panel.BringToFront();
                }
                if (Version != _VersionVista || IsDisposed || Disposing || Desplazamiento == 0) return;
                Point Posicion = new Point(PosicionAnterior.X + Desplazamiento, PosicionAnterior.Y + DesplazamientoVertical);
                if (Location != Posicion) Location = Posicion;
            }
            finally
            {
                _TransicionesVista--;
            }
        }
        //Fin Diego Fernando Santizo Samayoa 0901-22-15950 05/10/2026
    }
}
