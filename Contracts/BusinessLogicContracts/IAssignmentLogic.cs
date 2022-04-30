using Contracts.BindingModels;
using System.Collections.Generic;
using Contracts.ViewModels;

namespace Contracts.BusinessLogicContracts
{
    public interface IAssignmentLogic
    {
        List<AssignmentViewModel> Read(AssignmentBindingModel model);

        void CreateOrUpdate(AssignmentBindingModel model);

        void Delete(AssignmentBindingModel model);
    }
}
