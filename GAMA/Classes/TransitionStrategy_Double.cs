using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAMA
{
    public class TransitionStrategy_Double : ITransitionStrategy
    {
        public void Mix(Control target, PropertyInfo property, object minValue, object maxValue, double percent)
        {
            double distinct = ((double)maxValue) - ((double)minValue);
            double result = ((double)minValue) + distinct * percent;
            target.Invoke((MethodInvoker)delegate
            {
<<<<<<< HEAD
                //property.SetValue(target, result);
=======
                property.SetValue(target, result, null);
>>>>>>> ab7a4dc09ef241f6bfc41036749769e59d6837f0
            });
        }
    }
}
