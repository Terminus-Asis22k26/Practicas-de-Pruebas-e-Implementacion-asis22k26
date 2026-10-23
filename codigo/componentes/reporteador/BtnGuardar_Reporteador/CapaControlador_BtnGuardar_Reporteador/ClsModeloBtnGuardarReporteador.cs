using System;
using CapaModelo_BtnGuardar_Reporteador.Repositorios;

namespace CapaControlador_BtnGuardar_Reporteador
{
    public class ClsModeloBtnGuardarReporteador
    {
        private readonly ClsRepositorioBtnGuardarReporteador
            _Repositorio;

        public ClsModeloBtnGuardarReporteador()
        {
            _Repositorio =
                new ClsRepositorioBtnGuardarReporteador();
        }

        public string ReporteadorMetGuardar(
            int NumeroReporte,
            string NombreReporte,
            string RutaReporte,
            DateTime FechaReporte,
            bool EsEdicion)
        {
       
            if (string.IsNullOrWhiteSpace(
                NombreReporte))
            {
                return
                    "El nombre del reporte no puede estar vacío.";
            }

            if (string.IsNullOrWhiteSpace(
                RutaReporte))
            {
                return
                    "La ruta del reporte es requerida.";
            }

            // Inicio cambio - Gabriel André Guillén Pocón - 0901-23-1998
            // Se quitan los espacios sobrantes antes de guardar
            NombreReporte = NombreReporte.Trim();
            RutaReporte = RutaReporte.Trim();
            // Fin cambio - Gabriel André Guillén Pocón - 0901-23-1998

            string MensajeError;

            bool Exito =
                _Repositorio.ReporteadorMetGuardarReporte(
                    NumeroReporte,
                    NombreReporte,
                    RutaReporte,
                    FechaReporte,
                    EsEdicion,
                    out MensajeError);

            if (Exito)
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(
                MensajeError))
            {
                return
                    "No se pudo procesar el reporte.";
            }

            return MensajeError;
        }
    }
}