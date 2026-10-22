
namespace CapaVista_Consultas.Componentes
{
    partial class UsrTextBoxConsultas
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
            this.ConsultasPnlBorde = new System.Windows.Forms.Panel();
            this.ConsultasTxtTexto = new System.Windows.Forms.RichTextBox();
            this.ConsultasUsrError = new CapaVista_Consultas.Componentes.UsrLabelConsultas();
            this.ConsultasTlpMain.SuspendLayout();
            this.ConsultasPnlBorde.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConsultasTlpMain
            // 
            this.ConsultasTlpMain.ColumnCount = 1;
            this.ConsultasTlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConsultasTlpMain.Controls.Add(this.ConsultasPnlBorde, 0, 0);
            this.ConsultasTlpMain.Controls.Add(this.ConsultasUsrError, 0, 1);
            this.ConsultasTlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsultasTlpMain.Location = new System.Drawing.Point(0, 0);
            this.ConsultasTlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasTlpMain.Name = "ConsultasTlpMain";
            this.ConsultasTlpMain.Padding = new System.Windows.Forms.Padding(3);
            this.ConsultasTlpMain.RowCount = 2;
            this.ConsultasTlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ConsultasTlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ConsultasTlpMain.Size = new System.Drawing.Size(174, 55);
            this.ConsultasTlpMain.TabIndex = 0;
            // 
            // ConsultasPnlBorde
            // 
            this.ConsultasPnlBorde.BackColor = System.Drawing.Color.Red;
            this.ConsultasPnlBorde.Controls.Add(this.ConsultasTxtTexto);
            this.ConsultasPnlBorde.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsultasPnlBorde.Location = new System.Drawing.Point(3, 3);
            this.ConsultasPnlBorde.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasPnlBorde.MaximumSize = new System.Drawing.Size(1000, 30);
            this.ConsultasPnlBorde.Name = "ConsultasPnlBorde";
            this.ConsultasPnlBorde.Padding = new System.Windows.Forms.Padding(1);
            this.ConsultasPnlBorde.Size = new System.Drawing.Size(168, 25);
            this.ConsultasPnlBorde.TabIndex = 2;
            // 
            // ConsultasTxtTexto
            // 
            this.ConsultasTxtTexto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConsultasTxtTexto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsultasTxtTexto.Location = new System.Drawing.Point(1, 1);
            this.ConsultasTxtTexto.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasTxtTexto.Multiline = false;
            this.ConsultasTxtTexto.Name = "ConsultasTxtTexto";
            this.ConsultasTxtTexto.Size = new System.Drawing.Size(166, 23);
            this.ConsultasTxtTexto.TabIndex = 0;
            this.ConsultasTxtTexto.Text = "";
            // 
            // ConsultasUsrError
            // 
            this.ConsultasUsrError.AlineacionTexto = System.Drawing.ContentAlignment.MiddleLeft;
            this.ConsultasUsrError.ColorTexto = System.Drawing.Color.Red;
            this.ConsultasUsrError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsultasUsrError.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ConsultasUsrError.Location = new System.Drawing.Point(6, 32);
            this.ConsultasUsrError.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConsultasUsrError.MaximumSize = new System.Drawing.Size(1000, 22);
            this.ConsultasUsrError.MostrarAsterisco = false;
            this.ConsultasUsrError.Name = "ConsultasUsrError";
            this.ConsultasUsrError.Size = new System.Drawing.Size(162, 22);
            this.ConsultasUsrError.TabIndex = 0;
            // 
            // UsrTextBoxConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ConsultasTlpMain);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(1000, 62);
            this.Name = "UsrTextBoxConsultas";
            this.Size = new System.Drawing.Size(174, 55);
            this.ConsultasTlpMain.ResumeLayout(false);
            this.ConsultasPnlBorde.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CapaVista_Consultas.Componentes.ClsTableLayoutPanelConsultas ConsultasTlpMain;
        private System.Windows.Forms.Panel ConsultasPnlBorde;
        private UsrLabelConsultas ConsultasUsrError;
        private System.Windows.Forms.RichTextBox ConsultasTxtTexto;
    }
}
