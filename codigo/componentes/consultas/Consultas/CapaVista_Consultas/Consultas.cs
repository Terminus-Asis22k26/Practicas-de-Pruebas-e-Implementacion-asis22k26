using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace CapaVista_Consultas
{
    //Inicio Diego Fernando Santizo Samayoa 0901-22-15950 05/10/2026
    public class Consultas : Button, ISupportInitialize
    {
        private string _Tabla = "";
        private bool _Inicializando;
        private string _LlavePrimaria;
        private ClsSeleccionConsulta Seleccion;

        [Category("Consultas"), Description("Tabla o vista de la base activa que se consultará."), DefaultValue(""), Browsable(true), TypeConverter(typeof(ClsConvertidorTablaConsultas)), RefreshProperties(RefreshProperties.All)]
        public string Tabla
        {
            get { return _Tabla; }
            set
            {
                string Nueva = value ?? "";
                if (string.Equals(_Tabla, Nueva, StringComparison.Ordinal)) return;
                _Tabla = Nueva;
                if (!_Inicializando) CampoRetorno = "";
                TypeDescriptor.Refresh(this);
            }
        }

        [Category("Consultas"), Description("Columna de la tabla o vista seleccionada cuyo valor se devolverá."), DefaultValue(""), Browsable(true), TypeConverter(typeof(ClsConvertidorCampoRetornoConsultas))]
        public string CampoRetorno { get; set; } = "";

        [Category("Consultas"), Description("Control opcional del formulario consumidor que recibirá el texto seleccionado."), DefaultValue(null), Browsable(true), TypeConverter(typeof(ClsConvertidorControlRetornoConsultas)), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Control ControlRetorno { get; set; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object ValorSeleccionado { get; private set; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CampoSeleccionado { get; private set; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SeleccionRealizada { get; private set; }

        [Category("Consultas"), Description("Se emite una vez al confirmar una selección válida.")]
        public event EventHandler<ClsSeleccionConsulta> ConsultasEvtSeleccion;

        public void BeginInit()
        {
            _Inicializando = true;
        }

        public void EndInit()
        {
            _Inicializando = false;
            TypeDescriptor.Refresh(this);
        }

        protected override void OnClick(EventArgs Evento)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            ConsultasProcAbrir();
            base.OnClick(Evento);
        }

        private Control ConsultasFuncDestino(Form Propietario)
        {
            Control Destino = ControlRetorno;
            if (Destino == null) return null;
            if (Destino.IsDisposed || !ClsConvertidorControlRetornoConsultas.ConsultasFuncCompatible(Destino)) throw new ArgumentException("El destino debe ser TextBox, RichTextBox, Label, ComboBox editable o UsrTextBoxConsultas.");
            if (!ReferenceEquals(Destino.FindForm(), Propietario)) throw new ArgumentException("El control de retorno debe pertenecer al formulario consumidor.");
            return Destino;
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

        private void ConsultasProcAceptarSeleccion(ClsSeleccionConsulta Evento, Control Destino)
        {
            Seleccion = Evento;
            ValorSeleccionado = Evento.Valor;
            _LlavePrimaria = Evento.Pk;
            CampoSeleccionado = Convert.ToString(Evento.Valor, CultureInfo.InvariantCulture);
            SeleccionRealizada = true;
            if (Destino != null) Destino.Text = CampoSeleccionado;
            ConsultasEvtSeleccion?.Invoke(this, Evento);
        }

        private void ConsultasProcAbrir()
        {
            ClsInteraccionConsultas.ConsultasProcEjecutar(this, () =>
            {
                if (string.IsNullOrWhiteSpace(Tabla)) throw new ArgumentException("Configure Tabla antes de abrir Consultas.");
                if (string.IsNullOrWhiteSpace(CampoRetorno)) throw new ArgumentException("Configure CampoRetorno antes de abrir Consultas.");
                Form Propietario = FindForm();
                if (Propietario == null) throw new InvalidOperationException("El componente debe estar dentro del formulario consumidor.");
                Control Destino = ConsultasFuncDestino(Propietario);

                CapaControlador_Consultas.ClsControladorConsultas[] Controladores = FrmConsultas.ConsultasFuncPreparar(new[] { Tabla }, CampoRetorno);
                using (FrmConsultas Dialogo = new FrmConsultas(Controladores))
                {
                    if (Dialogo.ShowDialog(Propietario) != DialogResult.OK || !Dialogo.SeleccionRealizada) return;
                    ConsultasProcAceptarSeleccion(Dialogo.Seleccion, Destino);
                }
            });
        }
        //Fin Diego Fernando Santizo Samayoa 0901-22-15950 05/10/2026
    }
}
