using System.Collections.Generic;
using Contracts.BindingModels;
using Contracts.ViewModels;

namespace Contracts.StorageContracts
{
    public interface IAssignmentStorage
    {
        List<AssignmentViewModel> GetFullList();

        List<AssignmentViewModel> GetFilteredList(AssignmentBindingModel model);

        AssignmentViewModel GetElement(AssignmentBindingModel model);

        void Insert(AssignmentBindingModel model);

        void Update(AssignmentBindingModel model);

        void Delete(AssignmentBindingModel model);
    }
}
