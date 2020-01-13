
using Domain.Infrastructure;

namespace Domain.DatabaseModels
{
    internal class FoodCategoryIngredients : IDataTable
    {
        
        public int IngredientId { get; set; }
        
        public int CategoryId { get; set; }

    }
}
