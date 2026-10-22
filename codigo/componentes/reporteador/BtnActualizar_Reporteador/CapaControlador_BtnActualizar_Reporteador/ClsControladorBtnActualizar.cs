using System.Data;
using CapaModelo_BtnActualizar_Reporteador.Repositorios;

namespace CapaControlador_BtnActualizar_Reporteador
{
    public class ClsControladorBtnActualizar
    {
        private readonly ClsRepositorioBtnActualizar _RepositorioBtnActualizar;

        public ClsControladorBtnActualizar()
        {
            _RepositorioBtnActualizar =
                new ClsRepositorioBtnActualizar();
        }

        public DataTable ReporteadorMetObtenerReportes()
        {
            return _RepositorioBtnActualizar.ReporteadorMetObtenerTodos();
        }
    }
}