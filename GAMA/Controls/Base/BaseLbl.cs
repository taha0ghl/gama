using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using MyClass;

namespace GAMA
{
    public class BaseLbl : Label, IOrderable , IGAMAControl
    {
        public BaseLbl()
        {
            ForeColor = Color.Black;
            Font = new Font(Theme.FontFamily, 13);
            RightToLeft = RightToLeft.Yes;
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
