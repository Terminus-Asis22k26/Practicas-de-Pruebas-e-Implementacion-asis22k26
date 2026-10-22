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
    }
    /* fin de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
}
