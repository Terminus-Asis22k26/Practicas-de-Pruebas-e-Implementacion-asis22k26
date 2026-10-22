namespace CapaVista_Consultas.Componentes
{
    partial class UsrBaseConsultas
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
            this.SuspendLayout();
            // 
            // UsrBaseConsultas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(218)))));
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(1150, 750);
            this.Name = "UsrBaseConsultas";
            this.Size = new System.Drawing.Size(1150, 750);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
