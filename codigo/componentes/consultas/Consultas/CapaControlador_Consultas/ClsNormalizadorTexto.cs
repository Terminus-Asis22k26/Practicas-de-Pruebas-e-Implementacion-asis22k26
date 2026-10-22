using System;

namespace CapaControlador_Consultas
{
    /*Inicio de código de Gabriel André Guillén Pocón 0901-23-1998 el 21/10/2026*/
    public sealed class ClsNormalizadorTexto
    {
        // Longitud permitida
        private readonly int _LongitudMaxima;

        // Constructor
        public ClsNormalizadorTexto(int LongitudMaxima)
        {
            _LongitudMaxima = LongitudMaxima;
        }

        // Normaliza un texto
        public string ConsultasFuncNormalizar(string Texto)
        {
            if (string.IsNullOrWhiteSpace(Texto))
            {
                return string.Empty;
            }
            string Limpio = Texto.Trim();
            return Limpio.Length > _LongitudMaxima ? Limpio.Substring(0, _LongitudMaxima) : Limpio;
        }
    }
    /* fin de código de Gabriel André Guillén Pocón 0901-23-1998 el 21/10/2026*/
}
