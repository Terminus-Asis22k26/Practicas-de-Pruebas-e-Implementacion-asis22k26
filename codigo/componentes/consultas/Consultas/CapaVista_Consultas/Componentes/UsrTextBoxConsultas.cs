using System.Drawing;
using System.Windows.Forms;

namespace CapaVista_Consultas.Componentes
{
    public partial class UsrTextBoxConsultas : UserControl
    {
        /*Inicio del código de Carlos Andres arriaza Lara 0901-23-13862 el 5/10/2026 */
        private bool _ErrorVisible = true;

        public UsrTextBoxConsultas()
        {
            InitializeComponent();
            DoubleBuffered = true;
            ConsultasUsrError.ConsultasProcConservarRojo();
            ConsultasTxtTexto.TextChanged += (Sender, Evento) =>
            {
                ConsultasProcLimpiarError();
                OnTextChanged(Evento);
            };
            Enter += (Sender, Evento) => ConsultasTxtTexto.Focus();
        }

        public override string Text
        {
            get
            {
                return ConsultasTxtTexto == null ? base.Text : ConsultasTxtTexto.Text;
            }
            set
            {
                bool Cambiado = Text != (value ?? "");
                if (ConsultasTxtTexto != null)
                {
                    ConsultasTxtTexto.Text = value;
                }
                base.Text = value;
                if (Cambiado && ConsultasTxtTexto != null && !ConsultasTxtTexto.IsHandleCreated)
                {
                    ConsultasProcLimpiarError();
                    OnTextChanged(System.EventArgs.Empty);
                }
            }
        }

        internal RichTextBox ConsultasTxtEntrada => ConsultasTxtTexto;

        public int MaxLength
        {
            get
            {
                return ConsultasTxtTexto.MaxLength;
            }
            set
            {
                ConsultasTxtTexto.MaxLength = value;
            }
        }

        public event KeyEventHandler TextoKeyDown
        {
            add
            {
                ConsultasTxtTexto.KeyDown += value;
            }
            remove
            {
                ConsultasTxtTexto.KeyDown -= value;
            }
        }

        public void ConsultasProcMostrarError(string Mensaje)
        {
            if (string.IsNullOrWhiteSpace(Mensaje))
            {
                ConsultasProcLimpiarError();
                return;
            }

            using (new ClsActualizacionDisenoConsultas(ConsultasTlpMain))
            {
                if (ConsultasUsrError.Texto != Mensaje) ConsultasUsrError.Texto = Mensaje;
                if (ConsultasUsrError.ColorTexto != Color.Red) ConsultasUsrError.ColorTexto = Color.Red;
                if (!_ErrorVisible) ConsultasUsrError.Visible = true;
                _ErrorVisible = true;
                if (ConsultasTlpMain.RowStyles[1].SizeType != SizeType.AutoSize) ConsultasTlpMain.RowStyles[1].SizeType = SizeType.AutoSize;
                if (ConsultasPnlBorde.BackColor != Color.Red) ConsultasPnlBorde.BackColor = Color.Red;
            }
        }

        internal int ConsultasFuncAlturaError(string Mensaje)
        {
            int Ancho = System.Math.Max(1, Width - 12);
            int Altura = System.Math.Max(22, TextRenderer.MeasureText(Mensaje, ConsultasUsrError.Font, new Size(Ancho, int.MaxValue), TextFormatFlags.WordBreak).Height);
            return 50 + Altura;
        }

        internal void ConsultasProcAmpliarError(int AlturaFila)
        {
            int Altura = AlturaFila - 50;
            using (new ClsActualizacionDisenoConsultas(ConsultasTlpMain))
            {
                if (ConsultasUsrError.MaximumSize != new Size(1000, Altura)) ConsultasUsrError.MaximumSize = new Size(1000, Altura);
                if (ConsultasUsrError.MinimumSize != new Size(0, Altura)) ConsultasUsrError.MinimumSize = new Size(0, Altura);
                if (MaximumSize != new Size(1000, 40 + Altura)) MaximumSize = new Size(1000, 40 + Altura);
            }
        }

        public void ConsultasProcLimpiarError()
        {
            using (new ClsActualizacionDisenoConsultas(ConsultasTlpMain))
            {
                if (ConsultasUsrError.Texto != string.Empty) ConsultasUsrError.Texto = string.Empty;
                if (_ErrorVisible) ConsultasUsrError.Visible = false;
                _ErrorVisible = false;
                if (ConsultasUsrError.MinimumSize != Size.Empty) ConsultasUsrError.MinimumSize = Size.Empty;
                if (ConsultasUsrError.MaximumSize != new Size(1000, 22)) ConsultasUsrError.MaximumSize = new Size(1000, 22);
                if (MaximumSize != new Size(1000, 62)) MaximumSize = new Size(1000, 62);
                ClsActualizacionDisenoConsultas.ConsultasProcAltura(ConsultasTlpMain.RowStyles[1], 0);
                if (ConsultasPnlBorde.BackColor != Color.FromArgb(46, 74, 99)) ConsultasPnlBorde.BackColor = Color.FromArgb(46, 74, 99);
            }
        }
        /*Fin del código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026 */
    }
}
