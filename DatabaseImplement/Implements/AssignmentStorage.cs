using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.StorageContracts;
using Contracts.BindingModels;
using Contracts.ViewModels;
using DatabaseImplement.Models;

namespace DatabaseImplement.Implements
{
    public class AssignmentStorage : IAssignmentStorage
    {
        public List<AssignmentViewModel> GetFullList()
        {
            using var context = new Database();
            return context.AssingnmentToPosts.Select(CreateModel).ToList();
        }

        public List<AssignmentViewModel> GetFilteredList(AssignmentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new Database();
            return context.AssingnmentToPosts.Where(rec => rec.Employeeid == model.EmployeeId || rec.Departmentid == model.DepartmentId || rec.Postid == model.PostId).Select(CreateModel).ToList();
        }

        public AssignmentViewModel GetElement(AssignmentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new Database();
            var assign = context.AssingnmentToPosts.FirstOrDefault(rec => rec.Id == model.Id);

            return assign != null ? CreateModel(assign) : null;
        }

        public void Insert(AssignmentBindingModel model)
        {
            using var context = new Database();

            AssignmentToPost assignToAdd = new AssignmentToPost 
            { 
                Departmentid = model.DepartmentId,
                Postid = model.PostId,
                Employeeid = model.EmployeeId
            };
            context.AssingnmentToPosts.Add(assignToAdd);
            context.SaveChanges();
            CreateModel(model, assignToAdd, context);
            context.SaveChanges();
        }

        public void Update(AssignmentBindingModel model)
        {
            using var context = new Database();
            var assign = context.AssingnmentToPosts.FirstOrDefault(rec => rec.Id == model.Id);

            if (assign == null)
            {
                throw new Exception("Назначение не найдено");
            }

            CreateModel(model, assign, context);
            context.SaveChanges();
        }

        public void Delete(AssignmentBindingModel model)
        {
            using var context = new Database();
            var assign = context.AssingnmentToPosts.FirstOrDefault(rec => rec.Id == model.Id);

            if (assign == null)
            {
                throw new Exception("Назначение не найдено");
            }

            context.AssingnmentToPosts.Remove(assign);
            context.SaveChanges();
        }

        private AssignmentToPost CreateModel(AssignmentBindingModel model, AssignmentToPost assignment, Database context)
        {
            assignment.HiringDate = model.HiringDate;
            assignment.DismissDate = model.DismissDate;

            Post post = context.Posts.FirstOrDefault(rec => rec.Id == model.PostId);
            if(post != null)
            {
                if(post.AssingnmentToPosts == null)
                {
                    post.AssingnmentToPosts = new List<AssignmentToPost>();
                }
                post.AssingnmentToPosts.Add(assignment);
                context.Posts.Update(post);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Должность не найдена");
            }

            Employee empl = context.Employees.FirstOrDefault(rec => rec.Id == model.EmployeeId);
            if (empl != null)
            {
                if (empl.AssingnmentToPosts == null)
                {
                    empl.AssingnmentToPosts = new List<AssignmentToPost>();
                }
                empl.AssingnmentToPosts.Add(assignment);
                context.Employees.Update(empl);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Работник не найден");
            }

            Department dep = context.Departments.FirstOrDefault(rec => rec.Id == model.DepartmentId);
            if (dep != null)
            {
                if (dep.AssingnmentToPosts == null)
                {
                    dep.AssingnmentToPosts = new List<AssignmentToPost>();
                }
                dep.AssingnmentToPosts.Add(assignment);
                context.Departments.Update(dep);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Отдел не найден");
            }

            return assignment;
        }

        private AssignmentViewModel CreateModel(AssignmentToPost assignment)
        {
            return new AssignmentViewModel
            {
                Id = assignment.Id,
                PostId = assignment.Postid,
                DepartmentId = assignment.Departmentid,
                EmployeeId = assignment.Employeeid,
                HiringDate = assignment.HiringDate,
                DismissDate = assignment.DismissDate
            };
        }
    }
}
