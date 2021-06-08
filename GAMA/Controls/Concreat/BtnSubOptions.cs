using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using MyClass;
using System.IO;

namespace GAMA
{
    public class BtnSubOptions : BaseBtn, IBtnPro
    {
        public BtnSubOptions()
        {
            Font = new Font(Theme.FontFamily, 11);
            Left = StaticData.pnlsuboptions_space;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.BorderColor = BackColor;

            if (File.Exists(Application.StartupPath + "\\Colors\\Perpel.png"))
            {
                BackgroundImage = Image.FromFile(Application.StartupPath + "\\Colors\\Perpel.png"); ;
            }
        }

        //Properties***************************
        #region 

        public string FrmName { get; set; }
        public BtnOption BtnParent { get; set; }

        #endregion
        //*************************************

        //Events*******************************
        #region

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (FrmName == null || FrmName == string.Empty)
            {
                return;
            }

            (FormDictionary.Get(FrmName)).ShowDialog();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            EnterBtn();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            LeaveBtn();
        }

        #endregion
        //*************************************

        //Methods******************************
        #region

        public void EnterBtn()
        {
            Left -= StaticData.pnlsuboptions_space;
            Font = new Font(Font, FontStyle.Bold);
        }
        public void LeaveBtn()
        {
            Left += StaticData.pnlsuboptions_space;
            Font = new Font(Font, FontStyle.Regular);
        }

        #endregion
        //*************************************
    }
}
