using System;

namespace Contracts.BindingModels
{
    public class AssignmentBindingModel
    {
        public int? Id { get; set; }

        public int PostId { get; set; }

        public int DepartmentId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime HiringDate { get; set; }

        public DateTime DismissDate { get; set; }
    }
}
