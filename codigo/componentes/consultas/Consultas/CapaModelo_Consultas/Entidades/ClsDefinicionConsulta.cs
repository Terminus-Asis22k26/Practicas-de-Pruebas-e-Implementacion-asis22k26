using System.Collections.Generic;

namespace CapaModelo_Consultas.Entidades
{
    /*Inicio de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
    public sealed class ClsDefinicionConsulta
    {
        public string Tabla { get; set; }
        public List<ClsCondicion> Condiciones { get; set; } = new List<ClsCondicion>();
        public int? Limite { get; set; }
        public int Desplazamiento { get; set; }
    }
    /* fin de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
}
