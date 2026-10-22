using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using CapaModelo_Consultas.Entidades;
/*Inicio de código de Diana Mishel Loeiza Ramirez 9959-23-3457 el 6/10/2026*/
namespace CapaModelo_Consultas.Repositorios
{
    internal sealed class ClsLectorConsultaAntigua
    {
        private readonly List<string> _Tokens = new List<string>();
        private int _Posicion;

        internal ClsLectorConsultaAntigua(string Texto)
        {
            Regex Patron = new Regex(@"\G\s*(`[^`]+`|'(?:''|\\.|[^'\\])*'|[A-Za-z_][A-Za-z0-9_]*|[+-]?(?:\d+(?:\.\d*)?|\.\d+)(?:[eE][+-]?\d+)?|<>|!=|>=|<=|[=<>*,;])", RegexOptions.CultureInvariant);
            int Posicion = 0;
            while (Posicion < Texto.Length && !string.IsNullOrWhiteSpace(Texto.Substring(Posicion)))
            {
                Match Coincidencia = Patron.Match(Texto, Posicion);
                if (!Coincidencia.Success) throw new ArgumentException("La consulta antigua contiene una expresión no compatible. No puede editarse como filtros; la definición se conserva.");
                _Tokens.Add(Coincidencia.Groups[1].Value);
                Posicion += Coincidencia.Length;
            }
        }

        internal ClsDefinicionConsulta ConsultasFuncLeer()
        {
            ConsultasProcExigir("SELECT");
            ConsultasProcExigir("*");
            ConsultasProcExigir("FROM");
            ClsDefinicionConsulta Definicion = new ClsDefinicionConsulta { Tabla = ConsultasFuncIdentificador() };
            if (ConsultasFuncAceptar("WHERE"))
            {
                string Conector = "";
                do
                {
                    ClsCondicion Condicion = new ClsCondicion { Campo = ConsultasFuncIdentificador(), Conector = Conector, Orden = "" };
                    if (ConsultasFuncAceptar("IS"))
                    {
                        bool Negado = ConsultasFuncAceptar("NOT");
                        ConsultasProcExigir("NULL");
                        Condicion.Operador = Negado ? "IS NOT NULL" : "IS NULL";
                        Condicion.Valor = "";
                    }
                    else
                    {
                        Condicion.Operador = ConsultasFuncSiguiente().ToUpperInvariant();
                        if (Condicion.Operador == "!=") Condicion.Operador = "<>";
                        if (!new[] { "=", "<>", ">", "<", ">=", "<=", "LIKE" }.Contains(Condicion.Operador)) throw new ArgumentException("Operador antiguo no compatible.");
                        Condicion.Valor = ConsultasFuncLiteral();
                        if (Condicion.Operador == "LIKE")
                        {
                            string Escape = "\\";
                            if (ConsultasFuncAceptar("ESCAPE")) Escape = ConsultasFuncLiteral();
                            if (Escape.Length != 1) throw new ArgumentException("Escape de patrón no compatible.");
                            Condicion.Valor = ConsultasFuncPatron(Condicion.Valor, Escape[0]);
                        }
                    }
                    Definicion.Condiciones.Add(Condicion);
                    if (ConsultasFuncAceptar("AND")) Conector = "AND";
                    else if (ConsultasFuncAceptar("OR")) Conector = "OR";
                    else break;
                }
                while (true);
            }
            if (ConsultasFuncAceptar("ORDER"))
            {
                ConsultasProcExigir("BY");
                do
                {
                    string Campo = ConsultasFuncIdentificador();
                    string Orden = ConsultasFuncAceptar("DESC") ? "DESC" : "ASC";
                    if (Orden == "ASC") ConsultasFuncAceptar("ASC");
                    Definicion.Condiciones.Add(new ClsCondicion { Campo = Campo, Orden = Orden, Operador = "", Conector = "", Valor = "" });
                }
                while (ConsultasFuncAceptar(","));
            }
            if (ConsultasFuncAceptar("LIMIT"))
            {
                Definicion.Limite = ConsultasFuncEntero();
                if (ConsultasFuncAceptar(","))
                {
                    Definicion.Desplazamiento = Definicion.Limite.Value;
                    Definicion.Limite = ConsultasFuncEntero();
                }
                else if (ConsultasFuncAceptar("OFFSET")) Definicion.Desplazamiento = ConsultasFuncEntero();
            }
            ConsultasFuncAceptar(";");
            if (_Posicion != _Tokens.Count) throw new ArgumentException("Solo se permiten definiciones de lectura sobre una tabla, con condiciones y ordenamiento.");
            return Definicion;
        }

        private static string ConsultasFuncPatron(string Valor, char Escape)
        {
            string Resultado = "";
            for (int Indice = 0; Indice < Valor.Length; Indice++)
            {
                char Caracter = Valor[Indice];
                if (Caracter == Escape)
                {
                    if (++Indice == Valor.Length) throw new ArgumentException("Patrón de texto incompleto.");
                    Caracter = Valor[Indice];
                    if (Caracter == '%' || Caracter == '_' || Caracter == '!') Resultado += "!";
                }
                else if (Caracter == '!') Resultado += "!";
                Resultado += Caracter;
            }
            return Resultado;
        }

        private string ConsultasFuncLiteral()
        {
            string Token = ConsultasFuncSiguiente();
            if (Token.StartsWith("'", StringComparison.Ordinal))
            {
                string Valor = Token.Substring(1, Token.Length - 2).Replace("''", "'");
                return Regex.Replace(Valor, @"\\(.)", Coincidencia =>
                {
                    string Caracter = Coincidencia.Groups[1].Value;
                    if (Caracter == "n") return "\n";
                    if (Caracter == "r") return "\r";
                    if (Caracter == "t") return "\t";
                    if (Caracter == "%" || Caracter == "_") return "\\" + Caracter;
                    return Caracter;
                });
            }
            if (!Regex.IsMatch(Token, @"\A[+-]?(?:\d+(?:\.\d*)?|\.\d+)(?:[eE][+-]?\d+)?\z")) throw new ArgumentException("La consulta antigua requiere valores literales.");
            return Token;
        }

        private int ConsultasFuncEntero()
        {
            int Numero;
            if (!int.TryParse(ConsultasFuncSiguiente(), NumberStyles.None, CultureInfo.InvariantCulture, out Numero)) throw new ArgumentException("Límite de consulta inválido.");
            return Numero;
        }

        private string ConsultasFuncIdentificador()
        {
            string Nombre = ConsultasFuncSiguiente().Trim('`');
            ClsRepositorio.ConsultasFuncIdentificador(Nombre);
            return Nombre;
        }

        private bool ConsultasFuncAceptar(string Token)
        {
            if (_Posicion >= _Tokens.Count || !string.Equals(_Tokens[_Posicion], Token, StringComparison.OrdinalIgnoreCase)) return false;
            _Posicion++;
            return true;
        }

        private void ConsultasProcExigir(string Token)
        {
            if (!ConsultasFuncAceptar(Token)) throw new ArgumentException("Formato de consulta antigua no compatible. No puede editarse como filtros; la definición se conserva.");
        }

        private string ConsultasFuncSiguiente()
        {
            if (_Posicion >= _Tokens.Count) throw new ArgumentException("La consulta guardada está incompleta.");
            return _Tokens[_Posicion++];
        }
    }
}
/*Fin de código de Diana Mishel Loeiza Ramirez 9959-23-3457 el 6/10/2026*/
