using System.ComponentModel;

namespace Contracts.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [DisplayName("ФИО")]
        public string Name { get; set; }

        [DisplayName("Доплата")]
        public int Surchashrge { get; set; }
    }
}
