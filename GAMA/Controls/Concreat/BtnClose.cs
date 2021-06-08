using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyClass;

namespace GAMA
{
    class BtnClose : BaseBtn
    {
        public BtnClose()
        {
            Size = new Size(25, 25);
            Text = string.Empty;
            BackColor = Theme.HeaderColor;
        }

        //Events*******************************
        #region

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            CloseParent(this);
        }

        #endregion
        //*************************************

        //Methods******************************
        #region

        private void CloseParent(Control ctrl)
        {
            if (ctrl.Parent is Form)
            {
                (ctrl.Parent as Form).Close();
            }
            else
            {
                CloseParent(ctrl.Parent);
            }
        }

        #endregion
        //*************************************
    }
}
