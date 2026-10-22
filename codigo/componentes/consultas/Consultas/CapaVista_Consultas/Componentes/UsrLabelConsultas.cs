using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CapaVista_Consultas.Componentes
{
    public partial class UsrLabelConsultas : UserControl
    {
        /*Inicio de código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
        private bool _MostrarAsterisco = true;

        internal void ConsultasProcConservarRojo()
        {
            ((ClsEtiquetaConsultas)ConsultasLblTexto).ConsultasConservarRojo = true;
            ColorTexto = Color.Red;
            ConsultasLblTexto.Invalidate();
        }

        public UsrLabelConsultas()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Font = new Font("Tahoma",9F,FontStyle.Regular);
            ConsultasLblTexto.Font = Font;
        }

        [Category("Consultas")]
        [Description("Texto que se mostrará en el label.")]
        [DefaultValue("Label de Consultas")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Texto
        {
            get { return ConsultasLblTexto.Text; }
            set { ConsultasLblTexto.Text = value; }
        }

        [Category("Consultas")]
        [Description("Color del texto del label.")]
        [DefaultValue(typeof(Color), "46, 74, 99")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ColorTexto
        {
            get { return ConsultasLblTexto.ForeColor; }
            set { ConsultasLblTexto.ForeColor = value; }
        }

        [Category("Consultas")]
        [Description("Muestra u oculta el asterisco y su columna.")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool MostrarAsterisco
        {
            get { return _MostrarAsterisco; }
            set { ConsultasProcMostrarAsterisco(value); }
        }

        [Category("Consultas")]
        [Description("Define la alineación del texto de la etiqueta.")]
        [DefaultValue(ContentAlignment.MiddleRight)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ContentAlignment AlineacionTexto
        {
            get { return ConsultasLblTexto.TextAlign; }
            set { ConsultasLblTexto.TextAlign = value; }
        }


        public void ConsultasProcMostrarAsterisco(bool Mostrar)
        {
            if (_MostrarAsterisco == Mostrar && ConsultasTlpMain.ColumnCount == (Mostrar ? 2 : 1)) return;
            using (new ClsActualizacionDisenoConsultas(ConsultasTlpMain))
            {
                if (Mostrar)
                {
                    if (ConsultasTlpMain.ColumnCount == 1)
                    {
                        ConsultasTlpMain.ColumnCount = 2;
                        ConsultasTlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
                    }

                    if (!ConsultasTlpMain.Controls.Contains(ConsultasLblAsterisco))
                    {
                        ConsultasTlpMain.Controls.Add(ConsultasLblAsterisco, 1, 0);
                    }

                    if (!ConsultasLblAsterisco.Visible) ConsultasLblAsterisco.Visible = true;
                }
                else
                {
                    if (ConsultasLblAsterisco.Visible) ConsultasLblAsterisco.Visible = false;
                    ConsultasTlpMain.Controls.Remove(ConsultasLblAsterisco);

                    while (ConsultasTlpMain.ColumnStyles.Count > 1)
                    {
                        ConsultasTlpMain.ColumnStyles.RemoveAt(1);
                    }

                    ConsultasTlpMain.ColumnCount = 1;
                }

                _MostrarAsterisco = Mostrar;
            }
        }
        /*Fin del código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
    }
}
