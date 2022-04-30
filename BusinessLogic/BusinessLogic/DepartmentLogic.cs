using System;
using Contracts.StorageContracts;
using Contracts.BusinessLogicContracts;
using Contracts.BindingModels;
using System.Collections.Generic;
using Contracts.ViewModels;

namespace BusinessLogic.BusinessLogic
{
    public class DepartmentLogic : IDepartmentLogic
    {
        private readonly IDepartmentStorage _departmentStorage;

        public DepartmentLogic(IDepartmentStorage departmentStorage)
        {
            _departmentStorage = departmentStorage;
        }
        
        public List<DepartmentViewModel> Read(DepartmentBindingModel model)
        {
            if (model == null) return _departmentStorage.GetFullList();
            if (model.Id.HasValue) return new List<DepartmentViewModel> { _departmentStorage.GetElement(model) };
            return _departmentStorage.GetFilteredList(model);
        }
        
        public void CreateOrUpdate(DepartmentBindingModel model)
        {
            if (model.Id.HasValue) _departmentStorage.Update(model);
            else _departmentStorage.Insert(model);
        }

        public void Delete(DepartmentBindingModel model)
        {
            var dep = _departmentStorage.GetElement(new DepartmentBindingModel { Id = model.Id });
            if (dep == null) throw new Exception("Отдел не найден");

            _departmentStorage.Delete(model);
        }
    }
}
