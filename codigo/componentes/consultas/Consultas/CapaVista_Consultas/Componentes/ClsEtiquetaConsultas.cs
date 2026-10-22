using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaVista_Consultas.Componentes
{
    internal sealed class ClsEtiquetaConsultas : Label
    {
        /*Inicio de código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
        internal bool ConsultasConservarRojo { get; set; }

        protected override void OnPaint(PaintEventArgs Evento)
        {
            if (!ConsultasConservarRojo)
            {
                base.OnPaint(Evento);
                return;
            }
            TextFormatFlags Formato = TextFormatFlags.WordBreak | TextFormatFlags.NoPrefix | TextFormatFlags.TextBoxControl;
            if (TextAlign == ContentAlignment.MiddleLeft) Formato |= TextFormatFlags.VerticalCenter;
            Rectangle Area = new Rectangle(Padding.Left, Padding.Top, Math.Max(0, ClientSize.Width - Padding.Horizontal), Math.Max(0, ClientSize.Height - Padding.Vertical));
            TextRenderer.DrawText(Evento.Graphics, Text, Font, Area, Color.Red, Formato);
        }
        /*Fin del código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
    }
}
