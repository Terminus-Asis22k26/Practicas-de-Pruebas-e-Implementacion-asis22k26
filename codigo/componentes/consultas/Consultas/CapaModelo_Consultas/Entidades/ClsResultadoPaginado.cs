using System.Data;

namespace CapaModelo_Consultas.Entidades
{
    /*Inicio de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
    public sealed class ClsResultadoPaginado
    {
        public DataTable Datos { get; set; }
        public long TotalRegistros { get; set; }
        public int Pagina { get; set; }
        public int RegistrosPorPagina { get; set; }

        // Inicio cambio - Gabriel André Guillén Pocón - 0901-23-1998
        // Calcula cuántas páginas tiene el resultado según el total de registros.
        public int ConsultasFuncTotalPaginas()
        {
            if (RegistrosPorPagina <= 0)
            {
                return 0;
            }
            return (int)((TotalRegistros + RegistrosPorPagina - 1) / RegistrosPorPagina);
        }
        // Fin cambio - Gabriel André Guillén Pocón - 0901-23-1998
    }
    /* fin de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
}
