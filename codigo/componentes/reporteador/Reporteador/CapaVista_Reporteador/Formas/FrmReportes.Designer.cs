namespace CapaVista_Reporteador
{
    partial class FrmReportes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportes));
            this.ReporteadorLblRutaReporte = new System.Windows.Forms.Label();
            this.ReporteadorLblNombreReporte = new System.Windows.Forms.Label();
            this.ReporteadorLblAplicacionReporte = new System.Windows.Forms.Label();
            this.ReporteadorLblDatosBuscarReporte = new System.Windows.Forms.Label();
            this.ReporteadorTxtRutaReporte = new System.Windows.Forms.TextBox();
            this.ReporteadorTxtNombreReporte = new System.Windows.Forms.TextBox();
            this.ReporteadorCboAplicacionReporte = new System.Windows.Forms.ComboBox();
            this.ReporteadorDgvReportes = new System.Windows.Forms.DataGridView();
            this.ReporteadorPnlFiltroBuscarReporte = new System.Windows.Forms.Panel();
            this.ReporteadorChkNombreReporte = new System.Windows.Forms.CheckBox();
            this.ReporteadorChkFechaReporte = new System.Windows.Forms.CheckBox();
            this.ReporteadorTxtFiltroNombreReporte = new System.Windows.Forms.TextBox();
            this.ReporteadorDtpFechaReporte = new System.Windows.Forms.DateTimePicker();
            this.ReporteadorBtnActualizar = new CapaVista_BtnActualizar_Reporteador.ReporteadorUcActualizar();
            this.ReporteadorBtnBusqueda = new CapaVista_BtnBusqueda_Reporteador.ReporteadorUcBusqueda();
            this.ReporteadorBtnEditar = new CapaVista_BtnEditar_Reporteador.ReporteadorUcEditar();
            this.ReporteadorBtnEliminar = new CapaVista_BtnEliminar_Reporteador.ReporteadorUcEliminar();
            this.ReporteadorBtnLimpiar = new CapaVista_BtnLimpiar_Reporteador.ReporteadorUcLimpiar();
            this.ReporteadorBtnGuardar = new CapaVista_BtnGuardar_Reporteador.ReporteadorUcGuardar();
            this.ReporteadorBtnRuta = new CapaVista_BtnRuta_Reporteador.ReporteadorUcRutaReporte();
            this.ReporteadorBtnAyuda = new System.Windows.Forms.Button();
            this.ReporteadorPbLogo = new System.Windows.Forms.PictureBox();
            this.ReporteadorPbFooter = new System.Windows.Forms.PictureBox();
            this.ReporteadorPbBanner = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteadorDgvReportes)).BeginInit();
            this.ReporteadorPnlFiltroBuscarReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteadorPbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteadorPbFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteadorPbBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // ReporteadorLblRutaReporte
            // 
            this.ReporteadorLblRutaReporte.AutoSize = true;
            this.ReporteadorLblRutaReporte.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReporteadorLblRutaReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(87)))), ((int)(((byte)(91)))));
            this.ReporteadorLblRutaReporte.Location = new System.Drawing.Point(28, 123);
            this.ReporteadorLblRutaReporte.Name = "ReporteadorLblRutaReporte";
            this.ReporteadorLblRutaReporte.Size = new System.Drawing.Size(151, 21);
            this.ReporteadorLblRutaReporte.TabIndex = 3;
            this.ReporteadorLblRutaReporte.Text = "Ruta del reporte: *";
            // 
            // ReporteadorLblNombreReporte
            // 
            this.ReporteadorLblNombreReporte.AutoSize = true;
            this.ReporteadorLblNombreReporte.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReporteadorLblNombreReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(87)))), ((int)(((byte)(91)))));
            this.ReporteadorLblNombreReporte.Location = new System.Drawing.Point(28, 174);
            this.ReporteadorLblNombreReporte.Name = "ReporteadorLblNombreReporte";
            this.ReporteadorLblNombreReporte.Size = new System.Drawing.Size(174, 21);
            this.ReporteadorLblNombreReporte.TabIndex = 4;
            this.ReporteadorLblNombreReporte.Text = "Nombre del reporte: *";
            // 
            // ReporteadorLblAplicacionReporte
            // 
            this.ReporteadorLblAplicacionReporte.AutoSize = true;
            this.ReporteadorLblAplicacionReporte.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReporteadorLblAplicacionReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(87)))), ((int)(((byte)(91)))));
            this.ReporteadorLblAplicacionReporte.Location = new System.Drawing.Point(28, 225);
            this.ReporteadorLblAplicacionReporte.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ReporteadorLblAplicacionReporte.Name = "ReporteadorLblAplicacionReporte";
            this.ReporteadorLblAplicacionReporte.Size = new System.Drawing.Size(105, 21);
            this.ReporteadorLblAplicacionReporte.TabIndex = 28;
            this.ReporteadorLblAplicacionReporte.Text = "Aplicación: *";
            // 
            // ReporteadorLblDatosBuscarReporte
            // 
            this.ReporteadorLblDatosBuscarReporte.AutoSize = true;
            this.ReporteadorLblDatosBuscarReporte.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReporteadorLblDatosBuscarReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(87)))), ((int)(((byte)(91)))));
            this.ReporteadorLblDatosBuscarReporte.Location = new System.Drawing.Point(28, 327);
            this.ReporteadorLblDatosBuscarReporte.Name = "ReporteadorLblDatosBuscarReporte";
            this.ReporteadorLblDatosBuscarReporte.Size = new System.Drawing.Size(211, 21);
            this.ReporteadorLblDatosBuscarReporte.TabIndex = 5;
            this.ReporteadorLblDatosBuscarReporte.Text = "Datos para buscar reporte:";
            // 
            // ReporteadorTxtRutaReporte
            // 
            this.ReporteadorTxtRutaReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReporteadorTxtRutaReporte.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReporteadorTxtRutaReporte.Location = new System.Drawing.Point(219, 113);
            this.ReporteadorTxtRutaReporte.Name = "ReporteadorTxtRutaReporte";
            this.ReporteadorTxtRutaReporte.Size = new System.Drawing.Size(480, 33);
            this.ReporteadorTxtRutaReporte.TabIndex = 6;
            // 
            // ReporteadorTxtNombreReporte
            // 
            this.ReporteadorTxtNombreReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReporteadorTxtNombreReporte.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReporteadorTxtNombreReporte.Location = new System.Drawing.Point(219, 164);
            this.ReporteadorTxtNombreReporte.Name = "ReporteadorTxtNombreReporte";
            this.ReporteadorTxtNombreReporte.Size = new System.Drawing.Size(480, 33);
            this.ReporteadorTxtNombreReporte.TabIndex = 7;
            // 
            // ReporteadorCboAplicacionReporte
            // 
            this.ReporteadorCboAplicacionReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ReporteadorCboAplicacionReporte.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReporteadorCboAplicacionReporte.FormattingEnabled = true;
            this.ReporteadorCboAplicacionReporte.Location = new System.Drawing.Point(219, 214);
            this.ReporteadorCboAplicacionReporte.Margin = new System.Windows.Forms.Padding(2);
            this.ReporteadorCboAplicacionReporte.Name = "ReporteadorCboAplicacionReporte";
            this.ReporteadorCboAplicacionReporte.Size = new System.Drawing.Size(480, 33);
            this.ReporteadorCboAplicacionReporte.TabIndex = 29;
            // 
            // ReporteadorDgvReportes
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(230)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(118)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(230)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ReporteadorDgvReportes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ReporteadorDgvReportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ReporteadorDgvReportes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(230)))), ((int)(((byte)(214)))));
            this.ReporteadorDgvReportes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(87)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(230)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(87)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(230)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ReporteadorDgvReportes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ReporteadorDgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(87)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(118)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(230)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ReporteadorDgvReportes.DefaultCellStyle = dataGridViewCellStyle3;
            this.ReporteadorDgvReportes.EnableHeadersVisualStyles = false;
            this.ReporteadorDgvReportes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(118)))), ((int)(((byte)(63)))));
            this.ReporteadorDgvReportes.Location = new System.Drawing.Point(32, 425);
            this.ReporteadorDgvReportes.Name = "ReporteadorDgvReportes";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(87)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(118)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(230)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ReporteadorDgvReportes.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ReporteadorDgvReportes.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.ReporteadorDgvReportes.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ReporteadorDgvReportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ReporteadorDgvReportes.Size = new System.Drawing.Size(654, 144);
            this.ReporteadorDgvReportes.TabIndex = 8;
            // 
            // ReporteadorPnlFiltroBuscarReporte
            // 
            this.ReporteadorPnlFiltroBuscarReporte.Controls.Add(this.ReporteadorChkNombreReporte);
            this.ReporteadorPnlFiltroBuscarReporte.Controls.Add(this.ReporteadorChkFechaReporte);
            this.ReporteadorPnlFiltroBuscarReporte.Controls.Add(this.ReporteadorTxtFiltroNombreReporte);
            this.ReporteadorPnlFiltroBuscarReporte.Controls.Add(this.ReporteadorDtpFechaReporte);
            this.ReporteadorPnlFiltroBuscarReporte.Location = new System.Drawing.Point(32, 342);
            this.ReporteadorPnlFiltroBuscarReporte.Name = "ReporteadorPnlFiltroBuscarReporte";
            this.ReporteadorPnlFiltroBuscarReporte.Size = new System.Drawing.Size(462, 88);
            this.ReporteadorPnlFiltroBuscarReporte.TabIndex = 13;
            // 
            // ReporteadorChkNombreReporte
            // 
            this.ReporteadorChkNombreReporte.AutoSize = true;
            this.ReporteadorChkNombreReporte.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReporteadorChkNombreReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(87)))), ((int)(((byte)(91)))));
            this.ReporteadorChkNombreReporte.Location = new System.Drawing.Point(20, 10);
            this.ReporteadorChkNombreReporte.Name = "ReporteadorChkNombreReporte";
            this.ReporteadorChkNombreReporte.Size = new System.Drawing.Size(181, 27);
            this.ReporteadorChkNombreReporte.TabIndex = 9;
            this.ReporteadorChkNombreReporte.Text = "Nombre del reporte";
            this.ReporteadorChkNombreReporte.UseVisualStyleBackColor = true;
            // 
            // ReporteadorChkFechaReporte
            // 
            this.ReporteadorChkFechaReporte.AutoSize = true;
            this.ReporteadorChkFechaReporte.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReporteadorChkFechaReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(87)))), ((int)(((byte)(91)))));
            this.ReporteadorChkFechaReporte.Location = new System.Drawing.Point(271, 10);
            this.ReporteadorChkFechaReporte.Name = "ReporteadorChkFechaReporte";
            this.ReporteadorChkFechaReporte.Size = new System.Drawing.Size(162, 27);
            this.ReporteadorChkFechaReporte.TabIndex = 10;
            this.ReporteadorChkFechaReporte.Text = "Fecha del reporte";
            this.ReporteadorChkFechaReporte.UseVisualStyleBackColor = true;
            // 
            // ReporteadorTxtFiltroNombreReporte
            // 
            this.ReporteadorTxtFiltroNombreReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReporteadorTxtFiltroNombreReporte.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReporteadorTxtFiltroNombreReporte.Location = new System.Drawing.Point(20, 43);
            this.ReporteadorTxtFiltroNombreReporte.Name = "ReporteadorTxtFiltroNombreReporte";
            this.ReporteadorTxtFiltroNombreReporte.Size = new System.Drawing.Size(214, 33);
            this.ReporteadorTxtFiltroNombreReporte.TabIndex = 11;
            // 
            // ReporteadorDtpFechaReporte
            // 
            this.ReporteadorDtpFechaReporte.CalendarFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ReporteadorDtpFechaReporte.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(87)))), ((int)(((byte)(91)))));
            this.ReporteadorDtpFechaReporte.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(230)))), ((int)(((byte)(214)))));
            this.ReporteadorDtpFechaReporte.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(118)))), ((int)(((byte)(63)))));
            this.ReporteadorDtpFechaReporte.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.ReporteadorDtpFechaReporte.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ReporteadorDtpFechaReporte.Location = new System.Drawing.Point(271, 42);
            this.ReporteadorDtpFechaReporte.MaxDate = new System.DateTime(2026, 12, 31, 0, 0, 0, 0);
            this.ReporteadorDtpFechaReporte.MinDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.ReporteadorDtpFechaReporte.Name = "ReporteadorDtpFechaReporte";
            this.ReporteadorDtpFechaReporte.Size = new System.Drawing.Size(162, 31);
            this.ReporteadorDtpFechaReporte.TabIndex = 12;
            // 
            // ReporteadorBtnActualizar
            // 
            this.ReporteadorBtnActualizar.BackColor = System.Drawing.Color.Transparent;
            this.ReporteadorBtnActualizar.DgvReportes = null;
            this.ReporteadorBtnActualizar.Location = new System.Drawing.Point(605, 362);
            this.ReporteadorBtnActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.ReporteadorBtnActualizar.Name = "ReporteadorBtnActualizar";
            this.ReporteadorBtnActualizar.Size = new System.Drawing.Size(56, 56);
            this.ReporteadorBtnActualizar.TabIndex = 17;
            // 
            // ReporteadorBtnBusqueda
            // 
            this.ReporteadorBtnBusqueda.BackColor = System.Drawing.Color.Transparent;
            this.ReporteadorBtnBusqueda.ChkFechaReporte = null;
            this.ReporteadorBtnBusqueda.ChkNombreReporte = null;
            this.ReporteadorBtnBusqueda.DgvReportes = null;
            this.ReporteadorBtnBusqueda.DtpFechaReporte = null;
            this.ReporteadorBtnBusqueda.Location = new System.Drawing.Point(511, 362);
            this.ReporteadorBtnBusqueda.Margin = new System.Windows.Forms.Padding(4);
            this.ReporteadorBtnBusqueda.Name = "ReporteadorBtnBusqueda";
            this.ReporteadorBtnBusqueda.Size = new System.Drawing.Size(56, 56);
            this.ReporteadorBtnBusqueda.TabIndex = 18;
            this.ReporteadorBtnBusqueda.TxtNombreReporte = null;
            // 
            // ReporteadorBtnEditar
            // 
            this.ReporteadorBtnEditar.BackColor = System.Drawing.Color.Transparent;
            this.ReporteadorBtnEditar.Location = new System.Drawing.Point(113, 257);
            this.ReporteadorBtnEditar.Margin = new System.Windows.Forms.Padding(4);
            this.ReporteadorBtnEditar.Name = "ReporteadorBtnEditar";
            this.ReporteadorBtnEditar.ReporteadorTxtNombreReporte = null;
            this.ReporteadorBtnEditar.ReporteadorTxtRutaReporte = null;
            this.ReporteadorBtnEditar.Size = new System.Drawing.Size(56, 56);
            this.ReporteadorBtnEditar.TabIndex = 19;
            // 
            // ReporteadorBtnEliminar
            // 
            this.ReporteadorBtnEliminar.BackColor = System.Drawing.Color.Transparent;
            this.ReporteadorBtnEliminar.GridReportes = null;
            this.ReporteadorBtnEliminar.Location = new System.Drawing.Point(195, 257);
            this.ReporteadorBtnEliminar.Margin = new System.Windows.Forms.Padding(0);
            this.ReporteadorBtnEliminar.Name = "ReporteadorBtnEliminar";
            this.ReporteadorBtnEliminar.Size = new System.Drawing.Size(56, 56);
            this.ReporteadorBtnEliminar.TabIndex = 20;
            this.ReporteadorBtnEliminar.TxtNombreReporte = null;
            this.ReporteadorBtnEliminar.TxtRutaReporte = null;
            // 
            // ReporteadorBtnLimpiar
            // 
            this.ReporteadorBtnLimpiar.BackColor = System.Drawing.Color.Transparent;
            this.ReporteadorBtnLimpiar.Location = new System.Drawing.Point(276, 257);
            this.ReporteadorBtnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.ReporteadorBtnLimpiar.Name = "ReporteadorBtnLimpiar";
            this.ReporteadorBtnLimpiar.Size = new System.Drawing.Size(56, 56);
            this.ReporteadorBtnLimpiar.TabIndex = 21;
            // 
            // ReporteadorBtnGuardar
            // 
            this.ReporteadorBtnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.ReporteadorBtnGuardar.Location = new System.Drawing.Point(32, 257);
            this.ReporteadorBtnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.ReporteadorBtnGuardar.MaximumSize = new System.Drawing.Size(56, 56);
            this.ReporteadorBtnGuardar.MinimumSize = new System.Drawing.Size(56, 56);
            this.ReporteadorBtnGuardar.Name = "ReporteadorBtnGuardar";
            this.ReporteadorBtnGuardar.Size = new System.Drawing.Size(56, 56);
            this.ReporteadorBtnGuardar.TabIndex = 22;
            // 
            // ReporteadorBtnRuta
            // 
            this.ReporteadorBtnRuta.BackColor = System.Drawing.Color.Transparent;
            this.ReporteadorBtnRuta.CampoTextoRuta = null;
            this.ReporteadorBtnRuta.Location = new System.Drawing.Point(705, 113);
            this.ReporteadorBtnRuta.Margin = new System.Windows.Forms.Padding(4);
            this.ReporteadorBtnRuta.Name = "ReporteadorBtnRuta";
            this.ReporteadorBtnRuta.Size = new System.Drawing.Size(56, 56);
            this.ReporteadorBtnRuta.TabIndex = 24;
            // 
            // ReporteadorBtnAyuda
            // 
            this.ReporteadorBtnAyuda.BackColor = System.Drawing.Color.Transparent;
            this.ReporteadorBtnAyuda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReporteadorBtnAyuda.FlatAppearance.BorderSize = 0;
            this.ReporteadorBtnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReporteadorBtnAyuda.Image = global::CapaVista_Reporteador.Properties.Resources.btn_ayuda;
            this.ReporteadorBtnAyuda.Location = new System.Drawing.Point(795, 12);
            this.ReporteadorBtnAyuda.Name = "ReporteadorBtnAyuda";
            this.ReporteadorBtnAyuda.Size = new System.Drawing.Size(56, 56);
            this.ReporteadorBtnAyuda.TabIndex = 26;
            this.ReporteadorBtnAyuda.UseVisualStyleBackColor = false;
            this.ReporteadorBtnAyuda.Click += new System.EventHandler(this.ReporteadorMetMostrarAyuda);
            // 
            // ReporteadorPbLogo
            // 
            this.ReporteadorPbLogo.Image = global::CapaVista_Reporteador.Properties.Resources.img_mascota;
            this.ReporteadorPbLogo.Location = new System.Drawing.Point(667, 259);
            this.ReporteadorPbLogo.Name = "ReporteadorPbLogo";
            this.ReporteadorPbLogo.Size = new System.Drawing.Size(195, 210);
            this.ReporteadorPbLogo.TabIndex = 2;
            this.ReporteadorPbLogo.TabStop = false;
            // 
            // ReporteadorPbFooter
            // 
            this.ReporteadorPbFooter.Image = global::CapaVista_Reporteador.Properties.Resources.Footer_reporteador;
            this.ReporteadorPbFooter.Location = new System.Drawing.Point(-6, 574);
            this.ReporteadorPbFooter.MaximumSize = new System.Drawing.Size(890, 110);
            this.ReporteadorPbFooter.MinimumSize = new System.Drawing.Size(890, 110);
            this.ReporteadorPbFooter.Name = "ReporteadorPbFooter";
            this.ReporteadorPbFooter.Size = new System.Drawing.Size(890, 110);
            this.ReporteadorPbFooter.TabIndex = 1;
            this.ReporteadorPbFooter.TabStop = false;
            // 
            // ReporteadorPbBanner
            // 
            this.ReporteadorPbBanner.Image = global::CapaVista_Reporteador.Properties.Resources.banner_Reporteador;
            this.ReporteadorPbBanner.Location = new System.Drawing.Point(-6, -3);
            this.ReporteadorPbBanner.MaximumSize = new System.Drawing.Size(890, 110);
            this.ReporteadorPbBanner.MinimumSize = new System.Drawing.Size(890, 110);
            this.ReporteadorPbBanner.Name = "ReporteadorPbBanner";
            this.ReporteadorPbBanner.Size = new System.Drawing.Size(890, 110);
            this.ReporteadorPbBanner.TabIndex = 0;
            this.ReporteadorPbBanner.TabStop = false;
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(230)))), ((int)(((byte)(214)))));
            this.ClientSize = new System.Drawing.Size(874, 681);
            this.Controls.Add(this.ReporteadorCboAplicacionReporte);
            this.Controls.Add(this.ReporteadorLblAplicacionReporte);
            this.Controls.Add(this.ReporteadorBtnAyuda);
            this.Controls.Add(this.ReporteadorBtnRuta);
            this.Controls.Add(this.ReporteadorBtnGuardar);
            this.Controls.Add(this.ReporteadorBtnLimpiar);
            this.Controls.Add(this.ReporteadorBtnEliminar);
            this.Controls.Add(this.ReporteadorBtnEditar);
            this.Controls.Add(this.ReporteadorBtnBusqueda);
            this.Controls.Add(this.ReporteadorBtnActualizar);
            this.Controls.Add(this.ReporteadorDgvReportes);
            this.Controls.Add(this.ReporteadorTxtNombreReporte);
            this.Controls.Add(this.ReporteadorTxtRutaReporte);
            this.Controls.Add(this.ReporteadorLblDatosBuscarReporte);
            this.Controls.Add(this.ReporteadorLblNombreReporte);
            this.Controls.Add(this.ReporteadorLblRutaReporte);
            this.Controls.Add(this.ReporteadorPbLogo);
            this.Controls.Add(this.ReporteadorPbFooter);
            this.Controls.Add(this.ReporteadorPbBanner);
            this.Controls.Add(this.ReporteadorPnlFiltroBuscarReporte);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(890, 720);
            this.MinimumSize = new System.Drawing.Size(890, 591);
            this.Name = "FrmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3001 – ListaReportes";
            ((System.ComponentModel.ISupportInitialize)(this.ReporteadorDgvReportes)).EndInit();
            this.ReporteadorPnlFiltroBuscarReporte.ResumeLayout(false);
            this.ReporteadorPnlFiltroBuscarReporte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteadorPbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteadorPbFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteadorPbBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ReporteadorPbBanner;
        private System.Windows.Forms.PictureBox ReporteadorPbFooter;
        private System.Windows.Forms.PictureBox ReporteadorPbLogo;
        private System.Windows.Forms.Label ReporteadorLblRutaReporte;
        private System.Windows.Forms.Label ReporteadorLblNombreReporte;
        private System.Windows.Forms.Label ReporteadorLblAplicacionReporte;
        private System.Windows.Forms.Label ReporteadorLblDatosBuscarReporte;
        private System.Windows.Forms.TextBox ReporteadorTxtRutaReporte;
        private System.Windows.Forms.TextBox ReporteadorTxtNombreReporte;
        private System.Windows.Forms.ComboBox ReporteadorCboAplicacionReporte;
        private System.Windows.Forms.DataGridView ReporteadorDgvReportes;
        private System.Windows.Forms.CheckBox ReporteadorChkNombreReporte;
        private System.Windows.Forms.CheckBox ReporteadorChkFechaReporte;
        private System.Windows.Forms.TextBox ReporteadorTxtFiltroNombreReporte;
        private System.Windows.Forms.DateTimePicker ReporteadorDtpFechaReporte;
        private System.Windows.Forms.Panel ReporteadorPnlFiltroBuscarReporte;
        private CapaVista_BtnActualizar_Reporteador.ReporteadorUcActualizar ReporteadorBtnActualizar;
        private CapaVista_BtnBusqueda_Reporteador.ReporteadorUcBusqueda ReporteadorBtnBusqueda;
        private CapaVista_BtnEditar_Reporteador.ReporteadorUcEditar ReporteadorBtnEditar;
        private CapaVista_BtnEliminar_Reporteador.ReporteadorUcEliminar ReporteadorBtnEliminar;
        private CapaVista_BtnLimpiar_Reporteador.ReporteadorUcLimpiar ReporteadorBtnLimpiar;
        private CapaVista_BtnGuardar_Reporteador.ReporteadorUcGuardar ReporteadorBtnGuardar;
        private CapaVista_BtnRuta_Reporteador.ReporteadorUcRutaReporte ReporteadorBtnRuta;
        private System.Windows.Forms.Button ReporteadorBtnAyuda;
    }
}