using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace Test
{
    public interface ITransitionStrategy
    {
        void Mix(Control target, PropertyInfo property, object minValue, object value, double percent);
    }
}
