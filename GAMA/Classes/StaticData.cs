using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MyClass
{
    public static class StaticData
    {
        public static readonly int pnlsuboptions_space = 5;

        public static User current_user;
        public static string current_date = DateTimeManager.GetDate(DateTime.Now);
    }
}
