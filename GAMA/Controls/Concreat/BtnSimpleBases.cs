using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyClass;

namespace GAMA
{
    public class BtnSimpleBases : BaseBtn , IBtnPro
    {
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
