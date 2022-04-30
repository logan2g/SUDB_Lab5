using Contracts.StorageContracts;
using Contracts.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseImplement.Implements
{
    public class FullEmplInfoStorage : IFullEmplInfoStorage
    {
        public List<FullEmplInfoViewModel> GetFullList()
        {
            using var context = new Database();
            return context.Fullemplinfos.Select(CreateModel).ToList();
        }

        private FullEmplInfoViewModel CreateModel(Fullemplinfo info)
        {
            return new FullEmplInfoViewModel
            {
                Empname = info.Empname,
                Postname = info.Postname,
                Salary = info.Salary,
                Department = info.Department,
                HiringDate = info.HiringDate,
                DismissDate = info.DismissDate
            };
        }
    }
}
