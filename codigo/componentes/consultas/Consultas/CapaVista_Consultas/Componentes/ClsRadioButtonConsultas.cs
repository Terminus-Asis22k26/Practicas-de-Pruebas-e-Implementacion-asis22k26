using System.Drawing;
using System.Windows.Forms;

namespace CapaVista_Consultas.Componentes
{
    internal class ClsRadioButtonConsultas : RadioButton
    {
        /*Inicio de código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
        private static readonly Color _ColorTexto =
            ColorTranslator.FromHtml("#2E4A63");

        public ClsRadioButtonConsultas()
        {
            Font = new Font("Tahoma",9.0F,FontStyle.Regular,GraphicsUnit.Point);

            ForeColor = _ColorTexto;
            BackColor = Color.Transparent;
            AutoSize = true;
            Cursor = Cursors.Hand;
            UseVisualStyleBackColor = true;
            Margin = new Padding(3);
        }
        /*Fin del código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
    }
}
