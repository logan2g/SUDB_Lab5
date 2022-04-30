using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.StorageContracts;
using Contracts.BindingModels;
using Contracts.ViewModels;
using DatabaseImplement.Models;

namespace DatabaseImplement.Implements
{
    public class DepartmentStorage : IDepartmentStorage
    {
        public List<DepartmentViewModel> GetFullList()
        {
            using var context = new Database();
            return context.Departments.Select(CreateModel).ToList();
        }

        public List<DepartmentViewModel> GetFilteredList(DepartmentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new Database();
            return context.Departments.Where(rec => rec.Name.Equals(model.DepartmentName)).Select(CreateModel).ToList();
        }

        public DepartmentViewModel GetElement(DepartmentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new Database();
            var dep = context.Departments.FirstOrDefault(rec => rec.Id == model.Id);

            return dep != null ? CreateModel(dep) : null;
        }

        public void Insert(DepartmentBindingModel model)
        {
            using var context = new Database();

            context.Departments.Add(CreateModel(model, new Department()));
            context.SaveChanges();
        }

        public void Update(DepartmentBindingModel model)
        {
            using var context = new Database();
            var dep = context.Departments.FirstOrDefault(rec => rec.Id == model.Id);

            if (dep == null)
            {
                throw new Exception("Отдел не найден");
            }

            CreateModel(model, dep);
            context.SaveChanges();
        }

        public void Delete(DepartmentBindingModel model)
        {
            using var context = new Database();
            var dep = context.Departments.FirstOrDefault(rec => rec.Id == model.Id);

            if (dep == null)
            {
                throw new Exception("Отдел не найден");
            }

            context.Departments.Remove(dep);
            context.SaveChanges();
        }

        private DepartmentViewModel CreateModel(Department dep)
        {
            return new DepartmentViewModel
            {
                Id = dep.Id,
                DepartmentName = dep.Name
            };
        }

        private Department CreateModel(DepartmentBindingModel model, Department dep)
        {
            dep.Name = model.DepartmentName;

            return dep;
        }
    }
}
