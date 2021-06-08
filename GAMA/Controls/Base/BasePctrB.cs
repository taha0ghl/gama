using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyClass;

namespace GAMA
{
    public class BasePctrB : PictureBox, IOrderable
    {
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
