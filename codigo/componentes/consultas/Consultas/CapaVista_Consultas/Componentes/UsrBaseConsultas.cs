using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaVista_Consultas.Componentes
{
    public partial class UsrBaseConsultas : UserControl
    {
        /*Inicio del código de Carlos Andres Arriaza Lara el 5/10/2026*/
        private Size _TamanoDiseno;
        private float _EscalaAltura = 1F;
        internal event EventHandler ConsultasEvtTamanoNecesario;
        internal Size ConsultasTamanoDiseno => _TamanoDiseno;

        internal void ConsultasProcRegistrarDiseno()
        {
            _TamanoDiseno = ClientSize;
            MaximumSize = Size.Empty;
        }

        internal int ConsultasFuncEscalarAltura(float Altura)
        {
            return (int)Math.Ceiling(Altura * _EscalaAltura);
        }

        internal void ConsultasProcNotificarTamano()
        {
            ConsultasEvtTamanoNecesario?.Invoke(this, EventArgs.Empty);
        }

        internal virtual Size ConsultasFuncTamanoNecesario()
        {
            return _TamanoDiseno;
        }

        protected override void ScaleControl(SizeF Factor, BoundsSpecified Especificado)
        {
            base.ScaleControl(Factor, Especificado);
            if (_TamanoDiseno.IsEmpty) return;
            _TamanoDiseno = new Size((int)Math.Ceiling(_TamanoDiseno.Width * Factor.Width), (int)Math.Ceiling(_TamanoDiseno.Height * Factor.Height));
            _EscalaAltura *= Factor.Height;
            ConsultasProcNotificarTamano();
        }

        public UsrBaseConsultas()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
        /*Fin del código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026 */
    }
}
