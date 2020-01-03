
using Domain.ValueModels;
using System.Collections.Generic;

namespace Domain.Infrastructure
{
    public interface IShopResultsService : IServiceBase
    {
        IEnumerable<ShopGridViewModel> Read(string address, ref Dictionary<int, string> foodCategories);

        void RecordClick(int shopId);

        
    }
}
