using System;

namespace DatabaseImplement.Models
{
    public partial class AssignmentToPost
    {
        public int Id { get; set; }
        public int Departmentid { get; set; }
        public int Postid { get; set; }
        public int Employeeid { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime DismissDate { get; set; }

        public virtual Department Department { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Post Post { get; set; }
    }
}
