
using Domain.Infrastructure;

namespace Domain.DatabaseModels
{
    internal class ShopPriceIngredient : IDataTable
    {

        public int IngId { get; set; }
        public int ShopId { get; set; }
       
        public double Price { get; set; }
    }
}
