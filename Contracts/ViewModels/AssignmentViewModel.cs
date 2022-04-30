using System;
using System.ComponentModel;

namespace Contracts.ViewModels
{
    public class AssignmentViewModel
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public int DepartmentId { get; set; }

        public int EmployeeId { get; set; }

        [DisplayName("Дата принятия")]
        public DateTime HiringDate { get; set; }

        [DisplayName("Дата увольнения")]
        public DateTime DismissDate { get; set; }
    }
}
