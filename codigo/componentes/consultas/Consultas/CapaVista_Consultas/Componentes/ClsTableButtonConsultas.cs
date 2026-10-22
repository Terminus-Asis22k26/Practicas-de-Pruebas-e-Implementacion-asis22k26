using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaVista_Consultas.Componentes
{
    internal class ClsTableButtonConsultas : Button
    {
        /*Inicio de código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
        private static readonly Color _Primario = ColorTranslator.FromHtml("#2E4A63");
        private static readonly Color _Secundario = ColorTranslator.FromHtml("#4E8078");
        private bool _EsActivo;

        public bool EsActivo
        {
            get => _EsActivo;
            set
            {
                _EsActivo = value;
                ConsultasProcActualizarEstado();
            }
        }

        public ClsTableButtonConsultas()
        {
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Size = new Size(36, 30);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = _Primario;
            ForeColor = Color.White;
            Cursor = Cursors.Hand;
            UseVisualStyleBackColor = false;
            TextAlign = ContentAlignment.MiddleCenter;
            Margin = new Padding(2);
        }

        protected override Size DefaultSize => new Size(36, 30);

        protected override void OnMouseEnter(EventArgs Evento)
        {
            base.OnMouseEnter(Evento);

            if (!EsActivo)
            {
                BackColor = _Secundario;
                ForeColor = Color.White;
            }
        }

        protected override void OnMouseLeave(EventArgs Evento)
        {
            base.OnMouseLeave(Evento);
            ConsultasProcActualizarEstado();
        }

        protected override void OnEnabledChanged(EventArgs Evento)
        {
            base.OnEnabledChanged(Evento);
            Cursor = Enabled ? Cursors.Hand : Cursors.Default;
            ForeColor = Color.White;
        }

        private void ConsultasProcActualizarEstado()
        {
            BackColor = EsActivo ? _Secundario : _Primario;
            ForeColor = Color.White;
            if (Font.Name != "Segoe UI" || Font.Size != 9F || Font.Style != FontStyle.Regular || Font.Unit != GraphicsUnit.Point) Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        }
        /*Fin del código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
    }
}