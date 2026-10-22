namespace CapaVista_Reporteador.Formas
{
    partial class FrmVistaReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVistaReportes));
            this.ReporteadorRpvVistaReporte = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // ReporteadorRpvVistaReporte
            // 
            this.ReporteadorRpvVistaReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReporteadorRpvVistaReporte.Location = new System.Drawing.Point(0, 0);
            this.ReporteadorRpvVistaReporte.Name = "ReporteadorRpvVistaReporte";
            this.ReporteadorRpvVistaReporte.ServerReport.BearerToken = null;
            this.ReporteadorRpvVistaReporte.Size = new System.Drawing.Size(1163, 832);
            this.ReporteadorRpvVistaReporte.TabIndex = 0;
            // 
            // FrmVistaReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 832);
            this.Controls.Add(this.ReporteadorRpvVistaReporte);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmVistaReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3002 – VistaPrevia";
            this.Load += new System.EventHandler(this.ReporteadorMetCargarVistaPrevia);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer ReporteadorRpvVistaReporte;
    }
}