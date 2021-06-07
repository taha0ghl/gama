using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using GAMA;

namespace MyClass
{
    public class AutoDesigner
    {
        public AutoDesigner(Control p)
        {
            parent = p;
        }

        private readonly Control parent;

        public void SetSize()
        {
            int XbetweenPareSpace = (parent as IAutoDesigner).XSpace;
            int YbetweenPareSpace = (parent as IAutoDesigner).YSpace;
            int space = (parent as IAutoDesigner).Space;

            // Calculating Width
            int width = 0;
            for (int i = 1; i <= (parent as IAutoDesigner).ColumnCount; i++)
            {
                int maxWidth = FindMaxWidthLbl(i).Width;
                int maxWidthPare = FindMaxWidthPare(i).Width;
                width += maxWidth + XbetweenPareSpace + maxWidthPare + space;
            }
            width -= space;

            // Calulating Height
            int height = 0;
            for (int i = 1; i <= (parent as IAutoDesigner).RowCount; i++)
            {
                height += FindPareControl(1, i).Height + YbetweenPareSpace;
            }
            height -= YbetweenPareSpace;

            parent.Width = width;
            parent.Height = height;
        }
        public void SetLocation()
        {
            int XbetweenPareSpace = (parent as IAutoDesigner).XSpace;
            int YbetweenPareSpace = (parent as IAutoDesigner).YSpace;
            int space = (parent as IAutoDesigner).Space;
            int remainWidht = 0;

            for (int i = 1; i <= (parent as IAutoDesigner).ColumnCount; i++)
            {
                BaseLbl constLbl = FindMaxWidthLbl(i);
                Control constCtrl = FindMaxWidthPare(i);
                ArrayList sameColumnLbls = SameColumnLbl(i);

                // Set First Pare Of The Column
                Locations.RightOrder(parent,
                    remainWidht +
                    (constLbl.ColumnIndex - 1) * space +
                    (constLbl.ColumnIndex - 1) * XbetweenPareSpace,
                    constLbl);

                Locations.Left(constLbl, XbetweenPareSpace, false, constCtrl);

                remainWidht += constLbl.Width + constCtrl.Width;

                // Set The Rest Of The Pares
                for (int j = 0; j < sameColumnLbls.Count; j++)
                {
                    BaseLbl lbl = sameColumnLbls[j] as BaseLbl;
                    Control ctrl = parent.Controls[lbl.PareName];

                    // X
                    Locations.AlignRights(constLbl, lbl);
                    Locations.AlignRights(constCtrl, ctrl);

                    // Y

                    ctrl.Top = (lbl.RowIndex - 1) * (YbetweenPareSpace + constCtrl.Height);
                    Locations.AlignMiddles(ctrl, lbl);
                }
            }
        }

        private BaseLbl FindMaxWidthLbl(int colIndex)
        {
            BaseLbl output = new BaseLbl();
            output.Width = 0;

            ArrayList sameColLbls = SameColumnLbl(colIndex);

            for (int i = 0; i < sameColLbls.Count; i++)
            {
                if ((sameColLbls[i] as BaseLbl).Width > output.Width)
                {
                    output = sameColLbls[i] as BaseLbl;
                }
            }

            return output;
        }
        private Control FindMaxWidthPare(int colIndex)
        {
            Control output = new Control();
            output.Width = 0;

            foreach (Control item in parent.Controls)
            {
                if (item is IOrderable && !(item is BaseLbl))
                {
                    if ((item as IOrderable).ColumnIndex == colIndex)
                    {
                        if (item.Width > output.Width)
                        {
                            output = item;
                        }
                    }
                }
            }

            return output;
        }
        private ArrayList SameColumnLbl(int colmnIndex)
        {
            ArrayList ouput = new ArrayList();

            foreach (BaseLbl item in parent.Controls.OfType<BaseLbl>())
            {
                if (item.ColumnIndex == colmnIndex)
                {
                    ouput.Add(item);
                }
            }

            return ouput;
        }
        private Control FindPareControl(int columnIndex, int rowIndex)
        {
            Control output = new BaseLbl();

            foreach (Control item in parent.Controls.OfType<Control>())
            {
                if (item is IOrderable)
                {
                    if ((item as IOrderable).ColumnIndex == columnIndex && (item as IOrderable).RowIndex == rowIndex && !(item is BaseLbl))
                    {
                        output = item;
                        break;
                    }
                }
            }

            return output;
        }
    }
}
