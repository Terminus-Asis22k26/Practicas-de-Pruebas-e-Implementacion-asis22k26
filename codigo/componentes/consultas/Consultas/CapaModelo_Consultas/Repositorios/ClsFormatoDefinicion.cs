using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using CapaModelo_Consultas.Entidades;
/*Inicio de código de Diana Mishel Loeiza Ramirez 9959-23-3457 el 6/10/2026*/

namespace CapaModelo_Consultas.Repositorios
{
    internal static class ClsFormatoDefinicion
    {
        internal static string ConsultasFuncSerializar(ClsDefinicionConsulta Definicion)
        {
            XElement Raiz = new XElement("ConsultaTerminus", new XAttribute("Version", "1"), new XAttribute("Tabla", Definicion.Tabla));
            if (Definicion.Limite.HasValue) Raiz.Add(new XAttribute("Limite", Definicion.Limite.Value), new XAttribute("Desplazamiento", Definicion.Desplazamiento));
            foreach (ClsCondicion Condicion in Definicion.Condiciones)
            {
                Raiz.Add(new XElement("Condicion", new XAttribute("Campo", Condicion.Campo), new XAttribute("Operador", Condicion.Operador ?? ""), new XAttribute("Orden", Condicion.Orden ?? ""), new XAttribute("Conector", Condicion.Conector ?? ""), Condicion.Valor ?? ""));
            }
            return Raiz.ToString(SaveOptions.DisableFormatting);
        }

        internal static ClsDefinicionConsulta ConsultasFuncLeer(string Texto, string Tabla)
        {
            if (string.IsNullOrWhiteSpace(Texto) || Texto.Length > 65535) throw new ArgumentException("La definición guardada está vacía o excede el tamaño permitido.");
            ClsDefinicionConsulta Definicion;
            if (Texto.TrimStart().StartsWith("<", StringComparison.Ordinal))
            {
                XmlReaderSettings Opciones = new XmlReaderSettings { DtdProcessing = DtdProcessing.Prohibit, XmlResolver = null, MaxCharactersInDocument = 65535 };
                using (StringReader Entrada = new StringReader(Texto))
                using (XmlReader Lector = XmlReader.Create(Entrada, Opciones))
                {
                    XElement Raiz = XElement.Load(Lector);
                    if (Raiz.Name != "ConsultaTerminus" || (string)Raiz.Attribute("Version") != "1") throw new ArgumentException("Formato de consulta no reconocido.");
                    Definicion = new ClsDefinicionConsulta { Tabla = (string)Raiz.Attribute("Tabla"), Limite = (int?)Raiz.Attribute("Limite"), Desplazamiento = (int?)Raiz.Attribute("Desplazamiento") ?? 0 };
                    foreach (XElement Elemento in Raiz.Elements())
                    {
                        if (Elemento.Name != "Condicion" || Elemento.HasElements) throw new ArgumentException("La definición contiene elementos no admitidos.");
                        Definicion.Condiciones.Add(new ClsCondicion { Campo = (string)Elemento.Attribute("Campo"), Operador = (string)Elemento.Attribute("Operador"), Orden = (string)Elemento.Attribute("Orden"), Conector = (string)Elemento.Attribute("Conector"), Valor = Elemento.Value });
                    }
                }
            }
            else
            {
                try
                {
                    Definicion = new ClsLectorConsultaAntigua(Texto).ConsultasFuncLeer();
                }
                catch (ArgumentException Excepcion)
                {
                    throw new ArgumentException("La consulta SQL no puede editarse como filtros. La definición se conserva. " + Excepcion.Message, Excepcion);
                }
            }
            if (!string.Equals(Definicion.Tabla, Tabla, StringComparison.Ordinal)) throw new ArgumentException("La consulta guardada no pertenece a la tabla autorizada.");
            return Definicion;
        }
    }
}
/*Fin de código de Diana Mishel Loeiza Ramirez 9959-23-3457 el 6/10/2026*/
