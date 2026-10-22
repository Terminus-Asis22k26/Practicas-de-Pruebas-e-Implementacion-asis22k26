using System;
using System.Data;
using CapaModelo_Consultas.Contratos;
using CapaModelo_Consultas.Entidades;
/*Inicio de código de Diana Mishel Loeiza Ramirez 9959-23-3457 el 6/10/2026*/
namespace CapaControlador_Consultas
{
    public sealed class ClsServicioConsultasGuardadas
    {
        private readonly ClsServicioConsultasCompartidas _Compartidas;
        private readonly IRepositorioConsultasGuardadas _Guardadas;

        internal ClsServicioConsultasGuardadas(ClsServicioConsultasCompartidas Compartidas, IRepositorioConsultasGuardadas Guardadas)
        {
            _Compartidas = Compartidas;
            _Guardadas = Guardadas ?? throw new ArgumentNullException(nameof(Guardadas));
        }

        public DataTable ConsultasFuncListarGuardadas()
        {
            _Compartidas.ConsultasProcCargarCampos();
            DataTable Catalogo = new DataTable();
            Catalogo.Columns.Add("Id", typeof(int));
            Catalogo.Columns.Add("Nombre", typeof(string));
            foreach (ClsConsultaGuardada Consulta in _Guardadas.ConsultasFuncListar(_Compartidas.Tabla))
            {
                Catalogo.Rows.Add(Consulta.Id, Consulta.Nombre);
            }
            return Catalogo;
        }

        public DataTable ConsultasFuncCargarMantenimiento(int Id, out string Nombre)
        {
            ClsConsultaGuardada Consulta = ConsultasFuncObtenerGuardada(Id);
            ClsDefinicionConsulta Definicion = Consulta.Definicion;
            if (Definicion.Limite.HasValue || Definicion.Desplazamiento != 0)
            {
                throw new ArgumentException("La consulta tiene límites que Mantenimiento no puede representar. No puede editarse como filtros.");
            }
            DataTable Filas = new DataTable();
            foreach (string Columna in new[] { "Campo", "Operador", "Valor", "Orden", "Conector" })
            {
                Filas.Columns.Add(Columna);
            }
            foreach (ClsCondicion Condicion in Definicion.Condiciones)
            {
                Filas.Rows.Add(Condicion.Campo, Condicion.Operador, Condicion.Valor, Condicion.Orden, Condicion.Conector);
            }
            Nombre = Consulta.Nombre;
            return Filas;
        }

        public void ConsultasProcEliminarGuardada(int Id)
        {
            _Compartidas.ConsultasProcCargarCampos();
            if (Id <= 0)
            {
                throw new ArgumentException("Seleccione una consulta guardada.");
            }
            _Guardadas.ConsultasProcEliminar(Id, _Compartidas.Tabla);
        }

        internal ClsDefinicionConsulta ConsultasFuncDefinicionTemporal(DataTable Filas, bool Antigua = false)
        {
            _Compartidas.ConsultasProcCargarCampos();
            if (Filas == null || Filas.Rows.Count > 100) throw new ArgumentException("Se permiten hasta 100 condiciones.");
            ClsDefinicionConsulta Definicion = new ClsDefinicionConsulta { Tabla = _Compartidas.Tabla };
            foreach (DataRow Fila in Filas.Rows)
            {
                Definicion.Condiciones.Add(_Compartidas.Validador.ConsultasFuncValidarCondicion(Convert.ToString(Fila["Campo"]), Convert.ToString(Fila["Operador"]), Convert.ToString(Fila["Valor"]), Convert.ToString(Fila["Orden"]), Convert.ToString(Fila["Conector"]), Antigua));
            }
            ClsValidadorConsultas.ConsultasProcNormalizarConectores(Definicion);
            return Definicion;
        }

        public void ConsultasProcValidarGuardado(string Nombre, DataTable Filas, int Id = 0)
        {
            ConsultasFuncPrepararGuardado(Nombre, Filas, Id);
        }

        private ClsConsultaGuardada ConsultasFuncPrepararGuardado(string Nombre, DataTable Filas, int Id)
        {
            Nombre = (Nombre ?? "").Trim();
            if (Nombre.Length == 0 || Nombre.Length > 50) throw new ClsErrorValidacion("Nombre", "El nombre debe tener entre 1 y 50 caracteres.");
            if (Filas == null || Filas.Rows.Count == 0) throw new ArgumentException("Agregue entre 1 y 100 condiciones u ordenamientos.");
            ClsDefinicionConsulta Definicion = ConsultasFuncDefinicionTemporal(Filas, Id > 0);
            if (Id < 0) throw new ArgumentException("Identificador de edición inválido.");
            if (Id > 0) _Guardadas.ConsultasFuncObtener(Id, _Compartidas.Tabla);
            if (_Guardadas.ConsultasFuncExisteNombre(Nombre, Id)) throw new ClsErrorValidacion("Nombre", "Ya existe una consulta con ese nombre.");
            return new ClsConsultaGuardada { Id = Id, Nombre = Nombre, Tabla = _Compartidas.Tabla, Definicion = Definicion };
        }

        public int ConsultasFuncGuardar(string Nombre, DataTable Filas, int Id = 0)
        {
            ClsConsultaGuardada Consulta = ConsultasFuncPrepararGuardado(Nombre, Filas, Id);
            try
            {
                if (Id > 0) _Guardadas.ConsultasProcActualizar(Consulta);
                else _Guardadas.ConsultasProcGuardar(Consulta);
            }
            catch (InvalidOperationException Error)
            {
                if (Error.Message == "Ya existe una consulta con ese nombre.") throw new ClsErrorValidacion("Nombre", Error.Message);
                throw;
            }
            return Consulta.Id;
        }

        public void ConsultasProcGuardar(string Nombre, DataTable Filas)
        {
            ConsultasFuncGuardar(Nombre, Filas);
        }

        internal ClsDefinicionConsulta ConsultasFuncObtenerDefinicion(int Id)
        {
            return ConsultasFuncObtenerGuardada(Id).Definicion;
        }

        private ClsConsultaGuardada ConsultasFuncObtenerGuardada(int Id)
        {
            _Compartidas.ConsultasProcCargarCampos();
            if (Id <= 0)
            {
                throw new ArgumentException("Seleccione una consulta guardada.");
            }
            ClsConsultaGuardada Consulta = _Guardadas.ConsultasFuncObtener(Id, _Compartidas.Tabla);
            _Compartidas.Validador.ConsultasProcValidarDefinicion(Consulta.Definicion, true);
            return Consulta;
        }
    }
}
/*Fin de código de Diana Mishel Loeiza Ramirez 9959-23-3457 el 6/10/2026*/
