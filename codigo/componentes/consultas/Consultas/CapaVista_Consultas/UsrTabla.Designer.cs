namespace CapaVista_Consultas
{
    partial class UsrTabla
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
            System.ComponentModel.ComponentResourceManager Recursos = new System.ComponentModel.ComponentResourceManager(typeof(UsrTabla));
            this.ConsultasTlpPrincipal = new CapaVista_Consultas.Componentes.ClsTableLayoutPanelConsultas();
            this.ConsultasTlpPaginacion = new CapaVista_Consultas.Componentes.ClsTableLayoutPanelConsultas();
            this.ConsultasFlpPaginas = new System.Windows.Forms.FlowLayoutPanel();
            this.ConsultasBtnSiguiente = new CapaVista_Consultas.Componentes.ClsButtonConsultas();
            this.ConsultasBtnAnterior = new CapaVista_Consultas.Componentes.ClsButtonConsultas();
            this.ConsultasUsrResultados = new CapaVista_Consultas.Componentes.UsrDataGridViewConsultas();
            this.ConsultasUsrPaginacion = new CapaVista_Consultas.Componentes.UsrLabelConsultas();
            this.ConsultasTlpPrincipal.SuspendLayout();
            this.ConsultasTlpPaginacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConsultasTlpPrincipal
            // 
            this.ConsultasTlpPrincipal.ColumnCount = 2;
            this.ConsultasTlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.ConsultasTlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConsultasTlpPrincipal.Controls.Add(this.ConsultasTlpPaginacion, 1, 1);
            this.ConsultasTlpPrincipal.Controls.Add(this.ConsultasUsrResultados, 0, 0);
            this.ConsultasTlpPrincipal.Controls.Add(this.ConsultasUsrPaginacion, 0, 1);
            this.ConsultasTlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsultasTlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.ConsultasTlpPrincipal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConsultasTlpPrincipal.Name = "ConsultasTlpPrincipal";
            this.ConsultasTlpPrincipal.RowCount = 2;
            this.ConsultasTlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConsultasTlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.ConsultasTlpPrincipal.Size = new System.Drawing.Size(871, 480);
            this.ConsultasTlpPrincipal.TabIndex = 0;
            // 
            // ConsultasTlpPaginacion
            // 
            this.ConsultasTlpPaginacion.ColumnCount = 3;
            this.ConsultasTlpPaginacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.ConsultasTlpPaginacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConsultasTlpPaginacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.ConsultasTlpPaginacion.Controls.Add(this.ConsultasFlpPaginas, 1, 0);
            this.ConsultasTlpPaginacion.Controls.Add(this.ConsultasBtnSiguiente, 2, 0);
            this.ConsultasTlpPaginacion.Controls.Add(this.ConsultasBtnAnterior, 0, 0);
            this.ConsultasTlpPaginacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsultasTlpPaginacion.Location = new System.Drawing.Point(200, 428);
            this.ConsultasTlpPaginacion.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasTlpPaginacion.Name = "ConsultasTlpPaginacion";
            this.ConsultasTlpPaginacion.RowCount = 1;
            this.ConsultasTlpPaginacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConsultasTlpPaginacion.Size = new System.Drawing.Size(671, 52);
            this.ConsultasTlpPaginacion.TabIndex = 3;
            // 
            // ConsultasFlpPaginas
            // 
            this.ConsultasFlpPaginas.AutoScroll = false;
            this.ConsultasFlpPaginas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsultasFlpPaginas.Location = new System.Drawing.Point(53, 0);
            this.ConsultasFlpPaginas.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.ConsultasFlpPaginas.Name = "ConsultasFlpPaginas";
            this.ConsultasFlpPaginas.Size = new System.Drawing.Size(565, 52);
            this.ConsultasFlpPaginas.TabIndex = 2;
            this.ConsultasFlpPaginas.WrapContents = false;
            // 
            // ConsultasBtnSiguiente
            // 
            this.ConsultasBtnSiguiente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConsultasBtnSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(218)))));
            this.ConsultasBtnSiguiente.BackgroundImage = ((System.Drawing.Image)(Recursos.GetObject("ConsultasBtnSiguiente.BackgroundImage")));
            this.ConsultasBtnSiguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConsultasBtnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConsultasBtnSiguiente.FlatAppearance.BorderSize = 0;
            this.ConsultasBtnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsultasBtnSiguiente.ImagenDeshabilitado = ((System.Drawing.Image)(Recursos.GetObject("ConsultasBtnSiguiente.ImagenDeshabilitado")));
            this.ConsultasBtnSiguiente.Location = new System.Drawing.Point(621, 1);
            this.ConsultasBtnSiguiente.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasBtnSiguiente.MaximumSize = new System.Drawing.Size(50, 50);
            this.ConsultasBtnSiguiente.MinimumSize = new System.Drawing.Size(50, 50);
            this.ConsultasBtnSiguiente.Name = "ConsultasBtnSiguiente";
            this.ConsultasBtnSiguiente.Size = new System.Drawing.Size(50, 50);
            this.ConsultasBtnSiguiente.TabIndex = 4;
            this.ConsultasBtnSiguiente.UseVisualStyleBackColor = false;
            // 
            // ConsultasBtnAnterior
            // 
            this.ConsultasBtnAnterior.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConsultasBtnAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(218)))));
            this.ConsultasBtnAnterior.BackgroundImage = ((System.Drawing.Image)(Recursos.GetObject("ConsultasBtnAnterior.BackgroundImage")));
            this.ConsultasBtnAnterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConsultasBtnAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConsultasBtnAnterior.FlatAppearance.BorderSize = 0;
            this.ConsultasBtnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsultasBtnAnterior.ImagenDeshabilitado = ((System.Drawing.Image)(Recursos.GetObject("ConsultasBtnAnterior.ImagenDeshabilitado")));
            this.ConsultasBtnAnterior.Location = new System.Drawing.Point(0, 1);
            this.ConsultasBtnAnterior.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasBtnAnterior.MaximumSize = new System.Drawing.Size(50, 50);
            this.ConsultasBtnAnterior.MinimumSize = new System.Drawing.Size(50, 50);
            this.ConsultasBtnAnterior.Name = "ConsultasBtnAnterior";
            this.ConsultasBtnAnterior.Size = new System.Drawing.Size(50, 50);
            this.ConsultasBtnAnterior.TabIndex = 3;
            this.ConsultasBtnAnterior.UseVisualStyleBackColor = false;
            // 
            // ConsultasUsrResultados
            // 
            this.ConsultasTlpPrincipal.SetColumnSpan(this.ConsultasUsrResultados, 2);
            this.ConsultasUsrResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsultasUsrResultados.Location = new System.Drawing.Point(3, 4);
            this.ConsultasUsrResultados.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConsultasUsrResultados.Name = "ConsultasUsrResultados";
            this.ConsultasUsrResultados.Size = new System.Drawing.Size(865, 420);
            this.ConsultasUsrResultados.TabIndex = 0;
            // 
            // ConsultasUsrPaginacion
            // 
            this.ConsultasUsrPaginacion.AlineacionTexto = System.Drawing.ContentAlignment.MiddleCenter;
            this.ConsultasUsrPaginacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConsultasUsrPaginacion.BackColor = System.Drawing.Color.Transparent;
            this.ConsultasUsrPaginacion.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ConsultasUsrPaginacion.Location = new System.Drawing.Point(3, 443);
            this.ConsultasUsrPaginacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConsultasUsrPaginacion.MaximumSize = new System.Drawing.Size(1000, 22);
            this.ConsultasUsrPaginacion.MostrarAsterisco = false;
            this.ConsultasUsrPaginacion.Name = "ConsultasUsrPaginacion";
            this.ConsultasUsrPaginacion.Size = new System.Drawing.Size(194, 22);
            this.ConsultasUsrPaginacion.TabIndex = 5;
            this.ConsultasUsrPaginacion.TabStop = false;
            this.ConsultasUsrPaginacion.Texto = "Mostrando x-y de z registros";
            // 
            // UsrTabla
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(218)))));
            this.Controls.Add(this.ConsultasTlpPrincipal);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UsrTabla";
            this.Size = new System.Drawing.Size(871, 480);
            this.ConsultasTlpPrincipal.ResumeLayout(false);
            this.ConsultasTlpPaginacion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CapaVista_Consultas.Componentes.ClsTableLayoutPanelConsultas ConsultasTlpPrincipal;
        private CapaVista_Consultas.Componentes.ClsTableLayoutPanelConsultas ConsultasTlpPaginacion;
        private System.Windows.Forms.FlowLayoutPanel ConsultasFlpPaginas;
        private CapaVista_Consultas.Componentes.ClsButtonConsultas ConsultasBtnSiguiente;
        private CapaVista_Consultas.Componentes.UsrDataGridViewConsultas ConsultasUsrResultados;
        private CapaVista_Consultas.Componentes.UsrLabelConsultas ConsultasUsrPaginacion;
        private Componentes.ClsButtonConsultas ConsultasBtnAnterior;
    }
}
