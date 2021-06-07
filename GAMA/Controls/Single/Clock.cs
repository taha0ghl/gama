using MyClass;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GAMA
{
    public partial class Clock : UserControl, IDisposable
    {
        public Clock()
        {
            _lblText = new Label
            {
                Text = Text,
                Font = Font,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true
            };
            AdjustLable();
            Controls.Add(_lblText);
            _lblText.TextChanged += LblText_TextChanged;

            if (CutRegion)
            {
                SetRegion();
            }
        }

        //Variables****************************
        #region

        // Booleans
        private bool _cutRegion = true;

        // Floats
        private float _clockValue = 0;
        private float _reachedWidth = 5;
        private float _unreachedWidth = 5;

        // Colors
        private Color _insideColor = Color.White;
        private Color _reachedColor = Color.Blue;
        private Color _outLineColor = Color.White;
        private Color _unreachedColor = Color.Gray;

        // Controls
        private readonly Label _lblText = new Label();

        #endregion
        //*************************************

        //Properties***************************
        #region

        public Color InsideColor
        {
            get => _insideColor;
            set
            {
                _insideColor = value;
                _lblText.BackColor = value;
                OnPaint(new PaintEventArgs(CreateGraphics(), ClientRectangle));
            }
        }
        public Color OutLineColor
        {
            get => _outLineColor;
            set
            {
                _outLineColor = value;
                OnPaint(new PaintEventArgs(CreateGraphics(), ClientRectangle));
            }
        }
        public Color ReachedColor
        {
            get => _reachedColor;
            set { _reachedColor = value; DrawClock(); }
        }
        public Color UnreachedColor
        {
            get => _unreachedColor;
            set { _unreachedColor = value; DrawClock(); }
        }

        /// <summary>
        /// value should be between 0 and 59
        /// </summary>
        public float ClockValue
        {
            get => _clockValue;
            set
            {
                CheckSecondValue(value);
                _clockValue = value;
                DrawClock();
            }
        }
        public float ReachedWidth
        {
            get => _reachedWidth;
            set
            {
                _reachedWidth = value;
                DrawClock();
                AdjustLable();
            }
        }
        public float UnreachedWidth
        {
            get => _unreachedWidth;
            set
            {
                _unreachedWidth = value;
                DrawClock();
                AdjustLable();
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [RefreshProperties(RefreshProperties.All)]
        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                _lblText.Text = value;
                AdjustLable();
            }
        }

        [Browsable(true)]
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                _lblText.Font = value;
                AdjustLable();
            }
        }

        public bool CutRegion
        {
            get
            {
                return _cutRegion;
            }
            set
            {
                _cutRegion = value;

                if (CutRegion)
                {
                    SetRegion();
                }
                else
                {
                    Region = new Region(ClientRectangle);
                }
            }
        }

        #endregion
        //*************************************

        //Events*******************************
        #region 

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawClock();
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            PlaceLabelToCenter();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            PlaceLabelToCenter();
            if (CutRegion)
            {
                SetRegion();
            }
        }
        private void LblText_TextChanged(object sender, EventArgs e)
        {
            AdjustLable();
        }

        #endregion
        //*************************************

        //Methods******************************
        #region 

        private void DrawClock()
        {
            // Creating Graphic
            Bitmap image = new Bitmap(Width, Height);
            DrawToBitmap(image, ClientRectangle);
            Graphics gr = Graphics.FromImage(image);
            gr.SmoothingMode = SmoothingMode.HighQuality;
            gr.CompositingQuality = CompositingQuality.HighQuality;

            // Painting
            PaintInsideColor(gr);
            DrawProgressbar(gr, ClockValue);
            gr = CreateGraphics();
            gr.DrawImage(image, Point.Empty);

            //Make Memmory Free
            DisposeObjects(gr, image);
        }
        private void SetRegion()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(ClientRectangle);
            Region = new Region(path);
        }
        private bool IsLableOut()
        {
            if (_lblText.Width + 2 * Math.Max(ReachedWidth, UnreachedWidth) > Width - 4 ||
                _lblText.Height + 2 * Math.Max(ReachedWidth, UnreachedWidth) > Height - 4)
                return true;
            return false;
        }
        public void AdjustLable()
        {
            AdjustLableSize();
            PlaceLabelToCenter();
            Graphics gr = CreateGraphics();
            gr.SmoothingMode = SmoothingMode.HighQuality;
            PaintInsideColor(gr);
            DisposeObjects(gr);
        }
        private void AdjustLableSize()
        {
            const float rate = 0.5f;
            while (IsLableOut())
                _lblText.Font = new Font(_lblText.Font.FontFamily, _lblText.Font.Size - rate);
        }
        private void PlaceLabelToCenter()
        {
            Locations.CenterWidth(this, _lblText);
            Locations.CenterHeight(this, _lblText);
        }
        private void CheckSecondValue(float value)
        {
            if (value > 59 || value < 0)
                throw new ArgumentException("Argument Should be between 0 and 59");
        }
        private void PaintInsideColor(Graphics gr)
        {
            Rectangle rect = ClientRectangle;
            int maxWidth = -(int)Math.Max(ReachedWidth, UnreachedWidth);
            rect.Inflate(maxWidth - 2, maxWidth - 2);
            gr.FillEllipse(new SolidBrush(InsideColor), rect);
            gr.DrawEllipse(new Pen(OutLineColor), rect);
        }
        private void DrawProgressbar(Graphics gr, float second)
        {
            //Drawing GraphicS
            DrawUnreachedProgress(gr, second == 0 ? 0.0001f : second, UnreachedWidth);
            if (second > 0)
                DrawReachedProgress(gr, second, ReachedWidth);
        }
        private void DisposeObjects(params IDisposable[] objects)
        {
            for (int i = 0; i < objects.Length; i++)
                objects[i].Dispose();
        }
        private void DrawReachedProgress(Graphics gr, float value, float width)
        {
            float sweepAngle = (value) * 6;
            Pen pen = new Pen(ReachedColor, width)
            {
                Alignment = System.Drawing.Drawing2D.PenAlignment.Inset,
                StartCap = System.Drawing.Drawing2D.LineCap.Round,
                EndCap = System.Drawing.Drawing2D.LineCap.Round
            };
            Rectangle rect = ClientRectangle;
            rect.Inflate(-(int)(width / 2 + 1), -(int)(width / 2 + 1));
            gr.DrawArc(pen, rect, 270, sweepAngle);
        }
        private void DrawUnreachedProgress(Graphics gr, float value, float width)
        {
            float startAngle = (value) * 6 - 90;
            Pen pen = new Pen(UnreachedColor, width) { Alignment = System.Drawing.Drawing2D.PenAlignment.Inset };
            Rectangle rect = ClientRectangle;
            rect.Inflate(-(int)(ReachedWidth / 2 + 1), -(int)(ReachedWidth / 2 + 1));
            gr.DrawArc(pen, rect, startAngle, 360 - (value * 6));
        }

        #endregion
        //*************************************
    }
}
