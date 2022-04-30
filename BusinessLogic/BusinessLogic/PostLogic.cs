using System;
using Contracts.StorageContracts;
using Contracts.BusinessLogicContracts;
using Contracts.BindingModels;
using System.Collections.Generic;
using Contracts.ViewModels;

namespace BusinessLogic.BusinessLogic
{
    public class PostLogic : IPostLogic
    {
        private readonly IPostStorage _postStorage;

        public PostLogic(IPostStorage postStorage)
        {
            _postStorage = postStorage;
        }

        public List<PostViewModel> Read(PostBindingModel model)
        {
            if (model == null) return _postStorage.GetFullList();
            if (model.Id.HasValue) return new List<PostViewModel> { _postStorage.GetElement(model) };
            return _postStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(PostBindingModel model)
        {
            if (model.Id.HasValue) _postStorage.Update(model);
            else _postStorage.Insert(model);
        }

        public void Delete(PostBindingModel model)
        {
            var post = _postStorage.GetElement(new PostBindingModel { Id = model.Id });
            if (post == null) throw new Exception("Должность не найдена");

            _postStorage.Delete(model);
        }
    }
}
