using System;
using System.Data.Odbc;
using System.Text.RegularExpressions;

namespace CapaModelo_Consultas.Repositorios
{
    public abstract class ClsRepositorio
    {

        /*Inicio de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
        private readonly ClsConexion _Conexion;

        protected ClsRepositorio(string CadenaConexion)
        {
            _Conexion = new ClsConexion(CadenaConexion);
        }

        protected OdbcConnection ConsultasFuncAbrirConexion()
        {
            return _Conexion.ConsultasFuncConexion();
        }

        internal static string ConsultasFuncIdentificador(string Nombre)
        {
            if (string.IsNullOrWhiteSpace(Nombre) || !Regex.IsMatch(Nombre, @"\A[A-Za-z_][A-Za-z0-9_]*\z"))
            {
                throw new ArgumentException("El identificador de tabla o campo no es válido.");
            }
            return "`" + Nombre + "`";
        }

        internal static void ConsultasProcAgregarParametro(OdbcCommand Comando, object Valor)
        {
            OdbcType Tipo = OdbcType.NVarChar;
            if (Valor is decimal) Tipo = OdbcType.Decimal;
            else if (Valor is double) Tipo = OdbcType.Double;
            else if (Valor is long || Valor is int) Tipo = OdbcType.BigInt;
            else if (Valor is DateTime) Tipo = OdbcType.DateTime;
            else if (Valor is TimeSpan) Tipo = OdbcType.Time;
            else if (Valor is bool) Tipo = OdbcType.Bit;
            OdbcParameter Parametro = Comando.Parameters.Add("p" + Comando.Parameters.Count, Tipo);
            Parametro.Value = Valor ?? DBNull.Value;
        }
    }
    /* fin de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/

}
