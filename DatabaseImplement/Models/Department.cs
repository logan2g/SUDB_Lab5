using System.Collections.Generic;

namespace DatabaseImplement.Models
{
    public partial class Department
    {
        public Department()
        {
            AssingnmentToPosts = new HashSet<AssignmentToPost>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AssignmentToPost> AssingnmentToPosts { get; set; }
    }
}
