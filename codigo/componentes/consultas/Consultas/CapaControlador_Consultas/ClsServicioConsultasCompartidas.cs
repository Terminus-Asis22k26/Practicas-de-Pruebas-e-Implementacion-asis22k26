using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using CapaModelo_Consultas.Contratos;
using CapaModelo_Consultas.Entidades;

namespace CapaControlador_Consultas
{
    /*Inicio de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
    internal sealed class ClsServicioConsultasCompartidas : IContextoConsulta
    {
        private readonly IRepositorioMetadatos _Metadatos;
        private readonly IRepositorioEjecucionConsultas _Ejecucion;
        private string[] _Tablas = new string[0];
        private IList<ClsCampoConsulta> _Campos;
        private bool _EsVista;
        private ClsDefinicionConsulta _Definicion;
        internal ClsValidadorConsultas Validador { get; }
        internal ClsDefinicionConsulta Definicion { get { return _Definicion; } set { _Definicion = value; } }
        internal int IdConsultaCargada { get; set; }
        public string Tabla { get; private set; }
        public string CampoRetorno { get; private set; }

        internal ClsServicioConsultasCompartidas(IRepositorioMetadatos Metadatos, IRepositorioEjecucionConsultas Ejecucion)
        {
            _Metadatos = Metadatos ?? throw new ArgumentNullException(nameof(Metadatos));
            _Ejecucion = Ejecucion ?? throw new ArgumentNullException(nameof(Ejecucion));
            Validador = new ClsValidadorConsultas(ConsultasFuncCampo, ConsultasFuncObtenerOperadores, () => Tabla);
        }

        public void ConsultasProcConfigurar(string[] Tablas, string CampoId)
        {
            if (Tablas == null || Tablas.Length == 0)
            {
                throw new ArgumentException("Proporcione al menos una tabla o vista autorizada.");
            }
            foreach (string Nombre in Tablas)
            {
                ConsultasProcValidarIdentificador(Nombre);
            }
            ConsultasProcValidarIdentificador(CampoId);
            _Tablas = Tablas.Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
            Tabla = _Tablas[0];
            CampoRetorno = CampoId;
            _Campos = null;
            _Definicion = new ClsDefinicionConsulta { Tabla = Tabla };
            IdConsultaCargada = 0;
        }

        public void ConsultasProcValidarConfiguracion(string[] Tablas, string CampoId)
        {
            ConsultasProcConfigurar(Tablas, CampoId);
            IList<string> Permitidas = _Metadatos.ConsultasFuncObtenerTablas();
            foreach (string Nombre in _Tablas)
            {
                if (!Permitidas.Contains(Nombre, StringComparer.OrdinalIgnoreCase)) throw new ArgumentException("La tabla o vista no existe entre los orígenes permitidos.");
            }
            ConsultasProcCargarCampos();
        }

        public void ConsultasProcCambiarTabla(string Nombre)
        {
            if (!_Tablas.Contains(Nombre, StringComparer.OrdinalIgnoreCase))
            {
                throw new ArgumentException("La tabla o vista no pertenece al contexto autorizado.");
            }
            Tabla = _Tablas.First(Actual => string.Equals(Actual, Nombre, StringComparison.OrdinalIgnoreCase));
            _Campos = null;
            _Definicion = new ClsDefinicionConsulta { Tabla = Tabla };
            IdConsultaCargada = 0;
        }

        public string[] ConsultasFuncObtenerCampos()
        {
            ConsultasProcCargarCampos();
            return _Campos.Select(Campo => Campo.Nombre).ToArray();
        }

        internal void ConsultasProcCargarCampos()
        {
            if (_Definicion == null)
            {
                throw new InvalidOperationException("Configure la tabla o vista y el campo de retorno antes de consultar.");
            }
            if (_Campos == null)
            {
                IList<ClsCampoConsulta> Campos = _Metadatos.ConsultasFuncObtenerCampos(Tabla);
                if (!Campos.Any(Campo => string.Equals(Campo.Nombre, CampoRetorno, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new ArgumentException("El campo de retorno no existe en la tabla o vista.");
                }
                _EsVista = _Metadatos.ConsultasFuncEsVista(Tabla);
                _Campos = Campos;
            }
        }

        private ClsCampoConsulta ConsultasFuncCampo(string Nombre)
        {
            ConsultasProcCargarCampos();
            ClsCampoConsulta Campo = _Campos.FirstOrDefault(Actual => string.Equals(Actual.Nombre, Nombre, StringComparison.OrdinalIgnoreCase));
            if (Campo == null)
            {
                throw new ArgumentException("Seleccione un campo de la tabla o vista autorizada.");
            }
            return Campo;
        }

        public string[] ConsultasFuncObtenerOperadores(string Nombre)
        {
            string Tipo = ConsultasFuncCampo(Nombre).Tipo.ToLowerInvariant();
            List<string> Operadores = new List<string> { "=", "<>" };
            if (ClsValidadorConsultas.ConsultasFuncEsTexto(Tipo))
            {
                Operadores.AddRange(new[] { "Contiene", "Comienza con", "Termina con" });
            }
            else if (Tipo != "bool" && Tipo != "boolean" && Tipo != "bit")
            {
                Operadores.AddRange(new[] { ">", "<", ">=", "<=" });
            }
            return Operadores.ToArray();
        }

        public void ConsultasProcLimpiarFiltro()
        {
            ConsultasProcCargarCampos();
            _Definicion = new ClsDefinicionConsulta { Tabla = Tabla };
            IdConsultaCargada = 0;
        }

        public ClsPaginaConsulta ConsultasFuncEjecutar(int Pagina, int RegistrosPorPagina, string CampoOrden, bool Descendente)
        {
            ConsultasProcCargarCampos();
            if (Pagina < 1 || RegistrosPorPagina < 1 || RegistrosPorPagina > 500)
            {
                throw new ArgumentException("La paginación no es válida.");
            }
            if (!string.IsNullOrEmpty(CampoOrden))
            {
                ConsultasFuncCampo(CampoOrden);
            }
            ClsResultadoPaginado Resultado = _Ejecucion.ConsultasFuncEjecutar(_Definicion, Pagina, RegistrosPorPagina, CampoOrden, Descendente);
            if (!Resultado.Datos.Columns.Contains(CampoRetorno))
            {
                throw new InvalidOperationException("El resultado no contiene el campo de retorno.");
            }
            return new ClsPaginaConsulta { Datos = Resultado.Datos, TotalRegistros = Resultado.TotalRegistros, Pagina = Resultado.Pagina, RegistrosPorPagina = Resultado.RegistrosPorPagina };
        }

        public object ConsultasFuncSeleccionar(DataRow Registro)
        {
            if (Registro == null || !Registro.Table.Columns.Contains(CampoRetorno))
            {
                throw new ArgumentException("Seleccione un registro que contenga el campo de retorno.");
            }
            if (Registro.IsNull(CampoRetorno))
            {
                throw new ArgumentException("El campo de retorno del registro seleccionado es nulo.");
            }
            return Registro[CampoRetorno];
        }

        public string ConsultasFuncObtenerPk(DataRow Registro)
        {
            ConsultasProcCargarCampos();
            if (_EsVista) return null;
            ClsCampoConsulta[] Primarios = _Campos.Where(Campo => Campo.EsPrimario).ToArray();
            if (Primarios.Length == 0)
            {
                throw new ArgumentException("La tabla seleccionada no tiene una llave primaria. No se puede confirmar la selección.");
            }
            if (Primarios.Length != 1)
            {
                throw new ArgumentException("La tabla seleccionada tiene una llave primaria compuesta. Solo se admiten llaves primarias de una columna.");
            }
            string Nombre = Primarios[0].Nombre;
            if (Registro == null || !Registro.Table.Columns.Contains(Nombre))
            {
                throw new ArgumentException("El registro seleccionado no contiene la columna de llave primaria.");
            }
            object Valor = Registro[Nombre];
            if (Valor == null || Valor == DBNull.Value)
            {
                throw new ArgumentException("La llave primaria del registro seleccionado es nula.");
            }
            return Convert.ToString(Valor, CultureInfo.InvariantCulture);
        }

        public string ConsultasFuncMensajeSinResultados(string NombreCampo)
        {
            string Tipo = ConsultasFuncCampo(NombreCampo).Tipo.ToLowerInvariant();
            if (Tipo == "date") return "Sin resultados. Verifique el campo y el operador. Use aaaa-MM-dd.";
            if (Tipo == "datetime" || Tipo == "timestamp") return "Sin resultados. Verifique el campo y el operador. Use aaaa-MM-dd HH:mm:ss.";
            return "Sin resultados. Verifique el campo, el operador y el formato del valor.";
        }

        private static void ConsultasProcValidarIdentificador(string Nombre)
        {
            if (string.IsNullOrWhiteSpace(Nombre) || !Regex.IsMatch(Nombre, @"\A[A-Za-z_][A-Za-z0-9_]*\z"))
            {
                throw new ArgumentException("La tabla o el campo solicitado no es un identificador válido.");
            }
        }
    }

    /* fin de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
}
