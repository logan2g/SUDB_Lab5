using System;
using Contracts.StorageContracts;
using Contracts.BusinessLogicContracts;
using Contracts.BindingModels;
using System.Collections.Generic;
using Contracts.ViewModels;

namespace BusinessLogic.BusinessLogic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IEmployeeStorage _employeeStorage;

        public EmployeeLogic(IEmployeeStorage employeeStorage)
        {
            _employeeStorage = employeeStorage;
        }

        public List<EmployeeViewModel> Read(EmployeeBindingModel model)
        {
            if (model == null) return _employeeStorage.GetFullList();
            if (model.Id.HasValue) return new List<EmployeeViewModel> { _employeeStorage.GetElement(model) };
            return _employeeStorage.GetFilteredList(model);
        }
        
        public void CreateOrUpdate(EmployeeBindingModel model)
        {
            if (model.Id.HasValue) _employeeStorage.Update(model);
            else _employeeStorage.Insert(model);
        }

        public void Delete(EmployeeBindingModel model)
        {
            var empl = _employeeStorage.GetElement(new EmployeeBindingModel { Id = model.Id });
            if (empl == null) throw new Exception("Работник не найден");

            _employeeStorage.Delete(model);
        }
    }
}
