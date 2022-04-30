using Contracts.BindingModels;
using System.Collections.Generic;
using Contracts.ViewModels;

namespace Contracts.BusinessLogicContracts
{
    public interface IDepartmentLogic
    {
        List<DepartmentViewModel> Read(DepartmentBindingModel model);

        void CreateOrUpdate(DepartmentBindingModel model);

        void Delete(DepartmentBindingModel modeol);
    }
}
