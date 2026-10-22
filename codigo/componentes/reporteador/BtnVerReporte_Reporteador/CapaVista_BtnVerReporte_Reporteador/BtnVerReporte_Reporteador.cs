using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaControlador_BtnVerReporte_Reporteador;

namespace CapaVista_BtnVerReporte_Reporteador
{
    public partial class ReporteadorUcVerReporte : UserControl
    {
        private readonly ClsControladorBtnVerReporte _Controlador;

        public ReporteadorUcVerReporte()
        {
            InitializeComponent();
            _Controlador = new ClsControladorBtnVerReporte();

            // HACER QUE EL CLICK DEL BOTON INTERNO LLEGUE AL USERCONTROL
            ReporteadorBtnVerReporte.Click += ReporteadorMetPropagarClick;
        }

        // PROPAGAR EL CLICK DEL BOTON INTERNO AL FORMULARIO QUE LO USA
        private void ReporteadorMetPropagarClick(object Sender, EventArgs ArgumentosEvento)
        {
            OnClick(ArgumentosEvento);
        }

        // BUSCAR LA RUTA POR NUMERO Y ABRIR EL REPORTE CON SUS FUENTES
        public void ReporteadorMetMostrarReporte(int NumeroReporte, Dictionary<string, object> FuentesDeDatos)
        {
            string RutaReporte = _Controlador.ReporteadorMetObtenerRutaReporte(NumeroReporte);

            if (string.IsNullOrEmpty(RutaReporte))
            {
                MessageBox.Show("No se encontro la ruta del reporte.");
                return;
            }

            FrmVistaPrevia VentanaVistaPrevia = new FrmVistaPrevia(RutaReporte, FuentesDeDatos);
            VentanaVistaPrevia.ShowDialog();
        }
    }
}
