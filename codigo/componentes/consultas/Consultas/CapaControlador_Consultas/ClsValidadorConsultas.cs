using System;
using System.Globalization;
using System.Linq;
using CapaModelo_Consultas.Entidades;

namespace CapaControlador_Consultas
{
    /*Inicio de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
    internal sealed class ClsValidadorConsultas
    {
        private readonly Func<string, ClsCampoConsulta> _Campo;
        private readonly Func<string, string[]> _Operadores;
        private readonly Func<string> _Tabla;

        internal ClsValidadorConsultas(Func<string, ClsCampoConsulta> Campo, Func<string, string[]> Operadores, Func<string> Tabla)
        {
            _Campo = Campo;
            _Operadores = Operadores;
            _Tabla = Tabla;
        }

        internal void ConsultasProcValidarDefinicion(ClsDefinicionConsulta Definicion, bool Antigua)
        {
            if (Definicion == null || !string.Equals(Definicion.Tabla, _Tabla(), StringComparison.OrdinalIgnoreCase) || Definicion.Condiciones == null || Definicion.Condiciones.Count > 100 || Definicion.Limite < 0 || Definicion.Desplazamiento < 0)
            {
                throw new ArgumentException("La definición no pertenece al contexto o no es válida.");
            }
            if (Definicion.Condiciones.Any(Condicion => Condicion == null))
            {
                throw new ArgumentException("La definición contiene una condición vacía.");
            }
            Definicion.Condiciones = Definicion.Condiciones.Select(Condicion => ConsultasFuncValidarCondicion(Condicion.Campo, Condicion.Operador, Condicion.Valor, Condicion.Orden, Condicion.Conector, Antigua)).ToList();
            ConsultasProcNormalizarConectores(Definicion);
        }

        internal static void ConsultasProcNormalizarConectores(ClsDefinicionConsulta Definicion)
        {
            bool TieneFiltro = false;
            foreach (ClsCondicion Condicion in Definicion.Condiciones)
            {
                if (string.IsNullOrEmpty(Condicion.Operador))
                {
                    Condicion.Conector = "";
                    continue;
                }
                if (!TieneFiltro)
                {
                    Condicion.Conector = "";
                }
                else if (Condicion.Conector != "AND" && Condicion.Conector != "OR")
                {
                    throw new ArgumentException("Seleccione AND u OR para cada filtro posterior.");
                }
                TieneFiltro = true;
            }
        }

        internal ClsCondicion ConsultasFuncValidarCondicion(string Nombre, string Operador, string Valor, string Orden, string Conector, bool Antigua)
        {
            ClsCampoConsulta Campo = _Campo(Nombre);
            Operador = Operador ?? "";
            if (Operador == "Empieza con")
            {
                Operador = "Comienza con";
            }
            Orden = Orden ?? "";
            Conector = Conector ?? "";
            if (Orden != "" && Orden != "ASC" && Orden != "DESC")
            {
                throw new ArgumentException("Seleccione un orden válido.");
            }
            if (Conector != "" && Conector != "AND" && Conector != "OR")
            {
                throw new ArgumentException("Seleccione AND u OR.");
            }
            if (Operador == "" && Orden == "")
            {
                throw new ArgumentException("Seleccione un operador o un ordenamiento.");
            }
            if (Operador != "" && !_Operadores(Nombre).Contains(Operador) && !(Antigua && (Operador == "IS NULL" || Operador == "IS NOT NULL" || (Operador == "LIKE" && ConsultasFuncEsTexto(Campo.Tipo)))))
            {
                throw new ArgumentException("El operador no es compatible con el tipo de campo.");
            }
            ClsCondicion Condicion = new ClsCondicion { Campo = Campo.Nombre, Operador = Operador, Valor = Valor ?? "", Orden = Orden, Conector = Conector };
            if (Operador == "" || Operador == "IS NULL" || Operador == "IS NOT NULL")
            {
                Condicion.Valor = "";
                return Condicion;
            }
            if (string.IsNullOrWhiteSpace(Valor) && !Antigua)
            {
                throw new ClsErrorValidacion("Valor", "Ingrese un valor para el filtro.");
            }
            Condicion.ValorTipado = ConsultasFuncConvertirValor(Campo, Valor);
            return Condicion;
        }

        private static object ConsultasFuncConvertirValor(ClsCampoConsulta Campo, string Valor)
        {
            string Tipo = Campo.Tipo.ToLowerInvariant();
            if (ConsultasFuncEsTexto(Tipo))
            {
                if (Campo.Longitud > 0 && Valor.Length > Campo.Longitud)
                {
                    throw new ClsErrorValidacion("Valor", "El valor supera la longitud del campo.");
                }
                return Valor;
            }
            if (Tipo == "bool" || Tipo == "boolean" || Tipo == "bit")
            {
                bool Booleano;
                if (Valor == "1")
                {
                    return true;
                }
                if (Valor == "0")
                {
                    return false;
                }
                if (bool.TryParse(Valor, out Booleano))
                {
                    return Booleano;
                }
            }
            else if (Tipo.Contains("int") || Tipo == "year")
            {
                long Entero;
                if (long.TryParse(Valor, NumberStyles.Integer, CultureInfo.InvariantCulture, out Entero))
                {
                    return Entero;
                }
            }
            else if (Tipo == "decimal" || Tipo == "numeric")
            {
                decimal Numero;
                if (decimal.TryParse(Valor, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out Numero))
                {
                    return Numero;
                }
            }
            else if (Tipo == "float" || Tipo == "double" || Tipo == "real")
            {
                double Numero;
                if (double.TryParse(Valor, NumberStyles.Float, CultureInfo.InvariantCulture, out Numero) && !double.IsNaN(Numero) && !double.IsInfinity(Numero))
                {
                    return Numero;
                }
            }
            else if (Tipo == "time")
            {
                TimeSpan Hora;
                if (TimeSpan.TryParseExact(Valor, @"hh\:mm\:ss", CultureInfo.InvariantCulture, out Hora))
                {
                    return Hora;
                }
            }
            else if (Tipo == "date" || Tipo == "datetime" || Tipo == "timestamp")
            {
                DateTime Fecha;
                string[] Formatos = Tipo == "date" ? new[] { "dd/MM/yyyy", "yyyy-MM-dd" } : new[] { "dd/MM/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss" };
                if (DateTime.TryParseExact(Valor, Formatos, CultureInfo.InvariantCulture, DateTimeStyles.None, out Fecha))
                {
                    return Fecha;
                }
            }
            else
            {
                throw new ArgumentException("El tipo de campo no admite filtros en este componente.");
            }
            if (Tipo.Contains("int") || Tipo == "year") throw new ClsErrorValidacion("Valor", "El valor debe ser numérico.");
            if (Tipo == "date") throw new ClsErrorValidacion("Valor", "Use el formato aaaa-MM-dd.");
            if (Tipo == "datetime" || Tipo == "timestamp") throw new ClsErrorValidacion("Valor", "Use el formato aaaa-MM-dd HH:mm:ss.");
            throw new ClsErrorValidacion("Valor", "El valor no es válido para el tipo " + Tipo + ". Use fechas DD/MM/AAAA, horas HH:mm:ss y punto decimal.");
        }

        internal static bool ConsultasFuncEsTexto(string Tipo)
        {
            return new[] { "char", "varchar", "tinytext", "text", "mediumtext", "longtext", "enum", "set" }.Contains(Tipo.ToLowerInvariant());
        }
    }
    /* fin de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
}
