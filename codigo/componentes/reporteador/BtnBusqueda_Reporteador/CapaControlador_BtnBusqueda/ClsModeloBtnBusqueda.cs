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
            // Inicio cambio - Gabriel André Guillén Pocón - 0901-23-1998
            // Se valida el criterio elegido antes de consultar al modelo
            if (BuscarPorNombre && string.IsNullOrWhiteSpace(NombreReporte))
            {
                throw new ArgumentException("Debe ingresar el nombre del reporte a buscar.");
            }

            if (BuscarPorFecha && !FechaReporte.HasValue)
            {
                throw new ArgumentException("Debe seleccionar la fecha del reporte a buscar.");
            }
            // Fin cambio - Gabriel André Guillén Pocón - 0901-23-1998

            return _Repositorio
                .ReporteadorMetBuscarReportes(
                    NombreReporte,
                    FechaReporte,
                    BuscarPorNombre,
                    BuscarPorFecha);
        }
    }
}