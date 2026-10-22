using System.Drawing;
using System.Windows.Forms;

namespace CapaVista_Consultas.Componentes
{

    public partial class ClsComboBoxConsultas : ComboBox
    {
        /*Inicio de código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
        private static readonly Color _ColorTexto =ColorTranslator.FromHtml("#2E4A63");
        public ClsComboBoxConsultas()
        {
            Font = new Font("Segoe UI",10F,FontStyle.Regular,GraphicsUnit.Point);
            ForeColor = _ColorTexto;
            BackColor = Color.White;
            DropDownStyle = ComboBoxStyle.DropDownList;
            FlatStyle = FlatStyle.Flat;
            IntegralHeight = true;
            MaxDropDownItems = 8;
            Margin = new Padding(3);
        }

        protected override Size DefaultSize =>
            new Size(200, 27);
    }
    /*Fin del código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
    // Fin de código de "Diego Fernando Santizo Samayoa" - carné: "0901-22-15950" - Fecha: "15/09/26"

}
