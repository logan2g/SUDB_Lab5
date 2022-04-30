using System;
using System.Collections.Generic;

#nullable disable

namespace TestDBLibrary
{
    public partial class Department
    {
        public Department()
        {
            AssignmentToPosts = new HashSet<AssignmentToPost>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AssignmentToPost> AssignmentToPosts { get; set; }
    }
}
