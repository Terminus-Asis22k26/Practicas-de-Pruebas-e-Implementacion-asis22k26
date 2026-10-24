using System.Data;

namespace CapaControlador_Consultas
{
    public sealed class ClsPaginaConsulta
    {
        /*Inicio de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
        public DataTable Datos { get; internal set; }
        public long TotalRegistros { get; internal set; }
        public int Pagina { get; internal set; }
        public int RegistrosPorPagina { get; internal set; }

        private int totalPaginas;

        public int calcularTotalPaginas()
        {
            if (RegistrosPorPagina <= 0)
            {
                return 0;
            }
            totalPaginas = (int)((TotalRegistros + RegistrosPorPagina - 1) / RegistrosPorPagina);
            return totalPaginas;
        }
    }
    /* fin de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
}
