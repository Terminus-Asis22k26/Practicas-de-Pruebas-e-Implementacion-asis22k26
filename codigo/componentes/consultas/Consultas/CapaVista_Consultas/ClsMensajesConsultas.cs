using System.Windows.Forms;
using CapaControlador_Consultas;

namespace CapaVista_Consultas
{
    /*Inicio de código de Gabriel André Guillén Pocón 0901-23-1998 el 21/10/2026*/
    public sealed class ClsMensajesConsultas
    {
        // Muestra un error de validacion
        public void ConsultasProcMostrarError(ClsErrorValidacion Error)
        {
            MessageBox.Show(Error.Message, "Consultas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    /* fin de código de Gabriel André Guillén Pocón 0901-23-1998 el 21/10/2026*/
}
