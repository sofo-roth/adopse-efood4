
using Domain.ValueModels;
using System.Collections.Generic;

namespace Domain.Infrastructure
{
    public interface IShopResultsService
    {
        IEnumerable<ShopGridViewModel> Read(string address, ref Dictionary<int, string> foodCategories);

        void RecordClick(int shopId);
    }
}
