using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyClass;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace GAMA
{
    public class BaseBtn : Button, IOrderable, IGAMAControl
    {
        public BaseBtn()
        {
            Cursor = Cursors.Hand;
            FlatStyle = Theme.FLATSTYLE_Btn;
            BackColor = Theme.ControlBackColor1;
            ForeColor = Theme.ControlForeColor1;
            Font = new Font(Theme.FontFamily, 13);
            BackgroundImageLayout = ImageLayout.Stretch;
            FlatAppearance.BorderSize = Theme.BORDERSIZE_Btn;
        }
        
        //Properties***************************
        #region 

        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public string PareName { get; set; }
        [Browsable(false)]
        public bool IsClicked { get; set; } = false;

        #endregion
        //*************************************

        //Events*******************************
        #region 

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            IsClicked = !IsClicked;
        }

        #endregion
        //*************************************

        //Methods******************************
        #region

        public void AlignMiddle(Control ctrl)
        {
            Locations.AlignMiddles(ctrl, this);
        }
        public void AlignCenter(Control ctrl)
        {
            Locations.AlignCenters(ctrl, this);
        }

        #endregion
        //*************************************
    }
}
