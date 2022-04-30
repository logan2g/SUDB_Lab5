using System.ComponentModel;

namespace Contracts.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }

        [DisplayName("Имя отдела")]
        public string DepartmentName { get; set; }
    }
}
