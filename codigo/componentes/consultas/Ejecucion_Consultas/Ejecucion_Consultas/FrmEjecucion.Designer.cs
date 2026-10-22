namespace Ejecucion_Consultas
{
    partial class FrmEjecucion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEjecucion));
            this.consultas1 = new CapaVista_Consultas.Consultas();
            this.ConsultasUsrCampoRetornado = new CapaVista_Consultas.Componentes.UsrTextBoxConsultas();
            this.ConsultasUsrPkRetornado = new CapaVista_Consultas.Componentes.UsrTextBoxConsultas();
            ((System.ComponentModel.ISupportInitialize)(this.consultas1)).BeginInit();
            this.SuspendLayout();
            // 
            // consultas1
            // 
            this.consultas1.CampoRetorno = "queryConsulta";
            this.consultas1.ControlRetorno = this.ConsultasUsrCampoRetornado;
            this.consultas1.Location = new System.Drawing.Point(87, 180);
            this.consultas1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.consultas1.Name = "consultas1";
            this.consultas1.Size = new System.Drawing.Size(256, 66);
            this.consultas1.TabIndex = 1;
            this.consultas1.Tabla = "tblconsulta";
            this.consultas1.Text = "consultas1";
            this.consultas1.UseVisualStyleBackColor = true;
            // 
            // ConsultasUsrCampoRetornado
            // 
            this.ConsultasUsrCampoRetornado.Enabled = false;
            this.ConsultasUsrCampoRetornado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ConsultasUsrCampoRetornado.Location = new System.Drawing.Point(9, 103);
            this.ConsultasUsrCampoRetornado.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasUsrCampoRetornado.MaximumSize = new System.Drawing.Size(1000, 62);
            this.ConsultasUsrCampoRetornado.MaxLength = 2147483647;
            this.ConsultasUsrCampoRetornado.Name = "ConsultasUsrCampoRetornado";
            this.ConsultasUsrCampoRetornado.Size = new System.Drawing.Size(397, 62);
            this.ConsultasUsrCampoRetornado.TabIndex = 3;
            // 
            // ConsultasUsrPkRetornado
            // 
            this.ConsultasUsrPkRetornado.Enabled = false;
            this.ConsultasUsrPkRetornado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ConsultasUsrPkRetornado.Location = new System.Drawing.Point(9, 23);
            this.ConsultasUsrPkRetornado.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasUsrPkRetornado.MaximumSize = new System.Drawing.Size(1000, 62);
            this.ConsultasUsrPkRetornado.MaxLength = 2147483647;
            this.ConsultasUsrPkRetornado.Name = "ConsultasUsrPkRetornado";
            this.ConsultasUsrPkRetornado.Size = new System.Drawing.Size(397, 62);
            this.ConsultasUsrPkRetornado.TabIndex = 2;
            // 
            // FrmEjecucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(413, 271);
            this.Controls.Add(this.ConsultasUsrCampoRetornado);
            this.Controls.Add(this.ConsultasUsrPkRetornado);
            this.Controls.Add(this.consultas1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(431, 318);
            this.MinimumSize = new System.Drawing.Size(431, 318);
            this.Name = "FrmEjecucion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "4001 - Ejecución";
            ((System.ComponentModel.ISupportInitialize)(this.consultas1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CapaVista_Consultas.Consultas consultas1;
        private CapaVista_Consultas.Componentes.UsrTextBoxConsultas ConsultasUsrPkRetornado;
        private CapaVista_Consultas.Componentes.UsrTextBoxConsultas ConsultasUsrCampoRetornado;
    }
}
