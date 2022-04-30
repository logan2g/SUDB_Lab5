using Contracts.ViewModels;
using System.Collections.Generic;

namespace Contracts.BusinessLogicContracts
{
    public interface IFullEmplInfoLogic
    {
        List<FullEmplInfoViewModel> Read();
    }
}
