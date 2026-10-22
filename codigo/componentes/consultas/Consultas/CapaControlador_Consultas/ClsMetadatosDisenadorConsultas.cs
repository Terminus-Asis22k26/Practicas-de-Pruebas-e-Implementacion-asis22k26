using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CapaModelo_Consultas.Contratos;
using CapaModelo_Consultas.Repositorios;

namespace CapaControlador_Consultas
{
    //Inicio Diego Fernando Santizo Samayoa 0901-22-15950 05/10/2026
    public sealed class ClsMetadatosDisenadorConsultas
    {
        private readonly IRepositorioMetadatos _Metadatos;
        private readonly Dictionary<string, Tuple<DateTime, Task<string[]>>> _Solicitudes = new Dictionary<string, Tuple<DateTime, Task<string[]>>>(StringComparer.Ordinal);

        public ClsMetadatosDisenadorConsultas() : this(new ClsRepositorioMetadatos(null, 3))
        {
        }

        public ClsMetadatosDisenadorConsultas(IRepositorioMetadatos Metadatos)
        {
            _Metadatos = Metadatos ?? throw new ArgumentNullException(nameof(Metadatos));
        }

        public string[] ConsultasFuncObtenerTablas()
        {
            return ConsultasFuncObtenerTablasYVistas();
        }

        public string[] ConsultasFuncObtenerTablasYVistas()
        {
            return ConsultasFuncOpciones("TablasYVistas", () => _Metadatos.ConsultasFuncObtenerTablas());
        }

        public string[] ConsultasFuncObtenerCampos(string Tabla)
        {
            if (string.IsNullOrWhiteSpace(Tabla)) return new string[0];
            return ConsultasFuncOpciones("Campos:" + Tabla, () => _Metadatos.ConsultasFuncObtenerCampos(Tabla).Select(Campo => Campo.Nombre));
        }

        private string[] ConsultasFuncOpciones(string Clave, Func<IEnumerable<string>> Leer)
        {
            Task<string[]> Solicitud;
            lock (_Solicitudes)
            {
                Tuple<DateTime, Task<string[]>> Entrada;
                if (!_Solicitudes.TryGetValue(Clave, out Entrada) || (Entrada.Item2.IsCompleted && DateTime.UtcNow - Entrada.Item1 > TimeSpan.FromSeconds(20)))
                {
                    Solicitud = Task.Run(() =>
                    {
                        try
                        {
                            return Leer().Where(Nombre => Nombre != null && Regex.IsMatch(Nombre, @"\A[A-Za-z_][A-Za-z0-9_]*\z")).Distinct(StringComparer.Ordinal).OrderBy(Nombre => Nombre, StringComparer.Ordinal).ToArray();
                        }
                        catch { return new string[0]; }
                    });
                    _Solicitudes[Clave] = Tuple.Create(DateTime.UtcNow, Solicitud);
                }
                else Solicitud = Entrada.Item2;
            }
            return Solicitud.Wait(TimeSpan.FromSeconds(3)) ? (string[])Solicitud.Result.Clone() : new string[0];
        }
        //Fin Diego Fernando Santizo Samayoa 0901-22-15950 05/10/2026
    }
}
