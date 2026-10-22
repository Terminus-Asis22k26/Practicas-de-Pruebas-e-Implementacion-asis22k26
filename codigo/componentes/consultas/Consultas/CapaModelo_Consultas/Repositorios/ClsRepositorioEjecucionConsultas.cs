using System;
using System.Data;
using System.Data.Odbc;
using CapaModelo_Consultas.Contratos;
using CapaModelo_Consultas.Entidades;

namespace CapaModelo_Consultas.Repositorios
{

    /*Inicio de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
    public sealed class ClsRepositorioEjecucionConsultas : ClsRepositorio, IRepositorioEjecucionConsultas
    {
        private readonly IRepositorioMetadatos _Metadatos;

        public ClsRepositorioEjecucionConsultas(string CadenaConexion = null) : base(CadenaConexion)
        {
            _Metadatos = new ClsRepositorioMetadatos(CadenaConexion);
        }

        public ClsResultadoPaginado ConsultasFuncEjecutar(ClsDefinicionConsulta Definicion, int Pagina, int RegistrosPorPagina, string CampoOrden, bool Descendente)
        {
            if (Definicion == null) throw new ArgumentNullException(nameof(Definicion));
            if (Pagina < 1 || RegistrosPorPagina < 1 || RegistrosPorPagina > 500) throw new ArgumentOutOfRangeException(nameof(Pagina));
            ClsConsultaPreparada Consulta = ClsConstructorConsulta.ConsultasFuncConstruir(Definicion, _Metadatos.ConsultasFuncObtenerCampos(Definicion.Tabla), CampoOrden, Descendente);
            using (OdbcConnection Conexion = ConsultasFuncAbrirConexion())
            using (OdbcTransaction Transaccion = Conexion.BeginTransaction(IsolationLevel.RepeatableRead))
            using (OdbcCommand Conteo = new OdbcCommand("SELECT COUNT(*) FROM (" + Consulta.Texto + ") AS ConsultasResultado", Conexion, Transaccion))
            {
                foreach (object Valor in Consulta.Valores) ConsultasProcAgregarParametro(Conteo, Valor);
                long Total = Convert.ToInt64(Conteo.ExecuteScalar());
                int PaginaReal = (int)Math.Min(Pagina, Math.Max(1, (Total + RegistrosPorPagina - 1) / RegistrosPorPagina));
                DataTable Datos = new DataTable();
                using (OdbcCommand Comando = new OdbcCommand("SELECT * FROM (" + Consulta.Texto + ") AS ConsultasResultado ORDER BY " + Consulta.Orden + " LIMIT ? OFFSET ?", Conexion, Transaccion))
                {
                    foreach (object Valor in Consulta.Valores) ConsultasProcAgregarParametro(Comando, Valor);
                    ConsultasProcAgregarParametro(Comando, RegistrosPorPagina);
                    ConsultasProcAgregarParametro(Comando, ((long)PaginaReal - 1) * RegistrosPorPagina);
                    using (OdbcDataAdapter Adaptador = new OdbcDataAdapter(Comando)) Adaptador.Fill(Datos);
                }
                Transaccion.Commit();
                return new ClsResultadoPaginado { Datos = Datos, TotalRegistros = Total, Pagina = PaginaReal, RegistrosPorPagina = RegistrosPorPagina };
            }
        }
    }
    /* fin de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
}
