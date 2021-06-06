using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyClass;

namespace GAMA
{
    class BaseTxt : TextBox, IOrderable, IGAMAControl
    {
        public BaseTxt()
        {
            ForeColor = Color.Black;
            Font = new Font(Theme.FontFamily, 11);
            RightToLeft = RightToLeft.Yes;
            TextAlign = HorizontalAlignment.Center;
        }

        //Properties***************************
        #region 

        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public string PareName { get; set; }

        #endregion
        //*************************************

        //Methods******************************
        #region

        public void AlignCenter(Control ctrl)
        {
            Locations.AlignCenters(ctrl, this);
        }
        public void AlignMiddle(Control ctrl)
        {
            Locations.AlignMiddles(ctrl, this);
        }

        #endregion
        //*************************************
    }
}
