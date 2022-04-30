using Contracts.BindingModels;
using System.Collections.Generic;
using Contracts.ViewModels;

namespace Contracts.BusinessLogicContracts
{
    public interface IEmployeeLogic
    {
        List<EmployeeViewModel> Read(EmployeeBindingModel model);

        void CreateOrUpdate(EmployeeBindingModel model);

        void Delete(EmployeeBindingModel model);
    }
}
