namespace CapaVista_Consultas.Componentes
{
    partial class UsrLabelConsultas
    {
        private System.ComponentModel.IContainer _Componentes = null;

        protected override void Dispose(bool LiberarRecursos)
        {
            if (LiberarRecursos && (_Componentes != null))
            {
                _Componentes.Dispose();
            }
            base.Dispose(LiberarRecursos);
        }

        #region Código generado por el Diseñador de componentes

        private void InitializeComponent()
        {
            this.ConsultasTlpMain = new CapaVista_Consultas.Componentes.ClsTableLayoutPanelConsultas();
            this.ConsultasLblTexto = new ClsEtiquetaConsultas();
            this.ConsultasLblAsterisco = new System.Windows.Forms.Label();
            this.ConsultasTlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConsultasTlpMain
            // 
            this.ConsultasTlpMain.ColumnCount = 2;
            this.ConsultasTlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConsultasTlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ConsultasTlpMain.Controls.Add(this.ConsultasLblTexto, 0, 0);
            this.ConsultasTlpMain.Controls.Add(this.ConsultasLblAsterisco, 1, 0);
            this.ConsultasTlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsultasTlpMain.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsultasTlpMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(74)))), ((int)(((byte)(99)))));
            this.ConsultasTlpMain.Location = new System.Drawing.Point(0, 0);
            this.ConsultasTlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasTlpMain.Name = "ConsultasTlpMain";
            this.ConsultasTlpMain.RowCount = 1;
            this.ConsultasTlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConsultasTlpMain.Size = new System.Drawing.Size(208, 20);
            this.ConsultasTlpMain.TabIndex = 0;
            // 
            // ConsultasLblTexto
            // 
            this.ConsultasLblTexto.AutoSize = true;
            this.ConsultasLblTexto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsultasLblTexto.Location = new System.Drawing.Point(3, 0);
            this.ConsultasLblTexto.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ConsultasLblTexto.Name = "ConsultasLblTexto";
            this.ConsultasLblTexto.Size = new System.Drawing.Size(189, 20);
            this.ConsultasLblTexto.TabIndex = 0;
            this.ConsultasLblTexto.Text = "Label de Consultas";
            this.ConsultasLblTexto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConsultasLblAsterisco
            // 
            this.ConsultasLblAsterisco.AutoSize = true;
            this.ConsultasLblAsterisco.Dock = System.Windows.Forms.DockStyle.Left;
            this.ConsultasLblAsterisco.ForeColor = System.Drawing.Color.Red;
            this.ConsultasLblAsterisco.Location = new System.Drawing.Point(192, 0);
            this.ConsultasLblAsterisco.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasLblAsterisco.Name = "ConsultasLblAsterisco";
            this.ConsultasLblAsterisco.Size = new System.Drawing.Size(16, 20);
            this.ConsultasLblAsterisco.TabIndex = 1;
            this.ConsultasLblAsterisco.Text = "*";
            this.ConsultasLblAsterisco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UsrLabelConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ConsultasTlpMain);
            this.MaximumSize = new System.Drawing.Size(1000, 20);
            this.Name = "UsrLabelConsultas";
            this.Size = new System.Drawing.Size(208, 20);
            this.ConsultasTlpMain.ResumeLayout(false);
            this.ConsultasTlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CapaVista_Consultas.Componentes.ClsTableLayoutPanelConsultas ConsultasTlpMain;
        private System.Windows.Forms.Label ConsultasLblTexto;
        private System.Windows.Forms.Label ConsultasLblAsterisco;
    }
}
