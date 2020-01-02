
using Domain.Infrastructure;

namespace Domain.DatabaseModels
{
    internal class ShopFoodItemCategories : IDataTable
    {
        public int ShopId { get; set; }
        public int CategoryId { get; set; }

        public string CategoryAlias { get; set; }
    }
}
