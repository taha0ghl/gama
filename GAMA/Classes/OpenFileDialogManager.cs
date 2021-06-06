using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GAMA
{
    public static class OpenFileDialogManager
    {
        public static OpenFileDialog Picture(bool multiSelect, string title)
        {
            OpenFileDialog output;

            output = new OpenFileDialog
            {
                Title = title,
                Multiselect = multiSelect
            };

            return output;
        }
        public static Bitmap Picture(OpenFileDialog picexplorer)
        {
            Bitmap output;

            if (picexplorer.ShowDialog() == DialogResult.OK)
            {
                output = new Bitmap(picexplorer.FileName);
            }
            else
            {
                output = null;
            }

            return output;
        }
    }
}
