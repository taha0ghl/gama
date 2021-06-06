using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyClass
{
    public class Student : User
    {
        public Student(string id)
        {
            Id = id;
            string condition = string.Format("Id = {0}", id);

            FirstName = SqlServerClass.Select(TableNames.Student, "fName", condition);
            LastName = SqlServerClass.Select(TableNames.Student, "lName", condition);
            NCode = SqlServerClass.Select(TableNames.Student, "ncode", condition);
            NationalId = SqlServerClass.Select(TableNames.Student, "nationalCode", condition);
            //Gender = SqlServerClass.Select(TableNames.Student, "Gender", condition);
            //Marriage = SqlServerClass.Select(TableNames.Student, "Married", condition);
            IssuePlace = SqlServerClass.Select(TableNames.Student, "issuePlace", condition);
            BirthDate = SqlServerClass.Select(TableNames.Student, "birthDate", condition);
            Father = SqlServerClass.Select(TableNames.Student, "Father", condition);
            Mother = SqlServerClass.Select(TableNames.Student, "Mother", condition);
            Education = SqlServerClass.Select(TableNames.Student, "Education", condition);
            Tel = SqlServerClass.Select(TableNames.Student, "Tel", condition);
            Mobile = SqlServerClass.Select(TableNames.Student, "Mobile", condition);
            TelegramNumber = SqlServerClass.Select(TableNames.Student, "TelegramNumber", condition);
            Job = SqlServerClass.Select(TableNames.Student, "StudentJob", condition);
            Address = SqlServerClass.Select(TableNames.Student, "Address", condition);
            PostalCode = SqlServerClass.Select(TableNames.Student, "PostalCode", condition);
            Email = SqlServerClass.Select(TableNames.Student, "Email", condition);
            //Picture = SqlServerClass.Select(TableNames.Student, "Pic", condition);
            //Signature = SqlServerClass.Select(TableNames.Student, "Signature", condition);
        }

        public string NCode { get; set; }
        public Gender Gender { get; set; }
        public Marriage Marriage { get; set; }
        public string IssuePlace { get; set; }
        public string BirthDate { get; set; }
        public string Father { get; set; }
        public string Mother { get; set; }
        public string Education { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public string TelegramNumber { get; set; }
        public string Job { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public Image Signature { get; set; }
    }
}
