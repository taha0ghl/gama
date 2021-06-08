using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GAMA
{
    public partial class DayItem : UserControl
    {
        public DayItem()
        {
            InitializeComponent();
        }

        #region Fields

        private Color _selectedRingColor = Color.FromArgb(156, 39, 160);
        private float _selectedRingWidth = 1;
        private Color _selectedForeColor = Color.White;
        private Color _currantRingColor = Color.FromArgb(156, 39, 160);
        private Color _currantForeColor = Color.White;
        private bool _isSelected = false;
        private bool _isCurrant = false;
        private bool _useFitEllipe = true;

        #endregion


        #region Properties

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                PaintItem();
                if (value)
                    Selected?.Invoke(this, new EventArgs());
                else
                    Unselected?.Invoke(this, new EventArgs());
            }
        }
        public bool IsCurrant
        {
            get => _isCurrant;
            set
            {
                _isCurrant = value;
                PaintItem();
                if (value)
                    MarkedAsCurrant?.Invoke(this, new EventArgs());
                else
                    UnmarkedAsCurrant?.Invoke(this, new EventArgs());
            }
        }
        public Color SelectedRingColor
        {
            get => _selectedRingColor;
            set
            {
                _selectedRingColor = value;
                PaintItem();
            }
        }
        public Color SelectedForeColor
        {
            get => _selectedForeColor;
            set
            {
                _selectedForeColor = value;
                PaintItem();
            }
        }
        public float SelectedRingWidth
        {
            get => _selectedRingWidth;
            set
            {
                _selectedRingWidth = value;
                PaintItem();
            }
        }
        public Color CurrantRingColor
        {
            get => _currantRingColor;
            set
            {
                _currantRingColor = value;
                PaintItem();
            }
        }
        public Color CurrantForeColor
        {
            get => _currantForeColor;
            set
            {
                _currantForeColor = value;
                PaintItem();
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                PaintItem();
            }
        }
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                PaintItem();
            }
        }
        public bool UseFitedEllipse
        {
            get => _useFitEllipe;
            set
            {
                _useFitEllipe = value;
                PaintItem();
            }
        }

        #endregion


        #region Methods

        protected void PaintItem()
        {
            using (Bitmap bitmap = new Bitmap(ClientSize.Width, ClientSize.Height))
            using (Graphics gr = Graphics.FromImage(bitmap))
            {
                EraseItem(gr);
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                if (IsCurrant)
                    MarkAsCurrant(gr);
                else if (IsSelected)
                    MarkAsSelected(gr);
                DrawText(gr);
                using (Graphics gr2 = CreateGraphics())
                    gr2.DrawImage(bitmap, Point.Empty);
            }
        }

        protected void EraseItem(Graphics gr)
        {
            gr.Clear(BackColor);
        }

        protected void MarkAsSelected(Graphics gr)
        {
            Pen pen = new Pen(SelectedRingColor, SelectedRingWidth)
            {
                Alignment = PenAlignment.Inset,
            };
            RectangleF rect = GetMarkRect();
            gr.DrawEllipse(pen, rect);
        }

        protected void MarkAsCurrant(Graphics gr)
        {
            RectangleF rect = GetMarkRect();
            gr.FillEllipse(new SolidBrush(CurrantRingColor), rect);
        }

        protected void DrawText(Graphics gr)
        {
            SizeF textSize = TextRenderer.MeasureText(Text, Font, Size);
            SolidBrush brush = new SolidBrush(IsCurrant ? CurrantForeColor : IsSelected ? SelectedForeColor : ForeColor);
            float width = ClientSize.Width / 2F - textSize.Width / 2F + 1;
            float height = ClientSize.Height / 2F - textSize.Height / 2F + 1;
            gr.DrawString(Text, Font, brush, width, height);
        }

        private RectangleF GetMarkRect()
        {
            float x, y, width, height;
            if (UseFitedEllipse)
            {
                float minSize = Math.Min(ClientSize.Width, ClientSize.Height);
                width = height = minSize;
                x = ClientSize.Width / 2F - minSize / 2F;
                y = ClientSize.Height / 2F - minSize / 2F;
            }
            else
            {
                width = ClientSize.Width;
                height = ClientSize.Height;
                x = y = 0;
            }
            return new RectangleF(x, y, width, height);
        }

        #endregion


        #region Event Implementation
        private void YearItem_Paint(object sender, PaintEventArgs e)
        {
            PaintItem();
        }

        private void YearItem_Click(object sender, EventArgs e)
        {
            IsSelected = !IsSelected;
        }
        #endregion


        #region Events
        public event EventHandler Selected;
        public event EventHandler Unselected;
        public event EventHandler MarkedAsCurrant;
        public event EventHandler UnmarkedAsCurrant;
        #endregion
    }
}
