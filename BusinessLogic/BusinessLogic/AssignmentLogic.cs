using System;
using Contracts.StorageContracts;
using Contracts.BusinessLogicContracts;
using Contracts.BindingModels;
using System.Collections.Generic;
using Contracts.ViewModels;

namespace BusinessLogic.BusinessLogic
{
    public class AssignmentLogic : IAssignmentLogic
    {
        private readonly IAssignmentStorage _assignmentStorage;

        public AssignmentLogic(IAssignmentStorage assignmentStorage)
        {
            _assignmentStorage = assignmentStorage;
        }

        public List<AssignmentViewModel> Read(AssignmentBindingModel model)
        {
            if (model == null) return _assignmentStorage.GetFullList();
            if (model.Id.HasValue) return new List<AssignmentViewModel> { _assignmentStorage.GetElement(model) };
            return _assignmentStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(AssignmentBindingModel model)
        {
            if (model.Id.HasValue) _assignmentStorage.Update(model);
            else _assignmentStorage.Insert(model);
        }

        public void Delete(AssignmentBindingModel model)
        {
            var assign = _assignmentStorage.GetElement(new AssignmentBindingModel { Id = model.Id });
            if (assign == null) throw new Exception("Назначене не найдено");

            _assignmentStorage.Delete(model);
        }
    }
}
