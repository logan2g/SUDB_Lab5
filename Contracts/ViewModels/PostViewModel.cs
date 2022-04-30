using System.ComponentModel;

namespace Contracts.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        public string PostName { get; set; }

        [DisplayName("Оклад")]
        public int Salary { get; set; }    
    }
}
