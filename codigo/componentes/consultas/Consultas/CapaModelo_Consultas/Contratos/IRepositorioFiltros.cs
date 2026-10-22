using System.Collections.Generic;
using CapaModelo_Consultas.Entidades;

namespace CapaModelo_Consultas.Contratos
{
    /*Inicio de código de Gabriel André Guillén Pocón 0901-23-1998 el 21/10/2026*/
    public interface IRepositorioFiltros
    {
        IList<ClsFiltroConsulta> ConsultasFuncObtenerFiltros(int IdConsulta);
    }
    /* fin de código de Gabriel André Guillén Pocón 0901-23-1998 el 21/10/2026*/
}
