using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

namespace CapaVista_Consultas
{
    public sealed class ClsSeleccionConsulta : EventArgs
    {
        /*Inicio de código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
        public object Valor { get; }
        public string Pk { get; }
        public IReadOnlyDictionary<string, object> Campos { get; }

        public ClsSeleccionConsulta(object Valor) : this(Valor, null)
        {
        }

        public ClsSeleccionConsulta(object Valor, string Pk) : this(Valor, Pk, null)
        {
        }

        public ClsSeleccionConsulta(object Valor, string Pk, IDictionary<string, object> Campos)
        {
            this.Valor = Valor;
            this.Pk = Pk;
            var Copia = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            if (Campos != null)
            {
                foreach (var Campo in Campos) Copia.Add(Campo.Key, Campo.Value);
            }
            this.Campos = new ReadOnlyDictionary<string, object>(Copia);
        }

        public object ConsultasFuncObtenerValorSeleccionado(string Campo)
        {
            if (string.IsNullOrWhiteSpace(Campo)) throw new ArgumentException("Indique el nombre del campo.", nameof(Campo));
            object ValorCampo;
            if (!Campos.TryGetValue(Campo, out ValorCampo)) throw new ArgumentException("El campo no pertenece al registro seleccionado: " + Campo, nameof(Campo));
            return ValorCampo;
        }

        public string ConsultasFuncObtenerCampoSeleccionado(string Campo)
        {
            return Convert.ToString(ConsultasFuncObtenerValorSeleccionado(Campo), CultureInfo.InvariantCulture);
        }
        /*Fin del código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
    }
}
