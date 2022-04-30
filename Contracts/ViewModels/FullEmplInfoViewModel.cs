using System.ComponentModel;
using System;

namespace Contracts.ViewModels
{
    public class FullEmplInfoViewModel
    {
        [DisplayName("ФИО работника")]
        public string Empname { get; set; }

        [DisplayName("Должность")]
        public string Postname { get; set; }

        [DisplayName("Зарплата")]
        public int? Salary { get; set; }

        [DisplayName("Отдел")]
        public string Department { get; set; }

        [DisplayName("Дата принятия")]
        public DateTime? HiringDate { get; set; }

        [DisplayName("Дата увольнения")]
        public DateTime? DismissDate { get; set; }
    }
}
