using CapaModelo_Consultas.Entidades;
// Inicio código Pedro José Gómez Villalobos 0901-23-4868 5/10/2026
namespace CapaControlador_Consultas
{
    public sealed class ClsControladorConsultasSimples
    {
        private readonly ClsServicioConsultasCompartidas _Compartidas;
        public IContextoConsulta Contexto => _Compartidas;

        internal ClsControladorConsultasSimples(ClsServicioConsultasCompartidas Compartidas)
        {
            _Compartidas = Compartidas;
        }

        public void ConsultasProcFiltrar(string Campo, string Operador, string Valor)
        {
            ClsDefinicionConsulta Definicion = new ClsDefinicionConsulta { Tabla = _Compartidas.Tabla };
            Definicion.Condiciones.Add(_Compartidas.Validador.ConsultasFuncValidarCondicion(Campo, Operador, Valor, "", "", false));
            _Compartidas.Definicion = Definicion;
        }
    }
}
// Fin código Pedro José Gómez Villalobos 0901-23-4868 5/10/2026
