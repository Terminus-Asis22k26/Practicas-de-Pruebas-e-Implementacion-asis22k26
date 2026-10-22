using System.ComponentModel;

namespace CapaVista_Consultas
{
    //Inicio Diego Fernando Santizo Samayoa 0901-22-15950 05/10/2026
    public sealed class ClsConvertidorCampoRetornoConsultas : ClsConvertidorTablaConsultas
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext Contexto)
        {
            Consultas Boton = Contexto?.Instance as Consultas;
            return new StandardValuesCollection(Metadatos.ConsultasFuncObtenerCampos(Boton?.Tabla));
        }
    }
    //Fin Diego Fernando Santizo Samayoa 0901-22-15950 05/10/2026
}
