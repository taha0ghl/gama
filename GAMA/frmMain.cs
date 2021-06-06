using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyClass;
using System.Globalization;
using System.Threading;
using System.Reflection;
using System.Collections;

namespace GAMA
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            upBtns = new BaseBtn[] { btnIcon, btnFile, btnStandard, btnPersenel, btnKaramooz, btnSabtNam, btnPayam, btnDafater, btnAzmoon, btnMali, btnPortal, btnBarnameHaftegi, btnKarbar, btnForoshgah, btnGozaresh };

            downBtns = new BaseBtn[] { btnNotifications, btnRahnama, btnTanzimat };

            btnSubOptionsMenuStrinp.Items[0].Click += BtnSubOptionsMenuString_Shortcut_Click;
            btnShortcutsMenuStrinp.Items[0].Click += BtnShorcutsMenuString_Delete_Click;

            pnlDateTime.Controls.Add(clock);

            // Calculate Sizes
            #region

            btnOptionsBetweenSpace = 0;
            btnSubOptionsBetweenSpace = 2;

            pnlBtnoptionsSize = new Size(Screen.PrimaryScreen.Bounds.Width / 11, Screen.PrimaryScreen.Bounds.Height - 60);

            btnOptionsSize = new Size(pnlBtnoptionsSize.Width, (Screen.PrimaryScreen.Bounds.Height - pnlBtnOptions.Controls.Count * btnOptionsBetweenSpace - 60) / (pnlBtnOptions.Controls.Count + 1 + 2));
            btnIconSize = new Size(btnOptionsSize.Width, 2 * btnOptionsSize.Height);

            btnSubOptionsSize = new Size(Convert.ToInt32(btnOptionsSize.Height * 2.3), Convert.ToInt32(btnOptionsSize.Height * 0.9));
            #endregion
        }

        //Variables****************************
        #region

        // DateTimes
        private DateTime now = DateTime.Now;

        // Ints
        private readonly int btnOptionsBetweenSpace;
        private readonly int btnSubOptionsBetweenSpace;

        // Controls
        private readonly BaseBtn[] upBtns;
        private readonly BaseBtn[] downBtns;

        // Sizes
        private readonly Size btnIconSize;
        private readonly Size btnOptionsSize;
        private readonly Size pnlBtnoptionsSize;
        private readonly Size btnSubOptionsSize;

        // Booleans
        private bool isPnlOptionsUpToDown = true;

        // Colors
        private readonly Color downPartBackColor = Theme.Color2;
        private readonly Color btnOptionsNotFocusedForeColor = Color.FromArgb(210, 210, 210);

        #endregion
        //*************************************

        //Events*******************************
        #region 

        // Timer
        private void Timer1_Tick(object sender, EventArgs e)
        {
            WriteDateTime();
        }

        // Form
        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Test !!!!!!!!!!!!!!!
            StaticData.current_user = new Manager
            {
                Id = "13",
                FirstName = "حسین",
                LastName = "محمودی"
            };
            lblLoggedUserName.Text = StaticData.current_user.FirstName + " " + StaticData.current_user.LastName;
            //

            SettingUp();
            ManageDesign();
            SetLocations();
        }
        private void FrmMain_Click(object sender, EventArgs e)
        {
            if (pnlSubOptions.Visible)
            {
                foreach (BtnOption item in pnlBtnOptions.Controls.OfType<BtnOption>())
                {
                    item.IsClicked = false;
                }
                pnlSubOptions.Hide();
            }
        }
        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphic = e.Graphics;

            graphic.DrawLine(Theme.Pen1,
                new Point(0, downBtns[downBtns.Length - 1].Top - 1),
                new Point(pnlBtnOptions.Left, downBtns[downBtns.Length - 1].Top - 1));
            graphic.DrawLine(Theme.Pen1,
                new Point(0, upBtns[0].Bottom),
                new Point(pnlBtnOptions.Left, upBtns[0].Bottom));

            SolidBrush brush = new SolidBrush(downPartBackColor);
            Rectangle rctngl1 = new Rectangle(0, downBtns[downBtns.Length - 1].Top, ClientSize.Width - pnlBtnOptions.Width, ClientSize.Height - downBtns[downBtns.Length - 1].Top);
            Rectangle rctngl2 = new Rectangle(0, upBtns[0].Top, ClientSize.Width - pnlBtnOptions.Width, btnIcon.Height);

            graphic.FillRectangle(brush, rctngl1);
            graphic.FillRectangle(brush, rctngl2);
        }

        // Button
        private void BtnOptions_Click(object sender, EventArgs e)
        {
            BtnOption btn = sender as BtnOption;

            // Hide The PnlSubOptions Incase Of Visibility
            if (btn.IsClicked)
            {
                HidePnlSubOptions();
                return;
            }
            else
            {
                if (pnlSubOptions.Visible)
                {
                    ManageIsClickedProperty(btn);

                    HidePnlSubOptions();
                }
            }

            // Check If Btn Has SubOptions
            if (btn.SubOptions == null || btn.SubOptions.Length == 0)
            {
                return;
            }

            // Seting PnlSubOptions
            SetPnlOptionsHeight(btn);
            isPnlOptionsUpToDown = !(btn.Top + pnlSubOptions.Height >= downBtns[downBtns.Length - 1].Top - 10);
            pnlSubOptions.Controls.Clear();
            SetSubPnlOptionsLocation(btn);

            // Creating BtnSubOptions
            CreatBtnSubOptions(btn);

            // Animation
            pnlSubOptions.Show();
        }
        private void BtnShortcuts_Click(object sender, EventArgs e)
        {
            if (pnlSubOptions.Visible)
            {
                ManageIsClickedProperty();

                HidePnlSubOptions();
            }
        }
        private void BtnSubOptions_Click(object sender, EventArgs e)
        {
            (sender as BtnSubOptions).BtnParent.IsClicked = false;
            HidePnlSubOptions();
        }
        private void BtnOptions_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            btn.ImageList = imageList1;
            btn.ForeColor = Color.White;
        }
        private void Btnoptions_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            btn.ImageList = imageList2;
            btn.ForeColor = Color.FromArgb(210, 210, 210);
        }
        private void BtnShortcuts_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            btnShortcutsMenuStrinp.BtnParent = sender as Button;
            (sender as Button).ContextMenuStrip.Show();
        }
        private void BtnSubOptions_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            btnSubOptionsMenuStrinp.BtnParent = sender as Button;
            (sender as Button).ContextMenuStrip.Show();
        }

        // ToolStripMenuItem
        private void BtnShorcutsMenuString_Delete_Click(object sender, EventArgs e)
        {
            fPnlShortcuts.Controls.Remove(btnShortcutsMenuStrinp.BtnParent);
        }
        private void BtnSubOptionsMenuString_Shortcut_Click(object sender, EventArgs e)
        {
            BtnSubOptions parent = btnSubOptionsMenuStrinp.BtnParent as BtnSubOptions;

            foreach (BaseBtn item in fPnlShortcuts.Controls.OfType<BaseBtn>())
            {
                if (item.Text == parent.Text)
                {
                    return;
                }
            }

            fPnlShortcuts.Controls.Add(CreatShortcut(parent));
        }

        #endregion
        //*************************************

        //Methods******************************
        #region

        private void SettingUp()
        {
            // SettingUp fPnlBtnOptions
            #region
            pnlBtnOptions.Size = pnlBtnoptionsSize;

            foreach (Button item in pnlBtnOptions.Controls.OfType<Button>())
            {
                item.Size = (item.Name == btnIcon.Name) ? btnIconSize : btnOptionsSize;

                item.Font = new Font(Theme.FontFamily, 13);
                item.ForeColor = btnOptionsNotFocusedForeColor;
            }
            #endregion

            // SettingUp PnlSubOptions
            #region
            pnlSubOptions.MaximumSize = new Size(btnSubOptionsSize.Width + StaticData.pnlsuboptions_space, 0);
            #endregion

            // SettingUp PnlLoggedUser
            #region
            pnlLoggedUser.Size = new Size(Convert.ToInt32(btnOptionsSize.Height * 4.5), Convert.ToInt32(btnOptionsSize.Height * 1.7));
            picLoggedUser.Size = new Size(pnlLoggedUser.Height, pnlLoggedUser.Height);
            #endregion

            // SettingUp PnlOnlineUsers
            #region
            lblOnlineUsers.Text = "تعداد کاربران آنلاین : 3";
            pnlOnlineUsers.Size = new Size(lblOnlineUsers.Width + 6, lblOnlineUsers.Height + 4);
            #endregion

            // Setting PnlDateTime
            #region
            pnlDateTime.Size = new Size(Convert.ToInt32(btnOptionsSize.Height * 3.5), pnlLoggedUser.Height - 10);
            clock.Size = new Size(pnlDateTime.Height - 3, pnlDateTime.Height - 3);
            //ManageDate();
            #endregion

            // Setting PnlShortcuts
            #region
            int size = downBtns[0].Bottom - downBtns[downBtns.Length - 1].Top - 10;
            fPnlShortcuts.Size = new Size(size * 2, size);
            #endregion
        }
        private void ManageDesign()
        {
            Theme.Set(this, btnIcon, btnNotifications, pnlSubOptions);
            fPnlShortcuts.BackColor = pnlDateTime.BackColor = pnlLoggedUser.BackColor = pnlOnlineUsers.BackColor = downPartBackColor;
        }
        private void SetLocations()
        {
            // fPnlBtnOptions
            #region 
            Locations.RightOrder(this, 0, pnlBtnOptions);
            pnlBtnOptions.Top = 0;

            // Up Buttons
            btnIcon.Location = new Point(0, 0);
            for (int i = 1; i < upBtns.Length; i++)
            {
                upBtns[i].Location = new Point(0, upBtns[i - 1].Bottom + btnOptionsBetweenSpace);
            }

            // Down Buttons
            btnNotifications.Location = new Point(0, pnlBtnOptions.Height - btnNotifications.Height);
            for (int i = 1; i < downBtns.Length; i++)
            {
                downBtns[i].Location = new Point(0, downBtns[i - 1].Top - downBtns[i].Height);
            }
            #endregion

            // fPnlSubOptions
            #region
            Locations.Left(pnlBtnOptions, 2, true, pnlSubOptions);
            #endregion

            // PnlLoggedUser
            #region
            pnlLoggedUser.Location = new Point(3, upBtns[0].Top + 3);

            // lblConstTitleLoggedUser
            Locations.RightOrder(pnlLoggedUser, 3, lblConstTitleLoggedUser);
            lblConstTitleLoggedUser.Top = 5;

            // pictureLoggedUser
            picLoggedUser.Location = new Point(0, 0);

            // lblLoggedUserName
            Locations.RightOrder(pnlLoggedUser, 5, lblLoggedUserName);
            lblLoggedUserName.Top = lblConstTitleLoggedUser.Bottom + 5;
            #endregion

            // PnlOnlineUsers
            #region
            pnlOnlineUsers.Location = new Point(3, downBtns[downBtns.Length - 1].Top + 3);

            // lblOnlineUsers
            Locations.RightOrder(pnlOnlineUsers, 3, lblOnlineUsers);
            Locations.CenterHeight(pnlOnlineUsers, lblOnlineUsers);
            #endregion

            // PnlDateTime 
            #region
            pnlDateTime.Location = new Point(3, downBtns[downBtns.Length - 1].Top + 3 + pnlOnlineUsers.Height + 3);

            // clock
            Locations.CenterHeight(pnlDateTime, clock);
            clock.Left = 1;

            // lblDate
            Locations.Right(clock, 0, true, lblDate);
            Locations.AlignMiddles(clock, lblDate);
            #endregion

            // PnlShortcuts
            #region
            Locations.Left(pnlBtnOptions, 10, false, fPnlShortcuts);
            fPnlShortcuts.Top = downBtns[downBtns.Length - 1].Top + 5;
            #endregion
        }
        private void WriteDateTime()
        {
            now = DateTime.Now;

            clock.ClockValue = now.Second;
            clock.Text = DateTimeManager.GetTime(now).Substring(0, 5);
            lblDate.Text = DateTimeManager.GetDate(now);
        }
        private void HidePnlSubOptions()
        {
            pnlSubOptions.Hide();
        }
        private void CreatBtnSubOptions(BtnOption btn)
        {
            for (int i = 0; i < btn.SubOptions.Length; i++)
            {
                BtnSubOptions subOptions = new BtnSubOptions
                {
                    Text = btn.SubOptions[i],
                    Size = btnSubOptionsSize,
                    BtnParent = btn,
                    ContextMenuStrip = btnSubOptionsMenuStrinp
                };
                subOptions.Click += BtnSubOptions_Click;
                subOptions.MouseDown += BtnSubOptions_MouseDown;

                if (btn.Frms != null && btn.Frms.Length >= (i + 1))
                {
                    subOptions.FrmName = btn.Frms[i];
                }

                if (isPnlOptionsUpToDown)
                {
                    subOptions.Top = (i * subOptions.Height + i * btnSubOptionsBetweenSpace);
                }
                else
                {
                    subOptions.Top = pnlSubOptions.Height - ((i + 1) * subOptions.Height) - i * btnSubOptionsBetweenSpace;
                }

                pnlSubOptions.Controls.Add(subOptions);
            }
        }
        private void SetPnlOptionsHeight(BtnOption btn)
        {
            pnlSubOptions.Height = (btn.SubOptions.Length - 1) * btnSubOptionsBetweenSpace + (btn.SubOptions.Length * btnSubOptionsSize.Height);
        }
        private void SetSubPnlOptionsLocation(Button btn)
        {
            if (isPnlOptionsUpToDown)
            {
                pnlSubOptions.Top = btn.Top + 3;
            }
            else
            {
                pnlSubOptions.Top = btn.Top + btn.Height - pnlSubOptions.Height;
            }

            Locations.Left(pnlBtnOptions, 2, true, pnlSubOptions);

            pnlSubOptions.BringToFront();
        }
        private BtnSubOptions CreatShortcut(BtnSubOptions parent)
        {
            BtnSubOptions output = new BtnSubOptions
            {
                Text = parent.Text,
                BackgroundImage = Image.FromFile(Application.StartupPath + "\\Colors\\Gray3.png"),
                Size = new Size(fPnlShortcuts.Width - 3, parent.Height - 5),
                FrmName = parent.FrmName,
                ContextMenuStrip = btnShortcutsMenuStrinp
            };
            output.MouseDown += BtnShortcuts_MouseDown;
            output.Click += BtnShortcuts_Click;

            return output;
        }
        private void ManageIsClickedProperty(BtnOption btn = null)
        {
            foreach (BtnOption item in pnlBtnOptions.Controls.OfType<BtnOption>())
            {
                if (btn != null && item.Name == btn.Name)
                {
                    continue;
                }

                item.IsClicked = false;
            }
        }

        #endregion
        //*************************************
    }
}
