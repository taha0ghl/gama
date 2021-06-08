using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace myclsass
{
    [DefaultEvent("_TextChanged")]
    class textBox : UserControl
    {
        #region field and property
        private TextBox textBox1;
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 2;
        private bool underlineStyle = false;
        private Color borderFocusColor = Color.HotPink;
        private bool isFocus = false;
        public Color BorderColor { get => borderColor; set { borderColor = value; this.Invalidate(); } }
        public int BorderSize { get => borderSize; set { borderSize = value; this.Invalidate(); } }
        public bool UnderlineStyle { get => underlineStyle; set { underlineStyle = value; this.Invalidate();} }
        public bool  passwordChar{
            get=>textBox1.UseSystemPasswordChar;

            set { textBox1.UseSystemPasswordChar = value; }
        }
        public bool Multiline{ get=>textBox1.Multiline; set { textBox1.Multiline = value; } }
        public override Color BackColor { get => base.BackColor ; set { base.BackColor = value; textBox1.BackColor = value; } }
        public override Color ForeColor { get => base.ForeColor; set { base.ForeColor = value; textBox1.ForeColor = value; } }
        public override Font Font { get => base.Font; set { base.Font = value; textBox1.Font = value;
                if (this.DesignMode)
                    UpdateHeight();
            } }
        public string texts { get => textBox1.Text; set { textBox1.Text = value; } }

        public Color BorderFocusColor { get => borderFocusColor; set => borderFocusColor = value; }
        #endregion

        #region method
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            using (Pen borderPen = new Pen(BorderColor, BorderSize))
            {
                borderPen.Alignment = PenAlignment.Inset;
                if (!isFocus)
                {
                    if (underlineStyle)
                        graph.DrawLine(borderPen, 0, this.Height - 1, this.Width, this.Height - 1);
                    else
                        graph.DrawRectangle(borderPen, 0, 0, this.Width - 0.5f, this.Height - 0.5f);
                }
                else
                {
                   borderPen.Color= borderFocusColor;
                    if (underlineStyle)
                        graph.DrawLine(borderPen, 0, this.Height - 1, this.Width, this.Height - 1);
                    else
                        graph.DrawRectangle(borderPen, 0, 0, this.Width - 0.5f, this.Height - 0.5f);
                }


            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if(this.DesignMode)
            UpdateHeight();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateHeight();
        }

        private void UpdateHeight()
        {
            if (textBox1.Multiline==false)
            {
                int txtHeight = TextRenderer.MeasureText("text", this.Font).Height;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0,txtHeight);
                textBox1.Multiline = false;
                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }
        #endregion
        #region event
        public event EventHandler _TextChanged;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
                _TextChanged.Invoke(sender, e);


        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocus = true;
            this.Invalidate();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocus = false;
            this.Invalidate();
        }
        #endregion
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(7, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(236, 15);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // textBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "textBox";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Size = new System.Drawing.Size(250, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public textBox()
        {
            InitializeComponent();
        }

    
    }
}
