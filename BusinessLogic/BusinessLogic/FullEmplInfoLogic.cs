using Contracts.BusinessLogicContracts;
using Contracts.StorageContracts;
using Contracts.ViewModels;
using System.Collections.Generic;

namespace BusinessLogic.BusinessLogic
{
    public class FullEmplInfoLogic : IFullEmplInfoLogic
    {
        private readonly IFullEmplInfoStorage _fullStorage;

        public FullEmplInfoLogic(IFullEmplInfoStorage storage)
        {
            _fullStorage = storage;
        }

        public List<FullEmplInfoViewModel> Read()
        {
            return _fullStorage.GetFullList();
        }
    }
}
