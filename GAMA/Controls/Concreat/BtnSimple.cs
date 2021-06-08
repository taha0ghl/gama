using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.IO;

namespace GAMA
{
    public class BtnSimple : BtnSimpleBases, IBtnPro
    {
        #region field and property
        private int borderSize = 0;
        private int borderRadius = 10;
        private Color borderColor = Color.PaleVioletRed;

        public int BorderSize { get => borderSize; set { borderSize = value; this.Invalidate(); } }
        public int BorderRadius { get => borderRadius; set {

                if (value <= this.Height)
                    borderRadius = value;
                else borderRadius = this.Height;
                this.Invalidate(); } }
        public Color BorderColor { get => borderColor; set { borderColor = value; this.Invalidate(); } }
        public Color BackgroundColor
        {
            get { return this.ForeColor; }
            set
            {
                this.ForeColor = value;
            }
        }
        public Color TextColor
        {
            get { return this.ForeColor; }
            set
            {
                this.ForeColor = value;
            }
        }
        #endregion
        #region mtehod
        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
            {
                borderRadius = this.Height;
            }
        }

        private GraphicsPath GetFigurePath(RectangleF rect,float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width-radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width-radius, rect.Height-radius, radius, radius,0, 90);
            path.AddArc(rect.X, rect.Height-radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF surface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8f, this.Height - 1);
            if (BorderRadius>2)
            {
                using (GraphicsPath surfacePath = GetFigurePath(surface, BorderRadius))
                using (GraphicsPath borderPath = GetFigurePath(rectBorder, BorderRadius-1f))
                using (Pen surfacePen = new Pen(this.Parent.BackColor, 2))
                using (Pen borderPen = new Pen(BorderColor, BorderSize))
                {

                    borderPen.Alignment = PenAlignment.Inset;
                    this.Region = new Region(surfacePath);
                    pevent.Graphics.DrawPath(surfacePen, surfacePath);
                    if (BorderSize>=1)
                    {
                        pevent.Graphics.DrawPath(borderPen, borderPath);
                    }
                }

            }
            else
            {
                this.Region=new Region(surface);
                if (BorderSize >= 1)
                {
                    using (Pen borderPen = new Pen(BorderColor, BorderSize))
                        pevent.Graphics.DrawRectangle(borderPen,0,0,this.Width-1,this.Height-1);
                }

            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChange);
        }

        private void Container_BackColorChange(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                this.Invalidate();
            }
        }
        #endregion
        #region ctor
        public BtnSimple()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(Button_Resize);

        }

        #endregion
    }
}

