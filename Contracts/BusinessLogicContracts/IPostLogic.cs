using Contracts.BindingModels;
using System.Collections.Generic;
using Contracts.ViewModels;

namespace Contracts.BusinessLogicContracts
{
    public interface IPostLogic
    {
        List<PostViewModel> Read(PostBindingModel model);

        void CreateOrUpdate(PostBindingModel model);

        void Delete(PostBindingModel model);
    }
}
