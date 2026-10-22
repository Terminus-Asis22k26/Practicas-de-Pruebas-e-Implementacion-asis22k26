using System.Data.Odbc;
using CapaModelo_Consultas.Repositorios;

namespace CapaVista_Consultas
{
    /*Inicio de código de Gabriel André Guillén Pocón 0901-23-1998 el 21/10/2026*/
    public sealed class ClsLectorDirectoConsultas
    {
        // Cadena de conexion
        private readonly string _Cadena;

        // Constructor
        public ClsLectorDirectoConsultas(string Cadena)
        {
            _Cadena = Cadena;
        }

        // Cuenta registros de una tabla
        public int ConsultasFuncContar(string Tabla)
        {
            using (OdbcConnection Conexion = new OdbcConnection(_Cadena))
            {
                Conexion.Open();
                OdbcCommand Comando = new OdbcCommand("SELECT COUNT(*) FROM " + Tabla, Conexion);
                return System.Convert.ToInt32(Comando.ExecuteScalar());
            }
        }
    }
    /* fin de código de Gabriel André Guillén Pocón 0901-23-1998 el 21/10/2026*/
}
