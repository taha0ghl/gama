using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Test
{
    public class TransitionStrategy_Color : ITransitionStrategy
    {
        public void Mix(Control target, PropertyInfo property, object minValue, object value, double percent)
        {
            Color result = Blend((Color)value, (Color)minValue, percent);
            target.Invoke((MethodInvoker)delegate
            {
                property.SetValue(target, result);
            });
        }

        /// <summary>
        /// It Combines two color 
        /// </summary>
        /// <param name="backColor">first color</param>
        /// <param name="color">the color that is under the main color</param>
        /// <param name="amount">how much of <paramref name="backColor"/> to keep</param>
        /// <returns>the blended color</returns>
        public static Color Blend(Color backColor, Color color, double amount)
        {
            byte r = (byte)((backColor.R * amount) + color.R * (1 - amount));
            byte g = (byte)((backColor.G * amount) + color.G * (1 - amount));
            byte b = (byte)((backColor.B * amount) + color.B * (1 - amount));
            return Color.FromArgb(r, g, b);
        }
    }
}
