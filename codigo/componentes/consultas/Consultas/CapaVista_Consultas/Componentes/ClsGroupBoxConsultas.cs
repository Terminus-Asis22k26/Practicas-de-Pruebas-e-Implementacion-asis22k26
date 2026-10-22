using System.Drawing;
using System.Windows.Forms;

namespace CapaVista_Consultas.Componentes
{
    public partial class ClsGroupBoxConsultas : GroupBox
    {
        /*Inicio de código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
        private static readonly Color _ColorTexto = ColorTranslator.FromHtml("#2E4A63");
        public ClsGroupBoxConsultas()
        {
            Font = new Font("Tahoma",10F,FontStyle.Bold,GraphicsUnit.Point);
            ForeColor = _ColorTexto;
            BackColor = Color.Transparent;
            FlatStyle = FlatStyle.Flat;
            Margin = new Padding(3);
        }
        /*Fin del código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
    }
}