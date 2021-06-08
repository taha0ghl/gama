using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using MyClass;

namespace GAMA
{
    public class BtnOption : BaseBtn , IBtnPro
    {
        public BtnOption()
        {
            Font = new Font(Theme.FontFamily, 15);
            ImageAlign = ContentAlignment.MiddleLeft;
        }

        //Variables****************************
        #region 

        private string[] _frms;
        private string[] _subOptions;

        #endregion
        //*************************************

        //Properties***************************
        #region 

        public string[] Frms
        {
            get
            {
                return _frms;
            }
            set
            {
                _frms = value;
            }
        }
        [Browsable(true)]
        public string[] SubOptions
        {
            get
            {
                return _subOptions;
            }
            set
            {
                _subOptions = value;
            }
        }

        #endregion
        //*************************************

        //Events*******************************
        #region 

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
            Font = new Font(Font, FontStyle.Bold);
        }
        public void LeaveBtn()
        {
            Font = new Font(Font, FontStyle.Regular);
        }

        #endregion
        //*************************************
    }
}
