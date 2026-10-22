using CapaVista_Consultas;
using System.Windows.Forms;

namespace Ejecucion_Consultas
{
    public partial class FrmEjecucion : Form
    {
        public FrmEjecucion()
        {
            InitializeComponent();
            ConsultasUsrCampoRetornado.ConsultasProcLimpiarError();
            ConsultasUsrPkRetornado.ConsultasProcLimpiarError();
            consultas1.ConsultasEvtSeleccion += ConsultasMetSeleccionar;
        }

        private void ConsultasMetSeleccionar(object Sender, ClsSeleccionConsulta Evento)
        {
            //Obtener llave primaria del registro seleccionado y mostrarla en el control de usuario
            string Pk = consultas1.ConsultasFuncObtenerLlavePrimaria(); 
            ConsultasUsrPkRetornado.Text = Pk;
            
            //Obtener un campo del registro seleccionado y mostrarlo en el control de usuario
            string Campo = consultas1.ConsultasFuncObtenerCampoSeleccionado("tablaConsulta");
            // ↓ Descomentar para probar esta función ↓
            //ConsultasUsrCampoRetornado.Text = Campo;

            ConsultasUsrPkRetornado.ConsultasProcMostrarError("Esta es la llave primaria del registro");
            ConsultasUsrCampoRetornado.ConsultasProcMostrarError("Este es el campo deseado del registro");
        }
    }
}
