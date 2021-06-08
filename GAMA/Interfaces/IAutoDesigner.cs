using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyClass;

namespace GAMA
{
    public interface IAutoDesigner
    {
        int ColumnCount { get; set; }
        int RowCount { get; set; }
        int Space { get; set; }
        int XSpace { get; set; }
        int YSpace { get; set; }
        AutoDesigner Designer { get; }
    }
}