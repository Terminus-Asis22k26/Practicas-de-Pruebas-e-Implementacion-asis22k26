namespace CapaModelo_Reporteador.Entidades
{
    public class ClsAplicacionReporteador
    {
        public int IdAplicacion { get; set; }

        public string NombreAplicacion { get; set; }

        public string NombreAplicacionMostrar
        {
            get { return IdAplicacion + " - " + NombreAplicacion; }
        }
    }
}