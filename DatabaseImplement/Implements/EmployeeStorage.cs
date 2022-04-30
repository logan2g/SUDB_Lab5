using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.StorageContracts;
using Contracts.BindingModels;
using Contracts.ViewModels;
using DatabaseImplement.Models;

namespace DatabaseImplement.Implements
{
    public class EmployeeStorage : IEmployeeStorage
    {
        public List<EmployeeViewModel> GetFullList()
        {
            using var context = new Database();
            return context.Employees.Select(CreateModel).ToList();
        }
        
        public List<EmployeeViewModel> GetFilteredList(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new Database();
            return context.Employees.Where(rec => rec.Name.Equals(model.Name)).Select(CreateModel).ToList();
        }

        public EmployeeViewModel GetElement(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new Database();
            var empl = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);

            return empl != null ? CreateModel(empl) : null;
        }

        public void Insert(EmployeeBindingModel model)
        {
            using var context = new Database();

            context.Employees.Add(CreateModel(model, new Employee()));
            context.SaveChanges();
        }

        public void Update(EmployeeBindingModel model)
        {
            using var context = new Database();

            var empl = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);
            if (empl == null)
            {
                throw new Exception("Работник не найден");
            }
            CreateModel(model, empl);
            context.SaveChanges();
        }

        public void Delete(EmployeeBindingModel model)
        {
            using var context = new Database();

            var empl = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);
            if (empl == null)
            {
                throw new Exception("Работник не найден");
            }
            context.Employees.Remove(empl);
            context.SaveChanges();
        }

        private Employee CreateModel(EmployeeBindingModel model, Employee empl)
        {
            empl.Name = model.Name;
            empl.Surcharge = model.Surchashrge;

            return empl;
        }

        private EmployeeViewModel CreateModel(Employee employee)
        {
            return new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Surchashrge = (int)employee.Surcharge
            };
        }
    }
}
