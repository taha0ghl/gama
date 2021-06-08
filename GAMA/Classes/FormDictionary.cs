using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GAMA;

namespace MyClass
{
    public static class FormDictionary
    {
        private static readonly Dictionary<string, Form> data = new Dictionary<string, Form>
        {
            { "frmbranch", new FrmBranch() },
            { "frmgroup", new FrmGroup() },
            { "frmstandard", new FrmStandard() },
            { "frmshowacademy", new FrmShowAcademy() },
            { "frmmostanadat", new  FrmMostanadat() },
            { "frmstudent", new FrmStudent() },
            { "frmaddeditstudent", new frmAddEditStudent() },
            { "frmaddeditsabtnam", new FrmAddEditSabtNam(Moods.Add)},
            { "frmsabtnam", new FrmSabtNam() }
        };

        public static Form Get(string frmName)
        {
            Form output = null;

            output = data[frmName.ToLower()];

            return output;
        }
    }
}
