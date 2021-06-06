using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GAMA
{
    public interface IOrderable 
    {
        int ColumnIndex { get; set; }
        int RowIndex { get; set; }
        string PareName { get; set; }
    }
}
