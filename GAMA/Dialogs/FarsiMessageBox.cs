using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MyClass
{
    public enum FarsiMessageBoxButtons
    {
        ناموفق_دوباره_نادیده,//AbortRetryIgnore
        تایید,//OK
        تایید_لغو,//OKCancel
        دوباره_لغو,//RetryCancel
        بلی_خیر,//YesNo
        بلی_خیر_لغو//YesNoCancel
    }
    //________________________________________________________________________________________________________________________________________________________________________________________________________________
    public enum FarsiDialogResult
    {
        ناموفق,//Abort
        لغو,//Cancel
        نادیده,//Ignore
        خیر,//No
        هیچ,//None
        تایید,//OK
        دوباره,//Retry
        بلی//Yes
    }
    //________________________________________________________________________________________________________________________________________________________________________________________________________________
    public enum FarsiMessageBoxIcon
    {
        خطا,//error
        هشدار,//warning
        پرسش,//question
        اطلاعات//information
    }
    //________________________________________________________________________________________________________________________________________________________________________________________________________________
    public enum FarsiMessageBoxDefaultButton
    {
        دکمه1,//button1
        دکمه2,//button2
        دکمه3//button3
    }
    //________________________________________________________________________________________________________________________________________________________________________________________________________________
    static class FarsiMessageBox
    {
        //-----this class form in farsi message box---
        private class FarsiForm : Form
        {
            Label lblshow = new Label();
            PictureBox pictureboxshow = new PictureBox();
            //----//
            private void InitializeForm()
            {
                this.TopMost = true;
                this.BackColor = Color.White;
                this.RightToLeft = RightToLeft.Yes;
                this.RightToLeftLayout = true;
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.ControlBox = false;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Height = 135;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.ShowInTaskbar = false;
                lblshow.Location = new Point(20, 30);
                lblshow.AutoSize = true;
                this.Controls.Add(lblshow);
                pictureboxshow.Size = new Size(0, 32);
                pictureboxshow.SizeMode = PictureBoxSizeMode.Zoom;
                pictureboxshow.Location = new Point(10, 30);
                this.Controls.Add(pictureboxshow);
            }
            //--------------------//
            public FarsiForm(string text)
            {
                InitializeForm();
                lblshow.Text = text;
                OK();
            }
            //--------------------//
            public FarsiForm(string text,string caption)
            {
                InitializeForm();
                lblshow.Text = text;
                this.Text = caption;
                OK();
            }
            //--------------------//
            public FarsiForm(string text, string caption, FarsiMessageBoxButtons farsibuttons)
            {
                InitializeForm();
                lblshow.Text = text;
                this.Text = caption;
                switch (farsibuttons)
                {
                    case FarsiMessageBoxButtons.ناموفق_دوباره_نادیده:
                        AbortRetryIgnore();
                        break;
                    case FarsiMessageBoxButtons.تایید:
                        OK();
                        break;
                    case FarsiMessageBoxButtons.تایید_لغو:
                        OKCancel();
                        break;
                    case FarsiMessageBoxButtons.دوباره_لغو:
                        RetryCancel();
                        break;
                    case FarsiMessageBoxButtons.بلی_خیر:
                        YesNo();
                        break;
                    case FarsiMessageBoxButtons.بلی_خیر_لغو:
                        YesNoCancel();
                        break;
                }
            }
            //--------------------//
            public FarsiForm(string text, string caption, FarsiMessageBoxButtons farsibuttons, FarsiMessageBoxIcon farsiicon)
            {
                InitializeForm();
                lblshow.Text = text;
                this.Text = caption;
                pictureboxshow.Width = 32;
                switch (farsibuttons)
                {
                    case FarsiMessageBoxButtons.ناموفق_دوباره_نادیده:
                        AbortRetryIgnore();
                        break;
                    case FarsiMessageBoxButtons.تایید:
                        OK();
                        break;
                    case FarsiMessageBoxButtons.تایید_لغو:
                        OKCancel();
                        break;
                    case FarsiMessageBoxButtons.دوباره_لغو:
                        RetryCancel();
                        break;
                    case FarsiMessageBoxButtons.بلی_خیر:
                        YesNo();
                        break;
                    case FarsiMessageBoxButtons.بلی_خیر_لغو:
                        YesNoCancel();
                        break;
                }
                switch (farsiicon)
                {
                    case FarsiMessageBoxIcon.خطا:
                        pictureboxshow.Image = Image.FromFile(Application.StartupPath + "\\pic\\Error.png");
                        System.Media.SystemSounds.Hand.Play();
                        break;
                    case FarsiMessageBoxIcon.هشدار:
                        pictureboxshow.Image = Image.FromFile(Application.StartupPath + "\\pic\\Warning.png");
                        System.Media.SystemSounds.Exclamation.Play();
                        break;
                    case FarsiMessageBoxIcon.پرسش:
                        pictureboxshow.Image = Image.FromFile(Application.StartupPath + "\\pic\\Question.jpg");
                        System.Media.SystemSounds.Question.Play();
                        break;
                    case FarsiMessageBoxIcon.اطلاعات:
                        pictureboxshow.Image = Image.FromFile(Application.StartupPath + "\\pic\\Information.png");
                        System.Media.SystemSounds.Asterisk.Play();
                        break;
                }
                pictureboxshow.Left = this.Width - 50;
                pictureboxshow.Top = lblshow.Top - 10;
            }
            //--------------------//
            public FarsiForm(string text, string caption, FarsiMessageBoxButtons farsibuttons, FarsiMessageBoxIcon farsiicon, FarsiMessageBoxDefaultButton farsidefault)
            {
                InitializeForm();
                lblshow.Text = text;
                this.Text = caption;
                pictureboxshow.Width = 32;
                switch (farsibuttons)
                {
                    case FarsiMessageBoxButtons.ناموفق_دوباره_نادیده:
                        AbortRetryIgnore();
                        break;
                    case FarsiMessageBoxButtons.تایید:
                        OK();
                        break;
                    case FarsiMessageBoxButtons.تایید_لغو:
                        OKCancel();
                        break;
                    case FarsiMessageBoxButtons.دوباره_لغو:
                        RetryCancel();
                        break;
                    case FarsiMessageBoxButtons.بلی_خیر:
                        YesNo();
                        break;
                    case FarsiMessageBoxButtons.بلی_خیر_لغو:
                        YesNoCancel();
                        break;
                }
                switch (farsiicon)
                {
                    case FarsiMessageBoxIcon.خطا:
                        pictureboxshow.Image = Image.FromFile(Application.StartupPath + "\\pic\\Error.png");
                        System.Media.SystemSounds.Hand.Play();
                        break;
                    case FarsiMessageBoxIcon.هشدار:
                        pictureboxshow.Image = Image.FromFile(Application.StartupPath + "\\pic\\Warning.png");
                        System.Media.SystemSounds.Exclamation.Play();
                        break;
                    case FarsiMessageBoxIcon.پرسش:
                        pictureboxshow.Image = Image.FromFile(Application.StartupPath + "\\pic\\Question.jpg");
                        System.Media.SystemSounds.Question.Play();
                        break;
                    case FarsiMessageBoxIcon.اطلاعات:
                        pictureboxshow.Image = Image.FromFile(Application.StartupPath + "\\pic\\Information.png");
                        System.Media.SystemSounds.Asterisk.Play();
                        break;
                }
                pictureboxshow.Left = this.Width - 50;
                pictureboxshow.Top = lblshow.Top - 10;
                Point p = new Point(0, 0);
                switch (farsidefault)
                {
                    case FarsiMessageBoxDefaultButton.دکمه1:
                        p = new Point(20, 70);
                        break;
                    case FarsiMessageBoxDefaultButton.دکمه2:
                        p = new Point(120, 70);
                        break;
                    case FarsiMessageBoxDefaultButton.دکمه3:
                        p = new Point(220, 70);
                        break;
                }
                int i;
                for (i = 0; i < this.Controls.Count; i++)
                {
                    if (Controls[i] is Button && Controls[i].Location.X == p.X && Controls[i].Location.Y == p.Y)
                    {
                        this.AcceptButton = Controls[i] as Button;
                        Controls[i].TabIndex = 0;
                        break;
                    }
                }
                int j = 1;
                int k = i;
                while (true)
                {
                    try
                    {
                        k++;
                        if (k == i)
                            break;
                        Controls[k].TabIndex = j;
                        j++;
                    }
                    catch (Exception)
                    {
                        k = 0;
                        if (k == i)
                            break;
                        Controls[k].TabIndex = j;
                        j++;
                    }
                }
            }
            //--------------------//
            private void OK()
            {
                Button ok = new Button();
                ok.Text = "تایید";
                ok.Size = new Size(90, 27);
                ok.Location = new Point(20, 70);
                ok.DialogResult = DialogResult.OK;
                ok.BackColor = Color.FromArgb(225, 225, 225);//Color.Transparent;
                ok.FlatStyle = FlatStyle.Flat;
                ok.FlatAppearance.BorderColor = Color.FromArgb(173, 173, 173);
                ok.Cursor = Cursors.Hand;
                this.Controls.Add(ok);
                int w = lblshow.Width + (int)(pictureboxshow.Width * 1.5) + 35;
                this.Width = (130 < w) ? w : 130;
                this.CancelButton = ok;
            }
            //--------------------//
            private void AbortRetryIgnore()
            {
                Button abort = new Button();
                Button retry = new Button();
                Button ignore = new Button();
                abort.Text = "ناموفق";
                abort.Size = new Size(90, 27);
                abort.Location = new Point(20, 70);
                abort.DialogResult = DialogResult.Abort;
                abort.BackColor = Color.FromArgb(225, 225, 225);//Color.Transparent;
                abort.FlatAppearance.BorderColor = Color.FromArgb(173, 173, 173);
                abort.FlatStyle = FlatStyle.Flat;
                abort.Cursor = Cursors.Hand;
                this.Controls.Add(abort);
                retry.Text = "دوباره";
                retry.Size = new Size(90, 27);
                retry.Location = new Point(120, 70);//+100
                retry.DialogResult = DialogResult.Retry;
                retry.BackColor = Color.FromArgb(225, 225, 225);//Color.Transparent;
                retry.FlatAppearance.BorderColor = Color.FromArgb(173, 173, 173);
                retry.FlatStyle = FlatStyle.Flat;
                retry.Cursor = Cursors.Hand;
                this.Controls.Add(retry);
                ignore.Text = "نادیده";
                ignore.Size = new Size(90, 27);
                ignore.Location = new Point(220, 70);
                ignore.DialogResult = DialogResult.Ignore;
                ignore.BackColor = Color.FromArgb(225, 225, 225);//Color.Transparent;
                ignore.FlatAppearance.BorderColor = Color.FromArgb(173, 173, 173);
                ignore.FlatStyle = FlatStyle.Flat;
                ignore.Cursor = Cursors.Hand;
                this.Controls.Add(ignore);
                int w = lblshow.Width + (int)(pictureboxshow.Width * 1.5) + 35;
                this.Width = (330 < w) ? w : 330;
            }
            //--------------------//
            private void OKCancel()
            {
                OK();
                Button cancel = new Button();
                cancel.Cursor = Cursors.Hand;
                cancel.Text = "لغو";
                cancel.Size = new Size(90, 27);
                cancel.Location = new Point(120, 70);//+100
                cancel.DialogResult = DialogResult.Cancel;
                cancel.BackColor = Color.FromArgb(225, 225, 225);//Color.Transparent;
                cancel.FlatAppearance.BorderColor = Color.FromArgb(173, 173, 173);
                cancel.FlatStyle = FlatStyle.Flat;
                this.Controls.Add(cancel);
                int w = lblshow.Width + (int)(pictureboxshow.Width * 1.5) + 35;
                this.Width = (230 < w) ? w : 230;
            }
            //--------------------//
            private void RetryCancel()
            {
                Button retry = new Button();
                Button cancel = new Button();
                retry.Text = "دوباره";
                retry.Size = new Size(90, 27);
                retry.Location = new Point(20, 70);
                retry.DialogResult = DialogResult.Retry;
                retry.BackColor = Color.FromArgb(225, 225, 225);//Color.Transparent;
                retry.FlatAppearance.BorderColor = Color.FromArgb(173, 173, 173);
                retry.FlatStyle = FlatStyle.Flat;
                retry.Cursor = Cursors.Hand;
                this.Controls.Add(retry);
                cancel.Text = "لغو";
                cancel.Size = new Size(90, 27);
                cancel.Location = new Point(120, 70);//+100
                cancel.DialogResult = DialogResult.Cancel;
                cancel.BackColor = Color.FromArgb(225, 225, 225);//Color.Transparent;
                cancel.FlatAppearance.BorderColor = Color.FromArgb(173, 173, 173);
                cancel.FlatStyle = FlatStyle.Flat;
                cancel.Cursor = Cursors.Hand;
                this.Controls.Add(cancel);
                int w = lblshow.Width + (int)(pictureboxshow.Width * 1.5) + 35;
                this.Width = (230 < w) ? w : 230;
                this.CancelButton = cancel;
            }
            //--------------------//
            private void YesNo()
            {
                Button yes = new Button();
                Button no = new Button();
                yes.Text = "بلی";
                yes.Size = new Size(90, 27);
                yes.Location = new Point(20, 70);
                yes.DialogResult = DialogResult.Yes;
                yes.BackColor = Color.FromArgb(225, 225, 225);//Color.Transparent;
                yes.FlatAppearance.BorderColor = Color.FromArgb(173, 173, 173);
                yes.FlatStyle = FlatStyle.Flat;
                yes.Cursor = Cursors.Hand;
                this.Controls.Add(yes);
                no.Text = "خیر";
                no.Size = new Size(90, 27);
                no.Location = new Point(120, 70);//+100
                no.DialogResult = DialogResult.No;
                no.BackColor = Color.FromArgb(225, 225, 225);//Color.Transparent;
                no.FlatAppearance.BorderColor = Color.FromArgb(173, 173, 173);
                no.FlatStyle = FlatStyle.Flat;
                no.Cursor = Cursors.Hand;
                this.Controls.Add(no);
                int w = lblshow.Width + (int)(pictureboxshow.Width * 1.5) + 35;
                this.Width = (230 < w) ? w : 230;
                this.CancelButton = no;
            }
            //--------------------//
            private void YesNoCancel()
            {
                YesNo();
                Button cancel = new Button();
                cancel.Cursor = Cursors.Hand;
                cancel.Text = "لغو";
                cancel.Size = new Size(90, 27);
                cancel.Location = new Point(220, 70);
                cancel.DialogResult = DialogResult.Cancel;
                cancel.BackColor = Color.FromArgb(225, 225, 225);//Color.Transparent;
                cancel.FlatAppearance.BorderColor = Color.FromArgb(173, 173, 173);
                cancel.FlatStyle = FlatStyle.Flat;
                this.Controls.Add(cancel);
                int w = lblshow.Width + (int)(pictureboxshow.Width * 1.5) + 35;
                this.Width = (330 < w) ? w : 330;
                this.CancelButton = cancel;
            }
        }//END FORM------------
        //--------------------//
        public static FarsiDialogResult Show(string text)
        {
            FarsiForm f = new FarsiForm(text);
            DialogResult d = f.ShowDialog();
            return ChangeDialogResultToFarsi(d);
        }
        //--------------------//
        public static FarsiDialogResult Show(string text, string caption)
        {
            FarsiForm f = new FarsiForm(text,caption);
            DialogResult d = f.ShowDialog();
            return ChangeDialogResultToFarsi(d);
        }
        //--------------------//
        public static FarsiDialogResult Show(string text, string caption, FarsiMessageBoxButtons farsibuttons)
        {
            FarsiForm f = new FarsiForm(text, caption,farsibuttons);
            DialogResult d = f.ShowDialog();
            return ChangeDialogResultToFarsi(d);
        }
        //--------------------//
        public static FarsiDialogResult Show(string text, string caption, FarsiMessageBoxButtons farsibuttons,FarsiMessageBoxIcon farsiicon)
        {
            FarsiForm f = new FarsiForm(text, caption, farsibuttons, farsiicon);
            DialogResult d = f.ShowDialog();
            return ChangeDialogResultToFarsi(d);
        }
        //--------------------//
        public static FarsiDialogResult Show(string text, string caption, FarsiMessageBoxButtons farsibuttons, FarsiMessageBoxIcon farsiicon, FarsiMessageBoxDefaultButton farsidefault)
        {
            FarsiForm f = new FarsiForm(text, caption, farsibuttons, farsiicon, farsidefault);
            DialogResult d = f.ShowDialog();            
            return ChangeDialogResultToFarsi(d);
        }
        //--------------------------------------------//
        private static FarsiDialogResult ChangeDialogResultToFarsi(DialogResult d)
        {
            switch (d)
            {
                case DialogResult.Abort:
                    return FarsiDialogResult.ناموفق;
                case DialogResult.Cancel:
                    return FarsiDialogResult.لغو;
                case DialogResult.Ignore:
                    return FarsiDialogResult.نادیده;
                case DialogResult.No:
                    return FarsiDialogResult.خیر;
                case DialogResult.OK:
                    return FarsiDialogResult.تایید;
                case DialogResult.Retry:
                    return FarsiDialogResult.دوباره;
                case DialogResult.Yes:
                    return FarsiDialogResult.بلی;
            }
            return FarsiDialogResult.هیچ;//none
        }
    }
    //________________________________________________________________________________________________________________________________________________________________________________________________________________
}