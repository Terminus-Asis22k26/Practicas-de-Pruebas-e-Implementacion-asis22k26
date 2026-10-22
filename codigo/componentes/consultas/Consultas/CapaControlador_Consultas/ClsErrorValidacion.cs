using System;

namespace CapaControlador_Consultas
{
    public sealed class ClsErrorValidacion : ArgumentException
    {
        /*Inicio de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
        public string Campo { get; }

        public ClsErrorValidacion(string Campo, string Mensaje) : base(Mensaje)
        {
            this.Campo = Campo;
        }
        /* fin de código de Miguel David Contreras Jacinto 0901-21-3878 el 8/10/2026*/
    }
}
