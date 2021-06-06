using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyClass;

namespace GAMA
{
    class PnlAutoDesign : BasePnl, IAutoDesigner
    {
        public int Space { get; set; } = 10;
        public int XSpace { get; set; } = 25;
        public int YSpace { get; set; } = 5;
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }
        public AutoDesigner Designer
        {
            get
            {
                return new AutoDesigner(this);
            }
        }
    }
}
