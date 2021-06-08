using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyClass;

namespace GAMA
{
    public partial class FrmMaster : Form
    {
        public FrmMaster()
        {
            InitializeComponent();

            BackColor = Theme.BackColor2;
            BorderColor = Color.FromKnownColor(KnownColor.DarkGray);

            // Header
            SetHeader();
            Controls.Add(Header);
            Header.MouseMove += Header_MouseMove;
            Header.MouseDown += Header_MouseDown;
            Header.MouseUp += Header_MouseUp;

            // BtnClose
            SetBtnClose();
            Header.Controls.Add(BtnClose);
        }

        //Variables****************************
        #region 

        private bool mouseDown;
        private bool _hasBorder;
        private bool _hasHeader;

        private Pen borderPen;
        private Pen borderPenCleaner;

        private Color _borderColor;
        private Color _headerForeColor;

        private Point lastLocation;
        private readonly int borderSideSpace = 3;

        private readonly Label Header = new Label();
        private readonly BtnClose BtnClose = new BtnClose();

        #endregion
        //*************************************

        //Properties***************************
        #region 

        [Browsable(true)]
        public bool HasBorder
        {
            get
            {
                return _hasBorder;
            }
            set
            {
                _hasBorder = value;
                OnPaint(new PaintEventArgs(CreateGraphics(), ClientRectangle));
            }
        }

        [Browsable(true)]
        public bool HasHeader
        {
            get
            {
                return _hasHeader;
            }
            set
            {
                _hasHeader = value;
                Header.Visible = value;
                OnPaint(new PaintEventArgs(CreateGraphics(), ClientRectangle));
            }
        }

        [Browsable(true)]
        public Color HeaderforeColor
        {
            get
            {
                return _headerForeColor;
            }
            set
            {
                _headerForeColor = value;
                OnPaint(new PaintEventArgs(CreateGraphics(), ClientRectangle));
            }
        }

        [Browsable(true)]
        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                OnPaint(new PaintEventArgs(CreateGraphics(), ClientRectangle));
            }
        }
        public int HeaderHeight
        {
            get
            {
                return 25;
            }
        }

        #endregion
        //*************************************

        //Events*******************************
        #region 

        // This
        #region 
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Locations.CenterScreen(this);
            if (File.Exists(Application.StartupPath + "\\Icons\\close.png"))
            {
                BtnClose.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Icons\\close.png");
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            SetHeader();
            SetBtnClose();

            Graphics gr = e.Graphics;

            borderPen = new Pen(BorderColor, 1);
            borderPenCleaner = new Pen(new SolidBrush(BackColor), 1);

            ManageBorder(gr);
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            SetHeader();
            SetBtnClose();
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            Locations.CenterScreen(this);
        }
        #endregion

        // Header
        #region
        private void Header_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void Header_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y); ;
                Update();
            }
        }
        #endregion

        #endregion
        //*************************************

        //Methods******************************
        #region 

        private void SetHeader()
        {
            Header.AutoSize = false;
            Header.TextAlign = ContentAlignment.MiddleLeft;

            Header.Width = ClientSize.Width - 2 * borderSideSpace - 1;
            Header.Height = 25;
            Header.Location = new Point(borderSideSpace + 1, borderSideSpace + 1);

            Header.Text = Text;
            Header.BackColor = BorderColor;
            Header.Font = new Font("b nazanin", 11, FontStyle.Bold);
            Header.ForeColor = HeaderforeColor;

            Header.SendToBack();
        }
        private void SetBtnClose()
        {
            BtnClose.Top = 2;
            BtnClose.BackColor = BorderColor;
            Locations.RightOrder(Header, 3, BtnClose);
            BtnClose.Size = new Size(20, 20);
            BtnClose.BackgroundImageLayout = ImageLayout.Stretch;
            BtnClose.BringToFront();
        }
        private void ManageBorder(Graphics gr)
        {
            if (HasBorder)
            {
                DrawBorder(gr, borderPen);
            }
            else
            {
                DrawBorder(gr, borderPenCleaner);
            }
        }
        private void DrawBorder(Graphics gr, Pen pen)
        {
            ProjectClass.DrawBorder(gr,
                pen,
                borderSideSpace,
                ClientSize.Width,
                ClientSize.Height,
                0.5);
        }

        #endregion
        //*************************************
    }
}
