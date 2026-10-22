using System.Data;

namespace CapaControlador_Consultas
{
    /*Inicio de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
    public interface IContextoConsulta
    {
        string Tabla { get; }
        string CampoRetorno { get; }
        string[] ConsultasFuncObtenerCampos();
        string[] ConsultasFuncObtenerOperadores(string Nombre);
        void ConsultasProcLimpiarFiltro();
        ClsPaginaConsulta ConsultasFuncEjecutar(int Pagina, int RegistrosPorPagina, string CampoOrden, bool Descendente);
        object ConsultasFuncSeleccionar(DataRow Registro);
        string ConsultasFuncObtenerPk(DataRow Registro);
        string ConsultasFuncMensajeSinResultados(string NombreCampo);
    }
    /* fin de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
}
