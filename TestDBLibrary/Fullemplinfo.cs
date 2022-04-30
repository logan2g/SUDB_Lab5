using System;
using System.Collections.Generic;

#nullable disable

namespace TestDBLibrary
{
    public partial class Fullemplinfo
    {
        public string Empname { get; set; }
        public string Postname { get; set; }
        public int? Salary { get; set; }
        public string Department { get; set; }
        public DateTime? HiringDate { get; set; }
        public DateTime? DismissDate { get; set; }
    }
}
