using System.Data;
using CapaModelo_Consultas.Contratos;
using CapaModelo_Consultas.Repositorios;

namespace CapaControlador_Consultas
{
    //Inicio Diego Fernando Santizo Samayoa 0901-22-15950 05/10/2026
    public sealed class ClsControladorConsultas : IContextoConsulta
    {
        private readonly ClsServicioConsultasCompartidas _Compartidas;
        private readonly ClsServicioConsultasGuardadas _Guardadas;
        public ClsControladorConsultasSimples Simples { get; }
        public ClsControladorConsultasComplejas Complejas { get; }
        public int IdConsultaCargada => _Compartidas.IdConsultaCargada;
        public string Tabla => _Compartidas.Tabla;
        public string CampoRetorno => _Compartidas.CampoRetorno;

        public ClsControladorConsultas() : this(new ClsRepositorioMetadatos(), new ClsRepositorioEjecucionConsultas(), new ClsRepositorioConsultasGuardadas())
        {
        }

        public ClsControladorConsultas(IRepositorioMetadatos Metadatos, IRepositorioEjecucionConsultas Ejecucion, IRepositorioConsultasGuardadas Guardadas)
        {
            _Compartidas = new ClsServicioConsultasCompartidas(Metadatos, Ejecucion);
            _Guardadas = new ClsServicioConsultasGuardadas(_Compartidas, Guardadas);
            Simples = new ClsControladorConsultasSimples(_Compartidas);
            Complejas = new ClsControladorConsultasComplejas(_Compartidas, _Guardadas);
        }

        public void ConsultasProcConfigurar(string[] Tablas, string CampoId)
        {
            _Compartidas.ConsultasProcConfigurar(Tablas, CampoId);
        }

        public void ConsultasProcValidarConfiguracion(string[] Tablas, string CampoId)
        {
            _Compartidas.ConsultasProcValidarConfiguracion(Tablas, CampoId);
        }

        public void ConsultasProcCambiarTabla(string Nombre)
        {
            _Compartidas.ConsultasProcCambiarTabla(Nombre);
        }

        public string[] ConsultasFuncObtenerCampos()
        {
            return _Compartidas.ConsultasFuncObtenerCampos();
        }

        public string[] ConsultasFuncObtenerOperadores(string Nombre)
        {
            return _Compartidas.ConsultasFuncObtenerOperadores(Nombre);
        }

        public void ConsultasProcFiltrar(string Campo, string Operador, string Valor)
        {
            Simples.ConsultasProcFiltrar(Campo, Operador, Valor);
        }

        public void ConsultasProcLimpiarFiltro()
        {
            _Compartidas.ConsultasProcLimpiarFiltro();
        }

        public ClsPaginaConsulta ConsultasFuncEjecutar(int Pagina, int RegistrosPorPagina, string CampoOrden, bool Descendente)
        {
            return _Compartidas.ConsultasFuncEjecutar(Pagina, RegistrosPorPagina, CampoOrden, Descendente);
        }

        public object ConsultasFuncSeleccionar(DataRow Registro)
        {
            return _Compartidas.ConsultasFuncSeleccionar(Registro);
        }

        public string ConsultasFuncObtenerPk(DataRow Registro)
        {
            return _Compartidas.ConsultasFuncObtenerPk(Registro);
        }

        public DataTable ConsultasFuncListarGuardadas()
        {
            return _Guardadas.ConsultasFuncListarGuardadas();
        }

        public void ConsultasProcCargarGuardada(int Id)
        {
            Complejas.ConsultasProcCargarGuardada(Id);
        }

        public DataTable ConsultasFuncCargarMantenimiento(int Id, out string Nombre)
        {
            return _Guardadas.ConsultasFuncCargarMantenimiento(Id, out Nombre);
        }

        public void ConsultasProcEliminarGuardada(int Id)
        {
            _Guardadas.ConsultasProcEliminarGuardada(Id);
        }

        public void ConsultasProcValidarFila(string Campo, string Operador, string Valor, string Orden, string Conector)
        {
            Complejas.ConsultasProcValidarFila(Campo, Operador, Valor, Orden, Conector);
        }

        public void ConsultasProcValidarFila(string Campo, string Operador, string Valor, string Orden, string Conector, bool TieneFiltroPrevio)
        {
            Complejas.ConsultasProcValidarFila(Campo, Operador, Valor, Orden, Conector, TieneFiltroPrevio);
        }

        public void ConsultasProcValidarMantenimiento(DataTable Filas, int Id = 0)
        {
            Complejas.ConsultasProcValidarMantenimiento(Filas, Id);
        }

        public ClsPaginaConsulta ConsultasFuncVistaPrevia(DataTable Filas, int Id = 0, int RegistrosPorPagina = 30)
        {
            return Complejas.ConsultasFuncVistaPrevia(Filas, Id, RegistrosPorPagina);
        }

        public void ConsultasProcValidarGuardado(string Nombre, DataTable Filas, int Id = 0)
        {
            _Guardadas.ConsultasProcValidarGuardado(Nombre, Filas, Id);
        }

        public int ConsultasFuncGuardar(string Nombre, DataTable Filas, int Id = 0)
        {
            return _Guardadas.ConsultasFuncGuardar(Nombre, Filas, Id);
        }

        public void ConsultasProcGuardar(string Nombre, DataTable Filas)
        {
            _Guardadas.ConsultasProcGuardar(Nombre, Filas);
        }

        public string ConsultasFuncMensajeSinResultados(string NombreCampo)
        {
            return _Compartidas.ConsultasFuncMensajeSinResultados(NombreCampo);
        }
        //Fin Diego Fernando Santizo Samayoa 0901-22-15950 05/10/2026
    }
}
