using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CapaVista_Consultas.Componentes
{
    public partial class UsrDataGridViewConsultas : UserControl
    {
        /*Inicio del código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
        private int _FilaHover = -1;
        private bool _ResaltarFilasAlPasar;
        private Cursor _CursorHabitual;

        [Category("Comportamiento")]
        [DefaultValue(false)]
        public bool ResaltarFilasAlPasar
        {
            get { return _ResaltarFilasAlPasar; }
            set { _ResaltarFilasAlPasar = value; ConsultasProcHover(-1); }
        }

        private void ConsultasProcHover(int Fila)
        {
            int Anterior = _FilaHover;
            _FilaHover = Fila;
            ConsultasDgvMain.Cursor = Fila >= 0 ? Cursors.Hand : _CursorHabitual;
            if (Anterior >= 0 && Anterior < ConsultasDgvMain.Rows.Count) ConsultasDgvMain.InvalidateRow(Anterior);
            if (Fila >= 0 && Fila < ConsultasDgvMain.Rows.Count) ConsultasDgvMain.InvalidateRow(Fila);
        }

        private const int _AlturaMinimaFila = 28;
        private const int _AlturaMaximaFila = 40;

        public UsrDataGridViewConsultas()
        {
            InitializeComponent();
            _CursorHabitual = ConsultasDgvMain.Cursor;
            ConsultasDgvMain.MouseMove += (Sender, Evento) =>
            {
                DataGridView.HitTestInfo Zona = ConsultasDgvMain.HitTest(Evento.X, Evento.Y);
                int Fila = ResaltarFilasAlPasar && Zona.Type == DataGridViewHitTestType.Cell && Zona.RowIndex >= 0 && !ConsultasDgvMain.Rows[Zona.RowIndex].IsNewRow ? Zona.RowIndex : -1;
                if (_FilaHover != Fila) ConsultasProcHover(Fila);
            };
            ConsultasDgvMain.MouseLeave += (Sender, Evento) => ConsultasProcHover(-1);
            ConsultasDgvMain.DataBindingComplete += (Sender, Evento) => ConsultasProcHover(-1);
            ConsultasDgvMain.CellPainting += (Sender, Evento) =>
            {
                if (ResaltarFilasAlPasar && Evento.RowIndex == _FilaHover && Evento.RowIndex >= 0 && Evento.ColumnIndex >= 0)
                {
                    System.Drawing.Color Fondo = Evento.CellStyle.BackColor;
                    System.Drawing.Color Texto = Evento.CellStyle.ForeColor;
                    try
                    {
                        Evento.CellStyle.BackColor = Evento.CellStyle.SelectionBackColor;
                        Evento.CellStyle.ForeColor = Evento.CellStyle.SelectionForeColor;
                        Evento.Paint(Evento.ClipBounds, Evento.PaintParts);
                        Evento.Handled = true;
                    }
                    finally
                    {
                        Evento.CellStyle.BackColor = Fondo;
                        Evento.CellStyle.ForeColor = Texto;
                    }
                }
            };

            ConsultasDgvMain.Resize += ConsultasMetActualizarAlturaFilas;
            ConsultasDgvMain.RowsAdded += ConsultasMetFilasAgregadas;
            ConsultasDgvMain.RowsRemoved += ConsultasMetFilasEliminadas;
            ConsultasDgvMain.DataBindingComplete += ConsultasMetEnlaceCompletado;
            ConsultasDgvMain.HandleCreated += ConsultasMetTablaCreada;

            ConsultasProcActivarDobleBuffer();
        }

        private void ConsultasMetTablaCreada(object Remitente, EventArgs Evento)
        {
            ConsultasProcActivarDobleBuffer();
            ConsultasProcAjustarAlturaFilas();
        }
        private void ConsultasProcActivarDobleBuffer()
        {
            System.Reflection.PropertyInfo PropiedadDobleBuffer =
                typeof(DataGridView).GetProperty(
                    "DoubleBuffered",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic);

            if (PropiedadDobleBuffer != null)
            {
                PropiedadDobleBuffer.SetValue(ConsultasDgvMain, true, null);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridView Tabla
        {
            get { return ConsultasDgvMain; }
        }

        [Category("Datos")]
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue(null)]
        public object DataSource
        {
            get { return ConsultasDgvMain.DataSource; }
            set { ConsultasDgvMain.DataSource = value; }
        }

        [Category("Datos")]
        [DefaultValue("")]
        public string DataMember
        {
            get { return ConsultasDgvMain.DataMember; }
            set { ConsultasDgvMain.DataMember = value; }
        }

        [Category("Datos")]
        [DefaultValue(true)]
        public bool AutoGenerateColumns
        {
            get { return ConsultasDgvMain.AutoGenerateColumns; }
            set { ConsultasDgvMain.AutoGenerateColumns = value; }
        }

        [Category("Comportamiento")]
        [DefaultValue(true)]
        public bool ReadOnly
        {
            get { return ConsultasDgvMain.ReadOnly; }
            set { ConsultasDgvMain.ReadOnly = value; }
        }

        [Category("Comportamiento")]
        [DefaultValue(false)]
        public bool AllowUserToAddRows
        {
            get { return ConsultasDgvMain.AllowUserToAddRows; }
            set { ConsultasDgvMain.AllowUserToAddRows = value; }
        }

        [Category("Comportamiento")]
        [DefaultValue(false)]
        public bool AllowUserToDeleteRows
        {
            get { return ConsultasDgvMain.AllowUserToDeleteRows; }
            set { ConsultasDgvMain.AllowUserToDeleteRows = value; }
        }

        [Category("Comportamiento")]
        [DefaultValue(false)]
        public bool AllowUserToResizeRows
        {
            get { return ConsultasDgvMain.AllowUserToResizeRows; }
            set { ConsultasDgvMain.AllowUserToResizeRows = value; }
        }

        [Category("Comportamiento")]
        [DefaultValue(false)]
        public bool MultiSelect
        {
            get { return ConsultasDgvMain.MultiSelect; }
            set { ConsultasDgvMain.MultiSelect = value; }
        }

        [Category("Comportamiento")]
        [DefaultValue(DataGridViewSelectionMode.FullRowSelect)]
        public DataGridViewSelectionMode SelectionMode
        {
            get { return ConsultasDgvMain.SelectionMode; }
            set { ConsultasDgvMain.SelectionMode = value; }
        }

        [Category("Comportamiento")]
        [DefaultValue(DataGridViewEditMode.EditProgrammatically)]
        public DataGridViewEditMode EditMode
        {
            get { return ConsultasDgvMain.EditMode; }
            set { ConsultasDgvMain.EditMode = value; }
        }

        [Category("Apariencia")]
        [DefaultValue(DataGridViewAutoSizeColumnsMode.Fill)]
        public DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode
        {
            get { return ConsultasDgvMain.AutoSizeColumnsMode; }
            set { ConsultasDgvMain.AutoSizeColumnsMode = value; }
        }

        [Category("Apariencia")]
        [DefaultValue(false)]
        public bool RowHeadersVisible
        {
            get { return ConsultasDgvMain.RowHeadersVisible; }
            set { ConsultasDgvMain.RowHeadersVisible = value; }
        }

        [Category("Apariencia")]
        [DefaultValue(true)]
        public bool ColumnHeadersVisible
        {
            get { return ConsultasDgvMain.ColumnHeadersVisible; }
            set
            {
                ConsultasDgvMain.ColumnHeadersVisible = value;
                ConsultasProcAjustarAlturaFilas();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewColumnCollection Columns
        {
            get { return ConsultasDgvMain.Columns; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewRowCollection Rows
        {
            get { return ConsultasDgvMain.Rows; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewSelectedRowCollection SelectedRows
        {
            get { return ConsultasDgvMain.SelectedRows; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewSelectedCellCollection SelectedCells
        {
            get { return ConsultasDgvMain.SelectedCells; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewRow CurrentRow
        {
            get { return ConsultasDgvMain.CurrentRow; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewCell CurrentCell
        {
            get { return ConsultasDgvMain.CurrentCell; }
            set { ConsultasDgvMain.CurrentCell = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int RowCount
        {
            get { return ConsultasDgvMain.RowCount; }
            set { ConsultasDgvMain.RowCount = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ColumnCount
        {
            get { return ConsultasDgvMain.ColumnCount; }
            set { ConsultasDgvMain.ColumnCount = value; }
        }

        public DataGridViewCell this[int IndiceColumna, int IndiceFila]
        {
            get { return ConsultasDgvMain[IndiceColumna, IndiceFila]; }
            set { ConsultasDgvMain[IndiceColumna, IndiceFila] = value; }
        }

        public DataGridViewCell this[string NombreColumna, int IndiceFila]
        {
            get { return ConsultasDgvMain[NombreColumna, IndiceFila]; }
            set { ConsultasDgvMain[NombreColumna, IndiceFila] = value; }
        }

        [Category("Acción")]
        public event DataGridViewCellEventHandler CellClick
        {
            add { ConsultasDgvMain.CellClick += value; }
            remove { ConsultasDgvMain.CellClick -= value; }
        }

        [Category("Acción")]
        public event DataGridViewCellEventHandler CellDoubleClick
        {
            add { ConsultasDgvMain.CellDoubleClick += value; }
            remove { ConsultasDgvMain.CellDoubleClick -= value; }
        }

        [Category("Acción")]
        public event DataGridViewCellEventHandler CellContentClick
        {
            add { ConsultasDgvMain.CellContentClick += value; }
            remove { ConsultasDgvMain.CellContentClick -= value; }
        }

        [Category("Acción")]
        public event EventHandler SelectionChanged
        {
            add { ConsultasDgvMain.SelectionChanged += value; }
            remove { ConsultasDgvMain.SelectionChanged -= value; }
        }

        [Category("Datos")]
        public event DataGridViewBindingCompleteEventHandler DataBindingComplete
        {
            add { ConsultasDgvMain.DataBindingComplete += value; }
            remove { ConsultasDgvMain.DataBindingComplete -= value; }
        }

        [Category("Datos")]
        public event DataGridViewRowsAddedEventHandler RowsAdded
        {
            add { ConsultasDgvMain.RowsAdded += value; }
            remove { ConsultasDgvMain.RowsAdded -= value; }
        }

        [Category("Datos")]
        public event DataGridViewRowsRemovedEventHandler RowsRemoved
        {
            add { ConsultasDgvMain.RowsRemoved += value; }
            remove { ConsultasDgvMain.RowsRemoved -= value; }
        }

        [Category("Datos")]
        public event DataGridViewCellEventHandler CellValueChanged
        {
            add { ConsultasDgvMain.CellValueChanged += value; }
            remove { ConsultasDgvMain.CellValueChanged -= value; }
        }

        [Category("Datos")]
        public event DataGridViewCellValidatingEventHandler CellValidating
        {
            add { ConsultasDgvMain.CellValidating += value; }
            remove { ConsultasDgvMain.CellValidating -= value; }
        }

        [Category("Datos")]
        public event DataGridViewDataErrorEventHandler DataError
        {
            add { ConsultasDgvMain.DataError += value; }
            remove { ConsultasDgvMain.DataError -= value; }
        }

        [Category("Teclado")]
        public new event KeyEventHandler KeyDown
        {
            add { ConsultasDgvMain.KeyDown += value; }
            remove { ConsultasDgvMain.KeyDown -= value; }
        }

        [Category("Teclado")]
        public new event KeyPressEventHandler KeyPress
        {
            add { ConsultasDgvMain.KeyPress += value; }
            remove { ConsultasDgvMain.KeyPress -= value; }
        }

        [Category("Teclado")]
        public new event KeyEventHandler KeyUp
        {
            add { ConsultasDgvMain.KeyUp += value; }
            remove { ConsultasDgvMain.KeyUp -= value; }
        }

        public void ConsultasProcLimpiarSeleccion()
        {
            ConsultasDgvMain.ClearSelection();
        }

        public bool ConsultasFuncIniciarEdicion(bool SeleccionarTodo)
        {
            return ConsultasDgvMain.BeginEdit(SeleccionarTodo);
        }

        public bool ConsultasFuncFinalizarEdicion()
        {
            return ConsultasDgvMain.EndEdit();
        }

        public bool ConsultasFuncCancelarEdicion()
        {
            return ConsultasDgvMain.CancelEdit();
        }

        public void ConsultasProcEnfocarTabla()
        {
            ConsultasDgvMain.Focus();
        }

        private void ConsultasMetActualizarAlturaFilas(object Remitente, EventArgs Evento)
        {
            ConsultasProcAjustarAlturaFilas();
        }

        private void ConsultasMetFilasAgregadas(object Remitente, DataGridViewRowsAddedEventArgs Evento)
        {
            ConsultasProcAjustarAlturaFilas();
        }

        private void ConsultasMetFilasEliminadas(object Remitente, DataGridViewRowsRemovedEventArgs Evento)
        {
            ConsultasProcAjustarAlturaFilas();
        }

        private void ConsultasMetEnlaceCompletado(object Remitente, DataGridViewBindingCompleteEventArgs Evento)
        {
            ConsultasProcAjustarAlturaFilas();
        }

        internal bool ConsultasFilasUniformes { get; set; }

        private void ConsultasProcAjustarAlturaFilas()
        {
            if (ConsultasDgvMain.AutoSizeRowsMode != DataGridViewAutoSizeRowsMode.None)
            {
                return;
            }

            int CantidadFilas = 0;

            foreach (DataGridViewRow Fila in ConsultasDgvMain.Rows)
            {
                if (Fila.Visible)
                {
                    CantidadFilas++;
                }
            }

            if (CantidadFilas == 0)
            {
                return;
            }

            int AlturaEncabezado = ConsultasDgvMain.ColumnHeadersVisible
                ? ConsultasDgvMain.ColumnHeadersHeight
                : 0;

            int EspacioDisponible = ConsultasDgvMain.ClientSize.Height - AlturaEncabezado;

            foreach (Control ControlInterno in ConsultasDgvMain.Controls)
            {
                if (ControlInterno is HScrollBar && ControlInterno.Visible)
                {
                    EspacioDisponible -= ControlInterno.Height;
                }
            }

            if (EspacioDisponible <= 0)
            {
                return;
            }

            int AlturaCalculada = EspacioDisponible / CantidadFilas;
            int AlturaBase = Math.Max(_AlturaMinimaFila, Math.Min(_AlturaMaximaFila, AlturaCalculada));
            int Sobrante = !ConsultasFilasUniformes && AlturaCalculada >= _AlturaMinimaFila && AlturaCalculada < _AlturaMaximaFila
                ? EspacioDisponible % CantidadFilas
                : 0;

            foreach (DataGridViewRow Fila in ConsultasDgvMain.Rows)
            {
                if (!Fila.Visible)
                {
                    continue;
                }

                int AlturaFila = Math.Max(Fila.MinimumHeight, AlturaBase + (Sobrante > 0 ? 1 : 0));

                if (Fila.Height != AlturaFila)
                {
                    Fila.Height = AlturaFila;
                }

                if (Sobrante > 0)
                {
                    Sobrante--;
                }
            }
            /*Fin del código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
        }
    }
}