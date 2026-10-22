using System.Collections.Generic;
using CapaModelo_Consultas.Entidades;
/*Inicio de código de Diana Mishel Loeiza Ramirez 9959-23-3457 el 6/10/2026*/
namespace CapaModelo_Consultas.Contratos
{
    public interface IRepositorioConsultasGuardadas
    {
        IList<ClsConsultaGuardada> ConsultasFuncListar(string Tabla);
        ClsConsultaGuardada ConsultasFuncObtener(int Id, string Tabla);
        bool ConsultasFuncExisteNombre(string Nombre, int IdExcluir = 0);
        void ConsultasProcGuardar(ClsConsultaGuardada Consulta);
        void ConsultasProcActualizar(ClsConsultaGuardada Consulta);
        void ConsultasProcEliminar(int Id, string Tabla);
    }
}
/*Fin de código de Diana Mishel Loeiza Ramirez 9959-23-3457 el 6/10/2026*/
