using System.Collections.Generic;

namespace CapaModelo_Consultas.Repositorios
{
    /*Inicio de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
    internal sealed class ClsConsultaPreparada
    {
        internal string Texto { get; set; }
        internal string Orden { get; set; }
        internal List<object> Valores { get; } = new List<object>();
    }
    /* fin de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
}
