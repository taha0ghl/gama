using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;


namespace myclass
{
    class RadioButtonSimple :RadioButton
    {
        #region Field
        private Color checkedColor = Color.SlateGray;
        private Color unCheckedColor = Color.Gray;
        #endregion

        #region Property
        public Color CheckedColor { get => checkedColor; set { checkedColor = value;  this.Invalidate(); } }
        public Color UnCheckedColor { get => unCheckedColor; set { unCheckedColor = value; this.Invalidate(); } }
        #endregion

        #region Method
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics graphics = pevent.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            float borderSize = 18f;
            float checkSize = 12f;
            RectangleF rectBorder = new RectangleF()
            {
                X=0.5f,
                Y=(this.Height-borderSize)/2,
                Width= borderSize,
                Height= borderSize
            };
            RectangleF rectCheck = new RectangleF()
            {
                X = rectBorder.X+((rectBorder.Width-checkSize)/2),
                Y = (this.Height - checkSize) / 2,
                Width = checkSize,
                Height = checkSize
            };
            using (Pen penBorder = new Pen(CheckedColor, 1.6f))
            using (SolidBrush brushCheck = new SolidBrush(checkedColor))
            using (SolidBrush textBrush = new SolidBrush(this.ForeColor))
            {
                graphics.Clear(this.BackColor);
                if (this.Checked)
                {
                    graphics.DrawEllipse(penBorder, rectBorder);
                    graphics.FillEllipse(brushCheck, rectCheck);
                }
                else
                {
                    penBorder.Color = UnCheckedColor;
                    graphics.DrawEllipse(penBorder, rectBorder);

                }
                graphics.DrawString(this.Text, this.Font, textBrush, borderSize + 8,
                    (this.Height - TextRenderer.MeasureText(this.Text, this.Font).Height) / 2);
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Width = TextRenderer.MeasureText(this.Text, this.Font).Width+30;
        }

        #endregion

        #region ctor
        public RadioButtonSimple()
        {
            this.MinimumSize = new Size(0, 21);
        }
        #endregion

    }
}
