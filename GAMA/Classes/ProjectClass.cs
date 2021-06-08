using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace MyClass
{
    static class ProjectClass
    {
        public static void DrawBorder(Graphics gr, Pen p, int space, int fullwidth, int fullheight, double nesbat)
        {
            int x1 = space, y1 = space;

            int x2 = Convert.ToInt32(fullwidth - p.Width - space), y2 = y1;

            int x3 = x1, y3 = Convert.ToInt32(fullheight - p.Width - space);

            int x4 = x2, y4 = y3;

            int w = Convert.ToInt32(fullwidth * nesbat), h = Convert.ToInt32(fullheight * nesbat);

            gr.DrawLine(p, new Point(x1, y1), new Point((x1 + w), y1));
            gr.DrawLine(p, new Point(x1, y1), new Point(x1, (y1 + h)));

            gr.DrawLine(p, new Point(x2, y2), new Point((x2 - w), y2));
            gr.DrawLine(p, new Point(x2, y2), new Point(x2, (y2 + h)));

            gr.DrawLine(p, new Point(x3, y3), new Point((x3 + w), y3));
            gr.DrawLine(p, new Point(x3, y3), new Point(x3, (y3 - h)));

            gr.DrawLine(p, new Point(x4, y4), new Point((x4 - w), y4));
            gr.DrawLine(p, new Point(x4, y4), new Point(x4, (y4 - h)));
        }

    }
}
