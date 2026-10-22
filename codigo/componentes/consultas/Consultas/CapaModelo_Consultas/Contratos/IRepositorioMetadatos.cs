using System.Collections.Generic;
using CapaModelo_Consultas.Entidades;

namespace CapaModelo_Consultas.Contratos
{
    /*Inicio de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
    public interface IRepositorioMetadatos
    {
        IList<string> ConsultasFuncObtenerTablas();
        bool ConsultasFuncEsVista(string Tabla);
        IList<ClsCampoConsulta> ConsultasFuncObtenerCampos(string Tabla);
    }
    /* fin de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
}
