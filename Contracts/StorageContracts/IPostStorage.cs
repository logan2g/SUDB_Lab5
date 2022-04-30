using Contracts.BindingModels;
using System.Collections.Generic;
using Contracts.ViewModels;

namespace Contracts.StorageContracts
{
    public interface IPostStorage
    {
        List<PostViewModel> GetFullList();

        List<PostViewModel> GetFilteredList(PostBindingModel model);

        PostViewModel GetElement(PostBindingModel model);

        void Insert(PostBindingModel model);

        void Update(PostBindingModel model);

        void Delete(PostBindingModel model);
    }
}
