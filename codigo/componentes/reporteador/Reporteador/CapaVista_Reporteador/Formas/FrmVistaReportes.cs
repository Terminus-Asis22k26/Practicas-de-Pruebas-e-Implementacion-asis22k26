using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using CapaControlador_Reporteador;
using Microsoft.Reporting.WinForms;

namespace CapaVista_Reporteador.Formas
{
    public partial class FrmVistaReportes : Form
    {
        private readonly string _RutaReporte;
        private readonly Dictionary<string, object> _FuentesDeDatos;

        public FrmVistaReportes(string RutaReporte, Dictionary<string, object> FuentesDeDatos)
        {
            InitializeComponent();
            _RutaReporte = RutaReporte;
            _FuentesDeDatos = FuentesDeDatos;
        }

        public FrmVistaReportes(int IdAplicacion, Dictionary<string, object> FuentesDeDatos)
            : this(
                new ClsModeloReporteador().ReporteadorMetObtenerRutaPrimerReporte(IdAplicacion),
                FuentesDeDatos
            ) { }

        private void ReporteadorMetCargarVistaPrevia(object Sender, EventArgs E)
        {
            if (_FuentesDeDatos == null)
            {
                ReporteadorRpvVistaReporte.LocalReport.ReportPath = _RutaReporte;
                ReporteadorRpvVistaReporte.RefreshReport();
                return;
            }

            ReporteadorMetCargarReporteDinamico(_RutaReporte, _FuentesDeDatos);
        }

        private void ReporteadorMetCargarReporteDinamico(
            string RutaRdlc,
            Dictionary<string, object> FuentesDeDatos
        )
        {
            if (!File.Exists(RutaRdlc))
            {
                MessageBox.Show("No se encontro el reporte en: " + RutaRdlc);
                return;
            }

            ReporteadorRpvVistaReporte.Reset();
            ReporteadorRpvVistaReporte.ProcessingMode = ProcessingMode.Local;
            ReporteadorRpvVistaReporte.LocalReport.ReportPath = RutaRdlc;

            // OBTENER LOS NOMBRES DE DATASET QUE PIDE EL ARCHIVO RDLC
            IList<string> DatasetsRequeridos =
                ReporteadorRpvVistaReporte.LocalReport.GetDataSourceNames();

            if (FuentesDeDatos == null)
            {
                FuentesDeDatos = new Dictionary<string, object>();
            }

            foreach (string NombreDataset in DatasetsRequeridos)
            {
                if (FuentesDeDatos.ContainsKey(NombreDataset))
                {
                    object Datos = FuentesDeDatos[NombreDataset];

                    ReportDataSource Fuente = new ReportDataSource(NombreDataset, Datos);

                    ReporteadorRpvVistaReporte.LocalReport.DataSources.Add(Fuente);
                }
                else
                {
                    MessageBox.Show(
                        "Advertencia: El reporte requiere el DataSet '" + NombreDataset + "', pero no fue provisto."
                    );
                }
            }

            ReporteadorRpvVistaReporte.RefreshReport();
        }
    }
}
