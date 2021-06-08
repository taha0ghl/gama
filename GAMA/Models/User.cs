using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyClass
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public Image Picture { get; set; }
        public Rank Rank { get; set; }
        public string Id { get; set; }
    }
}
