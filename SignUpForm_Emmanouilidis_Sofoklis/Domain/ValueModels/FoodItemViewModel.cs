
using System.Collections.Generic;

namespace Domain.ValueModels
{
    class FoodItemViewModel
    {
        public string ItemName { get; set; }

        public double Price { get; set; }

        public int ItemId { get; set; }

        public List<FoodItemIngredientViewModel> Ingredients { get; set; }
    }
}
