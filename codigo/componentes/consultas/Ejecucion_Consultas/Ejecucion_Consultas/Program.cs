using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejecucion_Consultas
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static int Main(string[] Argumentos)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);/*
            if (Argumentos.Length == 1 && Argumentos[0] == "--verificar-dll")
            {
                using (CapaVista_Consultas.FrmConsultas Consulta = new CapaVista_Consultas.FrmConsultas("tblConsulta", "Pk_Consulta"))
                {
                    return !Consulta.SeleccionRealizada && Consulta.ValorSeleccionado == null && Consulta.ErrorCarga == null ? 0 : 1;
                }
            }*/
            //Application.Run(new CapaVista_Consultas.FrmConsultas("tblConsulta", "Pk_Consulta"));
            Application.Run(new FrmEjecucion());
            return 0;
        }
    }
}
