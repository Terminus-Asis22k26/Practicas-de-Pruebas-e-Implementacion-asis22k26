using CapaModelo_Consultas.Entidades;

namespace CapaModelo_Consultas.Contratos
{
    /*Inicio de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
    public interface IRepositorioEjecucionConsultas
    {
        ClsResultadoPaginado ConsultasFuncEjecutar(ClsDefinicionConsulta Definicion, int Pagina, int RegistrosPorPagina, string CampoOrden, bool Descendente);
    }
    /* fin de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
}
