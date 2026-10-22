using System;
using System.Collections.Generic;
using CapaModelo_Reporteador.Entidades;
using CapaModelo_Reporteador.Repositorios;

namespace CapaControlador_Reporteador
{
    public class ClsModeloReporteador
    {
        public int NumeroReporte { get; set; }

        public int IdAplicacion { get; set; }

        public string NombreReporte { get; set; }

        public string RutaReporte { get; set; }

        public DateTime FechaReporte { get; set; }

        public ClsEstadoEntidad Estado { get; set; }

        private readonly ClsRepositorioReporteador _Repositorio;

        public ClsModeloReporteador()
        {
            _Repositorio = new ClsRepositorioReporteador();
        }

        // ============================================================
        // GUARDAR / ACTUALIZAR
        // ============================================================

        public string ReporteadorMetGuardarReporte()
        {
            try
            {
                if (IdAplicacion < 0)
                {
                    return "La aplicación seleccionada no es válida.";
                }

                if (NumeroReporte <= 0)
                {
                    return "El número de reporte debe ser mayor que cero.";
                }

                if (string.IsNullOrWhiteSpace(NombreReporte))
                {
                    return "Debe ingresar el nombre del reporte.";
                }

                if (string.IsNullOrWhiteSpace(RutaReporte))
                {
                    return "Debe seleccionar el archivo del reporte.";
                }

                NombreReporte = NombreReporte.Trim();

                RutaReporte = RutaReporte.Trim();

                int? NumeroReporteExcluir = null;

                if (Estado == ClsEstadoEntidad.Modified)
                {
                    NumeroReporteExcluir = NumeroReporte;
                }

                if (
                    Estado == ClsEstadoEntidad.Added
                    && _Repositorio.ReporteadorMetExisteAplicacionReporte(IdAplicacion)
                )
                {
                    return "Solo un reporte por aplicación.";
                }

                // ----------------------------------------------------
                // VALIDAR NÚMERO
                // ----------------------------------------------------

                if (
                    _Repositorio.ReporteadorMetExisteNumeroReporte(
                        NumeroReporte,
                        NumeroReporteExcluir
                    )
                )
                {
                    return "El número de reporte ya existe. No se puede guardar.";
                }

                // ----------------------------------------------------
                // VALIDAR NOMBRE
                // ----------------------------------------------------

                if (
                    _Repositorio.ReporteadorMetExisteNombreReporte(
                        NombreReporte,
                        NumeroReporteExcluir
                    )
                )
                {
                    return "El nombre del reporte ya existe. No se puede guardar.";
                }

                // ----------------------------------------------------
                // VALIDAR RUTA
                // ----------------------------------------------------

                if (_Repositorio.ReporteadorMetExisteRutaReporte(RutaReporte, NumeroReporteExcluir))
                {
                    return "La ruta del reporte ya está registrada. No se puede guardar.";
                }

                ClsReporteador Reporte = new ClsReporteador();

                Reporte.NumeroReporte = NumeroReporte;

                Reporte.NombreReporte = NombreReporte;

                Reporte.RutaReporte = RutaReporte;

                Reporte.FechaReporte = FechaReporte;

                // ----------------------------------------------------
                // EDITAR
                // ----------------------------------------------------

                if (Estado == ClsEstadoEntidad.Modified)
                {
                    _Repositorio.ReporteadorMetEditar(Reporte);

                    return "Actualización exitosa";
                }

                // ----------------------------------------------------
                // AGREGAR
                // ----------------------------------------------------

                if (Estado == ClsEstadoEntidad.Added)
                {
                    _Repositorio.ReporteadorMetAgregar(Reporte, IdAplicacion);

                    return "Grabación exitosa";
                }

                return "No se especificó una operación válida.";
            }
            catch (Exception)
            {
                return "No se pudo guardar el reporte. "
                    + "Verifique los datos e inténtelo nuevamente.";
            }
        }

        // ============================================================
        // OBTENER TODOS
        // ============================================================

        public IEnumerable<ClsReporteador> ReporteadorMetObtenerTodos(int IdAplicacion)
        {
            return _Repositorio.ReporteadorMetObtenerTodos(IdAplicacion);
        }

        public IEnumerable<ClsAplicacionReporteador> ReporteadorMetObtenerAplicaciones()
        {
            return _Repositorio.ReporteadorMetObtenerAplicaciones();
        }

        public int ReporteadorMetObtenerMaximoNumeroReporteGlobal()
        {
            return _Repositorio.ReporteadorMetObtenerMaximoNumeroReporteGlobal();
        }

        public string ReporteadorMetObtenerRutaPrimerReporte(int IdAplicacion)
        {
            return _Repositorio.ReporteadorMetObtenerRutaPrimerReporte(IdAplicacion);
        }
    }
}
