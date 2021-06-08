using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using MyClass;

namespace GAMA
{
    class BaseCombo : ComboBox, IOrderable, IGAMAControl
    {
        public BaseCombo()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
            Font = new Font(Theme.FontFamily, 12);
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
