using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Test
{
    public enum NotificationType
    {
        Success, Info, Warning, Danger
    }

    public partial class frmAlter : Form
    {
        #region Fields

        const int CONTROL_DISTANCE = 5;
        NotificationType _type = NotificationType.Info;

        #endregion


        #region Properties

        public NotificationType Type { get => _type; set { _type = value; SetTheme(value); } }
        public string Message {
            get => lblMessage.Text;
            set
            {
                lblMessage.Text = value;
                SetSize();
            }
        }
        public Font MessageFont { get => lblMessage.Font; set => lblMessage.Font = value; }

        #endregion


        #region Event Implication

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Close();
        }

        private void Control_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAlter_Shown(object sender, EventArgs e)
        {
            SetLocation();
        }

        private void frmAlter_Resize(object sender, EventArgs e)
        {
            RoundEdge();   
        }

        #endregion


        #region Functions

        public frmAlter()
        {
            new FormFader(this, 300, 1D);
            InitializeComponent();
            RoundEdge();
            SetTheme(Type);
            lblMessage.Padding = new Padding(0, 0, CONTROL_DISTANCE, 0);
        }

        private void RoundEdge()
        {
            RadiusCollection radiuses = new RadiusCollection(Height, 0, Height, 0);
            using (GraphicsPath path = ControlEdgeRounder.GetCustomRoundPath(ClientRectangle, radiuses))
                this.Region = new Region(path);
        }

        private void SetTheme(NotificationType notificationType)
        {
            CheckIfNull(notificationType);
            BackColor = Color.FromArgb(30, 42, 53);
            ForeColor = Color.White;
            switch (notificationType)
            {
                case NotificationType.Success:
                    picb.Image = Properties.Resources.Success;
                    //ForeColor = Color.FromArgb(1, 201, 160);
                    break;
                case NotificationType.Info:
                    picb.Image = Properties.Resources.Info;
                    //ForeColor = Color.FromArgb(0, 175, 204);
                    break;
                case NotificationType.Warning:
                    picb.Image = Properties.Resources.Warning;
                    //ForeColor = Color.FromArgb(255, 171, 1);
                    break;
                case NotificationType.Danger:
                    picb.Image = Properties.Resources.Danger;
                    //ForeColor = Color.FromArgb(225, 83, 87);
                    break;
            }
        }

        private void SetLocation()
        {
            int counter = 1;
            string formBaseName = "FaderNotification";
            while (true)
            {
                frmAlter form = (frmAlter)Application.OpenForms[formBaseName + counter];
                if (form == null)
                {
                    Name = formBaseName + counter;
                    Location = FindLocation(counter);
                    break;
                }
                counter++;
            }
        }

        private void SetSize()
        {
            int maxWidth = Owner is null ? Screen.PrimaryScreen.WorkingArea.Width : Owner.Width;
            int width = lblMessage.GetPreferredSize(new Size(maxWidth, Height)).Width + picb.Width;
            Width = width;
        }

        private Point FindLocation(int formNumber)
        {
            const int RIGHT_Padding = 10;
            const int BOTTOM_Padding = 0;
            const int EACH_Padding = 2;
            Size screenSize = Owner is null ? Screen.PrimaryScreen.WorkingArea.Size : new Size(Owner.Right, Owner.Bottom - 10);
            return new Point(screenSize.Width - Width - RIGHT_Padding, screenSize.Height - Height - BOTTOM_Padding - ((formNumber - 1) * Height) - ((formNumber - 1) * EACH_Padding));
        }

        private void CheckIfNull(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException();
        }

        #endregion
    }
}
