using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.StorageContracts;
using Contracts.BindingModels;
using Contracts.ViewModels;
using XUbuntuDatabaseImplement.Models;

namespace XUbuntuDatabaseImplement.Implements
{
    public class PostStorage : IPostStorage
    {
        public List<PostViewModel> GetFullList()
        {
            using var context = new Database();
            return context.Posts.Select(CreateModel).ToList();
        }

        public List<PostViewModel> GetFilteredList(PostBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new Database();
            return context.Posts.Where(rec => rec.Name.Equals(model.PostName)).Select(CreateModel).ToList();
        }

        public PostViewModel GetElement(PostBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new Database(); 
            var post = context.Posts.FirstOrDefault(rec => rec.Id == model.Id);

            return post != null ? CreateModel(post) : null;
        }

        public void Insert(PostBindingModel model)
        {
            using var context = new Database();

            context.Posts.Add(CreateModel(model, new Post()));
            context.SaveChanges();
        }

        public void Update(PostBindingModel model)
        {
            using var context = new Database();
            var post = context.Posts.FirstOrDefault(rec => rec.Id == model.Id);

            if (post == null)
            {
                throw new Exception("Должность не найдена");
            }

            CreateModel(model, post);
            context.SaveChanges();
        }

        public void Delete(PostBindingModel model)
        {
            using var context = new Database();
            var post = context.Posts.FirstOrDefault(rec => rec.Id == model.Id);

            if (post == null)
            {
                throw new Exception("Должность не найдена");
            }

            context.Posts.Remove(post);
            context.SaveChanges();
        }

        private PostViewModel CreateModel(Post post)
        {
            return new PostViewModel
            {
                Id = post.Id,
                PostName = post.Name,
                Salary = post.Salary
            };
        }

        private Post CreateModel(PostBindingModel model, Post post)
        {
            post.Name = model.PostName;
            post.Salary = model.Salary;

            return post;
        }
    }
}
