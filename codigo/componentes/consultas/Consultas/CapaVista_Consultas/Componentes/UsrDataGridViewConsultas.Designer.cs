namespace CapaVista_Consultas.Componentes
{
    partial class UsrDataGridViewConsultas
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
            System.Windows.Forms.DataGridViewCellStyle EstiloFilasAlternas = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle EstiloEncabezados = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle EstiloCeldas = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle EstiloFilas = new System.Windows.Forms.DataGridViewCellStyle();
            this.ConsultasPnlBorde = new System.Windows.Forms.Panel();
            this.ConsultasDgvMain = new System.Windows.Forms.DataGridView();
            this.ConsultasPnlBorde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConsultasDgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ConsultasPnlBorde
            // 
            this.ConsultasPnlBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(74)))), ((int)(((byte)(99)))));
            this.ConsultasPnlBorde.Controls.Add(this.ConsultasDgvMain);
            this.ConsultasPnlBorde.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsultasPnlBorde.Location = new System.Drawing.Point(0, 0);
            this.ConsultasPnlBorde.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasPnlBorde.Name = "ConsultasPnlBorde";
            this.ConsultasPnlBorde.Padding = new System.Windows.Forms.Padding(1);
            this.ConsultasPnlBorde.Size = new System.Drawing.Size(150, 150);
            this.ConsultasPnlBorde.TabIndex = 0;
            // 
            // ConsultasDgvMain
            // 
            this.ConsultasDgvMain.AllowUserToAddRows = false;
            this.ConsultasDgvMain.AllowUserToDeleteRows = false;
            this.ConsultasDgvMain.AllowUserToResizeRows = false;
            EstiloFilasAlternas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(242)))), ((int)(((byte)(235)))));
            EstiloFilasAlternas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(74)))), ((int)(((byte)(99)))));
            EstiloFilasAlternas.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(128)))), ((int)(((byte)(120)))));
            EstiloFilasAlternas.SelectionForeColor = System.Drawing.Color.White;
            this.ConsultasDgvMain.AlternatingRowsDefaultCellStyle = EstiloFilasAlternas;
            this.ConsultasDgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ConsultasDgvMain.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(218)))));
            this.ConsultasDgvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConsultasDgvMain.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ConsultasDgvMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            EstiloEncabezados.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            EstiloEncabezados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(74)))), ((int)(((byte)(99)))));
            EstiloEncabezados.Font = new System.Drawing.Font("Segoe UI", 9F);
            EstiloEncabezados.ForeColor = System.Drawing.Color.White;
            EstiloEncabezados.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(74)))), ((int)(((byte)(99)))));
            EstiloEncabezados.SelectionForeColor = System.Drawing.Color.White;
            this.ConsultasDgvMain.ColumnHeadersDefaultCellStyle = EstiloEncabezados;
            this.ConsultasDgvMain.ColumnHeadersHeight = 32;
            this.ConsultasDgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            EstiloCeldas.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            EstiloCeldas.BackColor = System.Drawing.Color.White;
            EstiloCeldas.Font = new System.Drawing.Font("Segoe UI", 9F);
            EstiloCeldas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(74)))), ((int)(((byte)(99)))));
            EstiloCeldas.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            EstiloCeldas.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(128)))), ((int)(((byte)(120)))));
            EstiloCeldas.SelectionForeColor = System.Drawing.Color.White;
            EstiloCeldas.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ConsultasDgvMain.DefaultCellStyle = EstiloCeldas;
            this.ConsultasDgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsultasDgvMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ConsultasDgvMain.EnableHeadersVisualStyles = false;
            this.ConsultasDgvMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ConsultasDgvMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(218)))));
            this.ConsultasDgvMain.Location = new System.Drawing.Point(1, 1);
            this.ConsultasDgvMain.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasDgvMain.MultiSelect = false;
            this.ConsultasDgvMain.Name = "ConsultasDgvMain";
            this.ConsultasDgvMain.ReadOnly = true;
            this.ConsultasDgvMain.RowHeadersVisible = false;
            this.ConsultasDgvMain.RowHeadersWidth = 51;
            EstiloFilas.BackColor = System.Drawing.Color.White;
            EstiloFilas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(74)))), ((int)(((byte)(99)))));
            EstiloFilas.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(128)))), ((int)(((byte)(120)))));
            EstiloFilas.SelectionForeColor = System.Drawing.Color.White;
            this.ConsultasDgvMain.RowsDefaultCellStyle = EstiloFilas;
            this.ConsultasDgvMain.RowTemplate.Height = 28;
            this.ConsultasDgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ConsultasDgvMain.Size = new System.Drawing.Size(148, 148);
            this.ConsultasDgvMain.TabIndex = 0;
            // 
            // UsrDataGridViewConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ConsultasPnlBorde);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UsrDataGridViewConsultas";
            this.ConsultasPnlBorde.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ConsultasDgvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ConsultasPnlBorde;
        private System.Windows.Forms.DataGridView ConsultasDgvMain;
    }
}
