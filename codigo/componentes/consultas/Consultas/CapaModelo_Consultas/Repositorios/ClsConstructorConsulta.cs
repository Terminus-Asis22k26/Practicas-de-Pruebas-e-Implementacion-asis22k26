using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaModelo_Consultas.Entidades;

namespace CapaModelo_Consultas.Repositorios
{
    internal static class ClsConstructorConsulta
    {
        /*Inicio de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
        internal static ClsConsultaPreparada ConsultasFuncConstruir(ClsDefinicionConsulta Definicion, IList<ClsCampoConsulta> Campos, string CampoOrden, bool Descendente)
        {
            if (Definicion == null || Definicion.Condiciones == null || Definicion.Condiciones.Count > 100 || Definicion.Desplazamiento < 0 || Definicion.Limite < 0)
            {
                throw new ArgumentException("La definición de consulta no es válida.");
            }
            ClsConsultaPreparada Consulta = new ClsConsultaPreparada();
            StringBuilder Texto = new StringBuilder("SELECT * FROM " + ClsRepositorio.ConsultasFuncIdentificador(Definicion.Tabla));
            List<string> Ordenes = new List<string>();
            HashSet<string> Ordenados = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            bool TieneFiltro = false;
            foreach (ClsCondicion Condicion in Definicion.Condiciones)
            {
                if (Condicion == null)
                {
                    throw new ArgumentException("La definición contiene una condición vacía.");
                }
                string Campo = ConsultasFuncCampo(Condicion.Campo, Campos);
                string Operador = Condicion.Operador ?? "";
                string Orden = Condicion.Orden ?? "";
                if (Orden != "" && Orden != "ASC" && Orden != "DESC")
                {
                    throw new ArgumentException("Ordenamiento no permitido.");
                }
                if (Orden != "" && Ordenados.Add(Condicion.Campo)) Ordenes.Add(Campo + " " + Orden);
                if (Operador == "")
                {
                    if (Orden == "") throw new ArgumentException("La condición está vacía.");
                    continue;
                }
                if (TieneFiltro)
                {
                    if (Condicion.Conector != "AND" && Condicion.Conector != "OR") throw new ArgumentException("Conector no permitido.");
                    Texto.Append(" " + Condicion.Conector + " ");
                }
                else Texto.Append(" WHERE ");
                TieneFiltro = true;
                Texto.Append(Campo);
                if (Operador == "IS NULL" || Operador == "IS NOT NULL")
                {
                    Texto.Append(" " + Operador);
                    continue;
                }
                object Valor = Condicion.ValorTipado ?? Condicion.Valor;
                if (Operador == "Contiene" || Operador == "Comienza con" || Operador == "Termina con")
                {
                    string Patron = Convert.ToString(Valor).Replace("!", "!!").Replace("%", "!%").Replace("_", "!_");
                    if (Operador != "Comienza con") Patron = "%" + Patron;
                    if (Operador != "Termina con") Patron += "%";
                    Texto.Append(" LIKE ? ESCAPE '!'");
                    Consulta.Valores.Add(Patron);
                }
                else
                {
                    if (!new[] { "=", "<>", ">", "<", ">=", "<=", "LIKE" }.Contains(Operador)) throw new ArgumentException("Operador no permitido.");
                    Texto.Append(" " + Operador + " ?");
                    if (Operador == "LIKE") Texto.Append(" ESCAPE '!'");
                    Consulta.Valores.Add(Valor);
                }
            }
            foreach (ClsCampoConsulta Campo in Campos.Where(Campo => Campo.EsPrimario).Concat(Campos))
            {
                if (Ordenados.Add(Campo.Nombre)) Ordenes.Add(ConsultasFuncCampo(Campo.Nombre, Campos) + " ASC");
            }
            string OrdenBase = string.Join(", ", Ordenes);
            Texto.Append(" ORDER BY " + OrdenBase);
            if (Definicion.Limite.HasValue)
            {
                Texto.Append(" LIMIT ? OFFSET ?");
                Consulta.Valores.Add(Definicion.Limite.Value);
                Consulta.Valores.Add(Definicion.Desplazamiento);
            }
            Consulta.Texto = Texto.ToString();
            Consulta.Orden = string.IsNullOrEmpty(CampoOrden) ? OrdenBase : ConsultasFuncCampo(CampoOrden, Campos) + (Descendente ? " DESC, " : " ASC, ") + OrdenBase;
            return Consulta;
        }

        private static string ConsultasFuncCampo(string Nombre, IList<ClsCampoConsulta> Campos)
        {
            ClsCampoConsulta Campo = Campos.FirstOrDefault(Actual => string.Equals(Actual.Nombre, Nombre, StringComparison.OrdinalIgnoreCase));
            if (Campo == null) throw new ArgumentException("El campo no pertenece a la tabla consultada.");
            return ClsRepositorio.ConsultasFuncIdentificador(Campo.Nombre);
        }
    }
    /* fin de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
}
