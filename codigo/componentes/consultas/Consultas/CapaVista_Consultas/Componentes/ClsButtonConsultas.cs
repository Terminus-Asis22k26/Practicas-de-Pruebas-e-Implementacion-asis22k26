using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CapaVista_Consultas.Componentes
{
    public partial class ClsButtonConsultas : Button
    {
        /*Inicio de código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
        private static readonly Color _FondoConsultas = ColorTranslator.FromHtml("#EDE7DA");

        private Image _ImagenDeshabilitado;
        private Image _ImagenNormal;
        private bool _ActualizandoImagen;

        [Category("Consultas")]
        [Description("Imagen de fondo que se muestra cuando el botón está deshabilitado.")]
        [DefaultValue(null)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image ImagenDeshabilitado
        {
            get { return _ImagenDeshabilitado; }
            set
            {
                _ImagenDeshabilitado = value;
                ConsultasProcActualizarImagen();
            }
        }

        public ClsButtonConsultas()
        {
            AutoSize = false;
            Size = new Size(80, 80);
            MinimumSize = new Size(80, 80);
            MaximumSize = new Size(80, 80);
            BackColor = _FondoConsultas;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            UseVisualStyleBackColor = false;
            BackgroundImageLayout = ImageLayout.Stretch;
            Cursor = Cursors.Hand;
            Margin = new Padding(0);
            Anchor = AnchorStyles.None;
        }

        protected override Size DefaultSize => new Size(80, 80);

        protected override void OnBackgroundImageChanged(EventArgs Evento)
        {
            if (!_ActualizandoImagen)
            {
                _ImagenNormal = BackgroundImage;
                ConsultasProcActualizarImagen();
            }

            base.OnBackgroundImageChanged(Evento);
        }

        protected override void OnEnabledChanged(EventArgs Evento)
        {
            ConsultasProcActualizarImagen();
            Cursor = Enabled ? Cursors.Hand : Cursors.Default;

            base.OnEnabledChanged(Evento);
        }

        private void ConsultasProcActualizarImagen()
        {
            Image ImagenActual = !Enabled && _ImagenDeshabilitado != null ? _ImagenDeshabilitado : _ImagenNormal;

            if (ReferenceEquals(BackgroundImage, ImagenActual))
            {
                return;
            }

            _ActualizandoImagen = true;

            try
            {
                BackgroundImage = ImagenActual;
            }
            finally
            {
                _ActualizandoImagen = false;
            }
        }
        /*Fin del código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
    }
}