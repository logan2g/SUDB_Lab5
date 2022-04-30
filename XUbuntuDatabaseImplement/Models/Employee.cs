using System;
using System.Collections.Generic;

#nullable disable

namespace XUbuntuDatabaseImplement.Models
{
    public partial class Employee
    {
        public Employee()
        {
            AssingnmentToPosts = new HashSet<AssignmentToPost>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Surcharge { get; set; }

        public virtual ICollection<AssignmentToPost> AssingnmentToPosts { get; set; }
    }
}
