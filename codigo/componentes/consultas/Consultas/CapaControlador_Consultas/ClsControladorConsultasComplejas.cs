using System;
using System.Data;
using CapaModelo_Consultas.Entidades;

// Inicio código José Cano - 0901-23-1727
// Fecha: 03/10/2026

namespace CapaControlador_Consultas
{
    public sealed class ClsControladorConsultasComplejas
    {
        private readonly ClsServicioConsultasCompartidas _Compartidas;
        public IContextoConsulta Contexto => _Compartidas;
        private readonly ClsServicioConsultasGuardadas _Guardadas;
        public ClsServicioConsultasGuardadas Guardadas => _Guardadas;

        internal ClsControladorConsultasComplejas(ClsServicioConsultasCompartidas Compartidas, ClsServicioConsultasGuardadas Guardadas)
        {
            _Compartidas = Compartidas;
            _Guardadas = Guardadas;
        }

        public void ConsultasProcCargarGuardada(int Id)
        {
            ClsDefinicionConsulta Definicion = _Guardadas.ConsultasFuncObtenerDefinicion(Id);
            _Compartidas.Definicion = Definicion;
            _Compartidas.IdConsultaCargada = Id;
        }

        public void ConsultasProcValidarFila(string Campo, string Operador, string Valor, string Orden, string Conector)
        {
            ConsultasProcValidarFila(Campo, Operador, Valor, Orden, Conector, false);
        }

        public void ConsultasProcValidarFila(string Campo, string Operador, string Valor, string Orden, string Conector, bool TieneFiltroPrevio)
        {
            _Compartidas.Validador.ConsultasFuncValidarCondicion(Campo, Operador, Valor, Orden, Conector, false);
            if (TieneFiltroPrevio && !string.IsNullOrEmpty(Operador) && Conector != "AND" && Conector != "OR")
            {
                throw new ArgumentException("Seleccione AND u OR para el filtro posterior.");
            }
        }

        public void ConsultasProcValidarMantenimiento(DataTable Filas, int Id = 0)
        {
            _Guardadas.ConsultasFuncDefinicionTemporal(Filas, Id > 0);
        }

        public ClsPaginaConsulta ConsultasFuncVistaPrevia(DataTable Filas, int Id = 0, int RegistrosPorPagina = 30)
        {
            ClsDefinicionConsulta Definicion = _Guardadas.ConsultasFuncDefinicionTemporal(Filas, Id > 0);
            ClsDefinicionConsulta Anterior = _Compartidas.Definicion;
            int IdAnterior = _Compartidas.IdConsultaCargada;
            try
            {
                _Compartidas.Definicion = Definicion;
                ClsPaginaConsulta Pagina = _Compartidas.ConsultasFuncEjecutar(1, RegistrosPorPagina, null, false);
                _Compartidas.IdConsultaCargada = Id;
                return Pagina;
            }
            catch
            {
                _Compartidas.Definicion = Anterior;
                _Compartidas.IdConsultaCargada = IdAnterior;
                throw;
            }
        }
    }
    // Fin código José Cano - 0901-23-1727
    // Fecha: 03/10/2026

}
