using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaVista_Consultas.Componentes
{
    internal sealed class ClsActualizacionDisenoConsultas : IDisposable
    {
        /*Inicio de código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
        private readonly List<Control> _Contenedores = new List<Control>();
        private readonly ClsTableLayoutPanelConsultas _PanelOculto;
        private bool _Finalizado;

        internal ClsActualizacionDisenoConsultas(Control Contenedor) : this(Contenedor, null)
        {
        }

        internal ClsActualizacionDisenoConsultas(Control Contenedor, ClsTableLayoutPanelConsultas PanelOculto)
        {
            for (Control Actual = Contenedor; Actual != null; Actual = Actual.Parent) _Contenedores.Add(Actual);
            for (int Indice = _Contenedores.Count - 1; Indice >= 0; Indice--) _Contenedores[Indice].SuspendLayout();
            _PanelOculto = PanelOculto;
            _PanelOculto?.ConsultasProcOcultarActualizacion();
        }

        public void Dispose()
        {
            if (_Finalizado) return;
            _Finalizado = true;
            try
            {
                ConsultasProcReanudar(0);
            }
            finally
            {
                _PanelOculto?.ConsultasProcRestaurarActualizacion();
            }
        }

        private void ConsultasProcReanudar(int Indice)
        {
            if (Indice == _Contenedores.Count) return;
            try
            {
                _Contenedores[Indice].ResumeLayout(true);
            }
            finally
            {
                ConsultasProcReanudar(Indice + 1);
            }
        }

        internal static void ConsultasProcAltura(RowStyle Fila, float Altura)
        {
            if (Fila.SizeType != SizeType.Absolute) Fila.SizeType = SizeType.Absolute;
            if (Fila.Height != Altura) Fila.Height = Altura;
        }
        /*Fin del código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
    }
}
