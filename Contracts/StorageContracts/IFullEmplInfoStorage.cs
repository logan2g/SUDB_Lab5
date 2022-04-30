using Contracts.ViewModels;
using System.Collections.Generic;

namespace Contracts.StorageContracts
{
    public interface IFullEmplInfoStorage
    {
        List<FullEmplInfoViewModel> GetFullList();
    }
}
