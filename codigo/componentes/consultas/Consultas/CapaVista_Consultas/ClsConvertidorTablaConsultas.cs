using System.ComponentModel;
using CapaControlador_Consultas;

namespace CapaVista_Consultas
{
    //Inicio Diego Fernando Santizo Samayoa 0901-22-15950 05/10/2026
    public class ClsConvertidorTablaConsultas : StringConverter
    {
        private static readonly ClsMetadatosDisenadorConsultas _Metadatos = new ClsMetadatosDisenadorConsultas();
        protected static ClsMetadatosDisenadorConsultas Metadatos => _Metadatos;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext Contexto) { return true; }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext Contexto) { return false; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext Contexto)
        {
            return new StandardValuesCollection(Metadatos.ConsultasFuncObtenerTablasYVistas());
        }
    }
    //Fin Diego Fernando Santizo Samayoa 0901-22-15950 05/10/2026
}
