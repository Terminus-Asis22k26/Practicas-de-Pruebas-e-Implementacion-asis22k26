using System;
using System.Data.Odbc;

namespace CapaModelo_Consultas.Repositorios
{
    /*Inicio de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
    public sealed class ClsConexion
    {
        private readonly string _CadenaConexion;

        public ClsConexion(string CadenaConexion = "Dsn=EmbutidosS.A")
        {
            _CadenaConexion = CadenaConexion ?? "Dsn=EmbutidosS.A";
        }

        public OdbcConnection ConsultasFuncConexion()
        {
            OdbcConnection Conexion = new OdbcConnection(_CadenaConexion);
            try
            {
                Conexion.Open();
                return Conexion;
            }
            catch (OdbcException Excepcion)
            {
                Conexion.Dispose();
                throw new InvalidOperationException("No fue posible abrir la conexión de Consultas. Revise el DSN EmbutidosS.A y la arquitectura del controlador instalado.", Excepcion);
            }
            catch
            {
                Conexion.Dispose();
                throw;
            }
     
        }
        /* fin de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
    }
}
