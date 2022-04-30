using System;
using System.Collections.Generic;

#nullable disable

namespace TestDBLibrary
{
    public partial class Post
    {
        public Post()
        {
            AssignmentToPosts = new HashSet<AssignmentToPost>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }

        public virtual ICollection<AssignmentToPost> AssignmentToPosts { get; set; }
    }
}
