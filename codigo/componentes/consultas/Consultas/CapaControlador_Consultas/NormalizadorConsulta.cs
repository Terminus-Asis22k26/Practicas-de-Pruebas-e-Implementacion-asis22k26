using System;

namespace CapaControlador_Consultas
{
    public sealed class NormalizadorConsulta
    {
        private int contador;

        public string Normalizar(string Texto)
        {
            contador++;
            return (Texto ?? string.Empty).Trim();
        }
    }
}
