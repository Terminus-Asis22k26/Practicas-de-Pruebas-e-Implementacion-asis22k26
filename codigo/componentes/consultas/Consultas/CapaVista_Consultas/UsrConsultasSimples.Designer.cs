namespace CapaVista_Consultas
{
    partial class UsrConsultasSimples
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrConsultasSimples));
            this.ConsultasTlpPrincipal = new CapaVista_Consultas.Componentes.ClsTableLayoutPanelConsultas();
            this.ConsultasGbxAgregarFiltro = new CapaVista_Consultas.Componentes.ClsGroupBoxConsultas();
            this.ConsultasTlpAgregarFiltro = new CapaVista_Consultas.Componentes.ClsTableLayoutPanelConsultas();
            this.ConsultasUsrEtiquetaValor = new CapaVista_Consultas.Componentes.UsrLabelConsultas();
            this.ConsultasUsrCampo = new CapaVista_Consultas.Componentes.UsrLabelConsultas();
            this.ConsultasCboCampo = new CapaVista_Consultas.Componentes.ClsComboBoxConsultas();
            this.ConsultasUsrValor = new CapaVista_Consultas.Componentes.UsrTextBoxConsultas();
            this.ConsultasCboOperador = new CapaVista_Consultas.Componentes.ClsComboBoxConsultas();
            this.ConsultasUsrOperador = new CapaVista_Consultas.Componentes.UsrLabelConsultas();
            this.ConsultasBtnBuscar = new CapaVista_Consultas.Componentes.ClsButtonConsultas();
            this.ConsultasBtnRefrescar = new CapaVista_Consultas.Componentes.ClsButtonConsultas();
            this.ConsultasBtnAyuda = new CapaVista_Consultas.Componentes.ClsButtonConsultas();
            this.ConsultasBtnConsultasComplejas = new CapaVista_Consultas.Componentes.ClsButtonConsultas();
            this.ConsultasBtnSalir = new CapaVista_Consultas.Componentes.ClsButtonConsultas();
            this.ConsultasGbxSeleccioneUnRegistro = new CapaVista_Consultas.Componentes.ClsGroupBoxConsultas();
            this.ConsultasUsrTabla = new CapaVista_Consultas.UsrTabla();
            this.ConsultasTlpPrincipal.SuspendLayout();
            this.ConsultasGbxAgregarFiltro.SuspendLayout();
            this.ConsultasTlpAgregarFiltro.SuspendLayout();
            this.ConsultasGbxSeleccioneUnRegistro.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConsultasTlpPrincipal
            // 
            this.ConsultasTlpPrincipal.ColumnCount = 1;
            this.ConsultasTlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConsultasTlpPrincipal.Controls.Add(this.ConsultasGbxAgregarFiltro, 0, 0);
            this.ConsultasTlpPrincipal.Controls.Add(this.ConsultasGbxSeleccioneUnRegistro, 0, 1);
            this.ConsultasTlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsultasTlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.ConsultasTlpPrincipal.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasTlpPrincipal.Name = "ConsultasTlpPrincipal";
            this.ConsultasTlpPrincipal.RowCount = 2;
            this.ConsultasTlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.ConsultasTlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConsultasTlpPrincipal.Size = new System.Drawing.Size(1000, 650);
            this.ConsultasTlpPrincipal.TabIndex = 20;
            // 
            // ConsultasGbxAgregarFiltro
            // 
            this.ConsultasGbxAgregarFiltro.BackColor = System.Drawing.Color.Transparent;
            this.ConsultasGbxAgregarFiltro.Controls.Add(this.ConsultasTlpAgregarFiltro);
            this.ConsultasGbxAgregarFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsultasGbxAgregarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsultasGbxAgregarFiltro.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ConsultasGbxAgregarFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(74)))), ((int)(((byte)(99)))));
            this.ConsultasGbxAgregarFiltro.Location = new System.Drawing.Point(3, 3);
            this.ConsultasGbxAgregarFiltro.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.ConsultasGbxAgregarFiltro.Name = "ConsultasGbxAgregarFiltro";
            this.ConsultasGbxAgregarFiltro.Padding = new System.Windows.Forms.Padding(0);
            this.ConsultasGbxAgregarFiltro.Size = new System.Drawing.Size(994, 142);
            this.ConsultasGbxAgregarFiltro.TabIndex = 19;
            this.ConsultasGbxAgregarFiltro.TabStop = false;
            this.ConsultasGbxAgregarFiltro.Text = "Agregar Filtro";
            // 
            // ConsultasTlpAgregarFiltro
            // 
            this.ConsultasTlpAgregarFiltro.AutoSize = true;
            this.ConsultasTlpAgregarFiltro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ConsultasTlpAgregarFiltro.ColumnCount = 9;
            this.ConsultasTlpAgregarFiltro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.ConsultasTlpAgregarFiltro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConsultasTlpAgregarFiltro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.ConsultasTlpAgregarFiltro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.ConsultasTlpAgregarFiltro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.ConsultasTlpAgregarFiltro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.ConsultasTlpAgregarFiltro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.ConsultasTlpAgregarFiltro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.ConsultasTlpAgregarFiltro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.ConsultasTlpAgregarFiltro.Controls.Add(this.ConsultasUsrEtiquetaValor, 0, 2);
            this.ConsultasTlpAgregarFiltro.Controls.Add(this.ConsultasUsrCampo, 0, 1);
            this.ConsultasTlpAgregarFiltro.Controls.Add(this.ConsultasCboCampo, 1, 1);
            this.ConsultasTlpAgregarFiltro.Controls.Add(this.ConsultasUsrValor, 1, 2);
            this.ConsultasTlpAgregarFiltro.Controls.Add(this.ConsultasCboOperador, 3, 1);
            this.ConsultasTlpAgregarFiltro.Controls.Add(this.ConsultasUsrOperador, 2, 1);
            this.ConsultasTlpAgregarFiltro.Controls.Add(this.ConsultasBtnBuscar, 4, 0);
            this.ConsultasTlpAgregarFiltro.Controls.Add(this.ConsultasBtnRefrescar, 5, 0);
            this.ConsultasTlpAgregarFiltro.Controls.Add(this.ConsultasBtnAyuda, 6, 0);
            this.ConsultasTlpAgregarFiltro.Controls.Add(this.ConsultasBtnConsultasComplejas, 7, 0);
            this.ConsultasTlpAgregarFiltro.Controls.Add(this.ConsultasBtnSalir, 8, 0);
            this.ConsultasTlpAgregarFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsultasTlpAgregarFiltro.Location = new System.Drawing.Point(0, 21);
            this.ConsultasTlpAgregarFiltro.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasTlpAgregarFiltro.Name = "ConsultasTlpAgregarFiltro";
            this.ConsultasTlpAgregarFiltro.RowCount = 4;
            this.ConsultasTlpAgregarFiltro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ConsultasTlpAgregarFiltro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.ConsultasTlpAgregarFiltro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.ConsultasTlpAgregarFiltro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ConsultasTlpAgregarFiltro.Size = new System.Drawing.Size(994, 121);
            this.ConsultasTlpAgregarFiltro.TabIndex = 0;
            // 
            // ConsultasUsrEtiquetaValor
            // 
            this.ConsultasUsrEtiquetaValor.Dock = System.Windows.Forms.DockStyle.Right;
            this.ConsultasUsrEtiquetaValor.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ConsultasUsrEtiquetaValor.Location = new System.Drawing.Point(3, 53);
            this.ConsultasUsrEtiquetaValor.MaximumSize = new System.Drawing.Size(1000, 22);
            this.ConsultasUsrEtiquetaValor.Name = "ConsultasUsrEtiquetaValor";
            this.ConsultasUsrEtiquetaValor.Size = new System.Drawing.Size(94, 22);
            this.ConsultasUsrEtiquetaValor.TabIndex = 2;
            this.ConsultasUsrEtiquetaValor.Texto = "Valor";
            // 
            // ConsultasUsrCampo
            // 
            this.ConsultasUsrCampo.Dock = System.Windows.Forms.DockStyle.Right;
            this.ConsultasUsrCampo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ConsultasUsrCampo.Location = new System.Drawing.Point(3, 14);
            this.ConsultasUsrCampo.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.ConsultasUsrCampo.MaximumSize = new System.Drawing.Size(1000, 22);
            this.ConsultasUsrCampo.Name = "ConsultasUsrCampo";
            this.ConsultasUsrCampo.Size = new System.Drawing.Size(94, 22);
            this.ConsultasUsrCampo.TabIndex = 0;
            this.ConsultasUsrCampo.Texto = "Campo";
            // 
            // ConsultasCboCampo
            // 
            this.ConsultasCboCampo.BackColor = System.Drawing.Color.White;
            this.ConsultasCboCampo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsultasCboCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConsultasCboCampo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsultasCboCampo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ConsultasCboCampo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(74)))), ((int)(((byte)(99)))));
            this.ConsultasCboCampo.FormattingEnabled = true;
            this.ConsultasCboCampo.Location = new System.Drawing.Point(103, 14);
            this.ConsultasCboCampo.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.ConsultasCboCampo.Name = "ConsultasCboCampo";
            this.ConsultasCboCampo.Size = new System.Drawing.Size(213, 31);
            this.ConsultasCboCampo.TabIndex = 3;
            // 
            // ConsultasUsrValor
            // 
            this.ConsultasUsrValor.AutoSize = true;
            this.ConsultasUsrValor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ConsultasTlpAgregarFiltro.SetColumnSpan(this.ConsultasUsrValor, 3);
            this.ConsultasUsrValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsultasUsrValor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ConsultasUsrValor.Location = new System.Drawing.Point(100, 50);
            this.ConsultasUsrValor.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasUsrValor.MaximumSize = new System.Drawing.Size(1000, 62);
            this.ConsultasUsrValor.MaxLength = 2147483647;
            this.ConsultasUsrValor.Name = "ConsultasUsrValor";
            this.ConsultasUsrValor.Size = new System.Drawing.Size(444, 62);
            this.ConsultasUsrValor.TabIndex = 5;
            // 
            // ConsultasCboOperador
            // 
            this.ConsultasCboOperador.BackColor = System.Drawing.Color.White;
            this.ConsultasCboOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConsultasCboOperador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsultasCboOperador.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ConsultasCboOperador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(74)))), ((int)(((byte)(99)))));
            this.ConsultasCboOperador.FormattingEnabled = true;
            this.ConsultasCboOperador.Location = new System.Drawing.Point(422, 14);
            this.ConsultasCboOperador.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.ConsultasCboOperador.Name = "ConsultasCboOperador";
            this.ConsultasCboOperador.Size = new System.Drawing.Size(119, 31);
            this.ConsultasCboOperador.TabIndex = 4;
            // 
            // ConsultasUsrOperador
            // 
            this.ConsultasUsrOperador.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ConsultasUsrOperador.Location = new System.Drawing.Point(322, 14);
            this.ConsultasUsrOperador.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.ConsultasUsrOperador.MaximumSize = new System.Drawing.Size(1000, 22);
            this.ConsultasUsrOperador.Name = "ConsultasUsrOperador";
            this.ConsultasUsrOperador.Size = new System.Drawing.Size(94, 22);
            this.ConsultasUsrOperador.TabIndex = 1;
            this.ConsultasUsrOperador.Texto = "Operador";
            // 
            // ConsultasBtnBuscar
            // 
            this.ConsultasBtnBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConsultasBtnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(218)))));
            this.ConsultasBtnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ConsultasBtnBuscar.BackgroundImage")));
            this.ConsultasBtnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConsultasBtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConsultasBtnBuscar.FlatAppearance.BorderSize = 0;
            this.ConsultasBtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsultasBtnBuscar.ImagenDeshabilitado = ((System.Drawing.Image)(resources.GetObject("ConsultasBtnBuscar.ImagenDeshabilitado")));
            this.ConsultasBtnBuscar.Location = new System.Drawing.Point(549, 20);
            this.ConsultasBtnBuscar.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasBtnBuscar.MaximumSize = new System.Drawing.Size(80, 80);
            this.ConsultasBtnBuscar.MinimumSize = new System.Drawing.Size(80, 80);
            this.ConsultasBtnBuscar.Name = "ConsultasBtnBuscar";
            this.ConsultasTlpAgregarFiltro.SetRowSpan(this.ConsultasBtnBuscar, 4);
            this.ConsultasBtnBuscar.Size = new System.Drawing.Size(80, 80);
            this.ConsultasBtnBuscar.TabIndex = 6;
            this.ConsultasBtnBuscar.UseVisualStyleBackColor = false;
            // 
            // ConsultasBtnRefrescar
            // 
            this.ConsultasBtnRefrescar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConsultasBtnRefrescar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(218)))));
            this.ConsultasBtnRefrescar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ConsultasBtnRefrescar.BackgroundImage")));
            this.ConsultasBtnRefrescar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConsultasBtnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConsultasBtnRefrescar.FlatAppearance.BorderSize = 0;
            this.ConsultasBtnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsultasBtnRefrescar.ImagenDeshabilitado = ((System.Drawing.Image)(resources.GetObject("ConsultasBtnRefrescar.ImagenDeshabilitado")));
            this.ConsultasBtnRefrescar.Location = new System.Drawing.Point(639, 20);
            this.ConsultasBtnRefrescar.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasBtnRefrescar.MaximumSize = new System.Drawing.Size(80, 80);
            this.ConsultasBtnRefrescar.MinimumSize = new System.Drawing.Size(80, 80);
            this.ConsultasBtnRefrescar.Name = "ConsultasBtnRefrescar";
            this.ConsultasTlpAgregarFiltro.SetRowSpan(this.ConsultasBtnRefrescar, 4);
            this.ConsultasBtnRefrescar.Size = new System.Drawing.Size(80, 80);
            this.ConsultasBtnRefrescar.TabIndex = 7;
            this.ConsultasBtnRefrescar.UseVisualStyleBackColor = false;
            // 
            // ConsultasBtnAyuda
            // 
            this.ConsultasBtnAyuda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConsultasBtnAyuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(218)))));
            this.ConsultasBtnAyuda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ConsultasBtnAyuda.BackgroundImage")));
            this.ConsultasBtnAyuda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConsultasBtnAyuda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConsultasBtnAyuda.FlatAppearance.BorderSize = 0;
            this.ConsultasBtnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsultasBtnAyuda.Location = new System.Drawing.Point(729, 20);
            this.ConsultasBtnAyuda.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasBtnAyuda.MaximumSize = new System.Drawing.Size(80, 80);
            this.ConsultasBtnAyuda.MinimumSize = new System.Drawing.Size(80, 80);
            this.ConsultasBtnAyuda.Name = "ConsultasBtnAyuda";
            this.ConsultasTlpAgregarFiltro.SetRowSpan(this.ConsultasBtnAyuda, 4);
            this.ConsultasBtnAyuda.Size = new System.Drawing.Size(80, 80);
            this.ConsultasBtnAyuda.TabIndex = 8;
            this.ConsultasBtnAyuda.UseVisualStyleBackColor = false;
            // 
            // ConsultasBtnConsultasComplejas
            // 
            this.ConsultasBtnConsultasComplejas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConsultasBtnConsultasComplejas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(218)))));
            this.ConsultasBtnConsultasComplejas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ConsultasBtnConsultasComplejas.BackgroundImage")));
            this.ConsultasBtnConsultasComplejas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConsultasBtnConsultasComplejas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConsultasBtnConsultasComplejas.FlatAppearance.BorderSize = 0;
            this.ConsultasBtnConsultasComplejas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsultasBtnConsultasComplejas.Location = new System.Drawing.Point(819, 20);
            this.ConsultasBtnConsultasComplejas.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasBtnConsultasComplejas.MaximumSize = new System.Drawing.Size(80, 80);
            this.ConsultasBtnConsultasComplejas.MinimumSize = new System.Drawing.Size(80, 80);
            this.ConsultasBtnConsultasComplejas.Name = "ConsultasBtnConsultasComplejas";
            this.ConsultasTlpAgregarFiltro.SetRowSpan(this.ConsultasBtnConsultasComplejas, 4);
            this.ConsultasBtnConsultasComplejas.Size = new System.Drawing.Size(80, 80);
            this.ConsultasBtnConsultasComplejas.TabIndex = 9;
            this.ConsultasBtnConsultasComplejas.UseVisualStyleBackColor = false;
            this.ConsultasBtnConsultasComplejas.Click += new System.EventHandler(this.ConsultasMetMostrarComplejas);
            // 
            // ConsultasBtnSalir
            // 
            this.ConsultasBtnSalir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConsultasBtnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(218)))));
            this.ConsultasBtnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ConsultasBtnSalir.BackgroundImage")));
            this.ConsultasBtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConsultasBtnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConsultasBtnSalir.FlatAppearance.BorderSize = 0;
            this.ConsultasBtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsultasBtnSalir.Location = new System.Drawing.Point(909, 20);
            this.ConsultasBtnSalir.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasBtnSalir.MaximumSize = new System.Drawing.Size(80, 80);
            this.ConsultasBtnSalir.MinimumSize = new System.Drawing.Size(80, 80);
            this.ConsultasBtnSalir.Name = "ConsultasBtnSalir";
            this.ConsultasTlpAgregarFiltro.SetRowSpan(this.ConsultasBtnSalir, 4);
            this.ConsultasBtnSalir.Size = new System.Drawing.Size(80, 80);
            this.ConsultasBtnSalir.TabIndex = 10;
            this.ConsultasBtnSalir.UseVisualStyleBackColor = false;
            // 
            // ConsultasGbxSeleccioneUnRegistro
            // 
            this.ConsultasGbxSeleccioneUnRegistro.BackColor = System.Drawing.Color.Transparent;
            this.ConsultasGbxSeleccioneUnRegistro.Controls.Add(this.ConsultasUsrTabla);
            this.ConsultasGbxSeleccioneUnRegistro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsultasGbxSeleccioneUnRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsultasGbxSeleccioneUnRegistro.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ConsultasGbxSeleccioneUnRegistro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(74)))), ((int)(((byte)(99)))));
            this.ConsultasGbxSeleccioneUnRegistro.Location = new System.Drawing.Point(3, 145);
            this.ConsultasGbxSeleccioneUnRegistro.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ConsultasGbxSeleccioneUnRegistro.Name = "ConsultasGbxSeleccioneUnRegistro";
            this.ConsultasGbxSeleccioneUnRegistro.Padding = new System.Windows.Forms.Padding(0);
            this.ConsultasGbxSeleccioneUnRegistro.Size = new System.Drawing.Size(994, 502);
            this.ConsultasGbxSeleccioneUnRegistro.TabIndex = 20;
            this.ConsultasGbxSeleccioneUnRegistro.TabStop = false;
            this.ConsultasGbxSeleccioneUnRegistro.Text = "Seleccione un Registro";
            // 
            // ConsultasUsrTabla
            // 
            this.ConsultasUsrTabla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(218)))));
            this.ConsultasUsrTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsultasUsrTabla.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ConsultasUsrTabla.Location = new System.Drawing.Point(0, 21);
            this.ConsultasUsrTabla.Margin = new System.Windows.Forms.Padding(0);
            this.ConsultasUsrTabla.MaximumSize = new System.Drawing.Size(1150, 750);
            this.ConsultasUsrTabla.Name = "ConsultasUsrTabla";
            this.ConsultasUsrTabla.Size = new System.Drawing.Size(994, 481);
            this.ConsultasUsrTabla.TabIndex = 0;
            // 
            // UsrConsultasSimples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ConsultasTlpPrincipal);
            this.MaximumSize = new System.Drawing.Size(1000, 650);
            this.Name = "UsrConsultasSimples";
            this.Size = new System.Drawing.Size(1000, 650);
            this.ConsultasTlpPrincipal.ResumeLayout(false);
            this.ConsultasGbxAgregarFiltro.ResumeLayout(false);
            this.ConsultasGbxAgregarFiltro.PerformLayout();
            this.ConsultasTlpAgregarFiltro.ResumeLayout(false);
            this.ConsultasTlpAgregarFiltro.PerformLayout();
            this.ConsultasGbxSeleccioneUnRegistro.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CapaVista_Consultas.Componentes.ClsTableLayoutPanelConsultas ConsultasTlpPrincipal;
        private Componentes.ClsGroupBoxConsultas ConsultasGbxAgregarFiltro;
        private CapaVista_Consultas.Componentes.ClsTableLayoutPanelConsultas ConsultasTlpAgregarFiltro;
        private Componentes.ClsButtonConsultas ConsultasBtnSalir;
        private Componentes.ClsButtonConsultas ConsultasBtnConsultasComplejas;
        private Componentes.ClsButtonConsultas ConsultasBtnAyuda;
        private Componentes.ClsButtonConsultas ConsultasBtnRefrescar;
        private Componentes.UsrLabelConsultas ConsultasUsrOperador;
        private Componentes.UsrLabelConsultas ConsultasUsrEtiquetaValor;
        private Componentes.UsrLabelConsultas ConsultasUsrCampo;
        private Componentes.ClsComboBoxConsultas ConsultasCboCampo;
        private Componentes.ClsComboBoxConsultas ConsultasCboOperador;
        private Componentes.UsrTextBoxConsultas ConsultasUsrValor;
        private Componentes.ClsButtonConsultas ConsultasBtnBuscar;
        private Componentes.ClsGroupBoxConsultas ConsultasGbxSeleccioneUnRegistro;
        private UsrTabla ConsultasUsrTabla;
    }
}
