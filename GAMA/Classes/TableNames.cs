using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyClass
{
    public static class TableNames
    {
        //Properties***************************
        #region

        public static string Student 
        {
            get
            {
                return "tbl001_Student";
            }
        }
        public static string BranchCourse
        {
            get
            {
                return "tbl002_BranchCourse";
            }
        }
        public static string GroupCourse
        {
            get
            {
                return "tbl003_GroupCourse";
            }
        }
        public static string Course
        {
            get
            {
                return "tbl004_Course";
            }
        }
        public static string BaseInformation
        {
            get
            {
                return "tbl005_BaseInformation";
            }
        }
        public static string RequiredDocuments
        {
            get
            {
                return "tbl006_RequiredDocuments";
            }
        }

        #endregion
        //*************************************
    }
}
