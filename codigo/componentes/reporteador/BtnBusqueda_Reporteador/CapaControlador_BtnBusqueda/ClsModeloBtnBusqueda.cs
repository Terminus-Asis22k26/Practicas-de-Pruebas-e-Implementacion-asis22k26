using System;
using System.Data;
using CapaModelo_BtnBusqueda_Reporteador.Repositorios;

namespace CapaControlador_BtnBusqueda_Reporteador
{
    public class ClsModeloBtnBusqueda
    {
        private readonly ClsRepositorioBtnBusqueda
            _Repositorio;

        public ClsModeloBtnBusqueda()
        {
            _Repositorio =
                new ClsRepositorioBtnBusqueda();
        }

        public DataTable ReporteadorMetBuscarReportes(
            string NombreReporte,
            DateTime? FechaReporte,
            bool BuscarPorNombre,
            bool BuscarPorFecha)
        {
            return _Repositorio
                .ReporteadorMetBuscarReportes(
                    NombreReporte,
                    FechaReporte,
                    BuscarPorNombre,
                    BuscarPorFecha);
        }
    }
}