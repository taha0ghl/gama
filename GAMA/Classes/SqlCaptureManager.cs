using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyClass;
using System.Drawing;

namespace MyClass
{
    public static class SqlCaptureManager
    {
        public static ArrayList AllBranchs()
        {
            ArrayList output;

            output = SqlServerClass.GetAllField_ArrayList(TableNames.BranchCourse, "branchName");

            return output;
        }
        public static ArrayList AllGroups()
        {
            ArrayList output;

            output = SqlServerClass.GetAllField_ArrayList(TableNames.GroupCourse, "groupName");

            return output;
        }
        public static ArrayList AllCourse()
        {
            ArrayList output;

            output = SqlServerClass.GetAllField_ArrayList(TableNames.Course, "courseName");

            return output;
        }
        public static string DepartmentName()
        {
            string output = string.Empty;

            output = SqlServerClass.Select(TableNames.Base, "AcademyName", "Id = 1");

            return output;
        }
        public static string RequirdDocumants()
        {
            string output;

            output = SqlServerClass.Select(TableNames.Base, "DataPayeSabtNam");

            return output;
        }
        public static ArrayList NumberList(int first, int last)
        {
            ArrayList output = new ArrayList();

            for (int i = first; i <= last; i++)
            {
                output.Add(i);
            }

            return output;
        }
    }
}
