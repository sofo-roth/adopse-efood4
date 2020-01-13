
using System.Collections.Generic;

namespace Domain.ValueModels
{
    public class FoodItemViewModel
    {
        public string ItemName { get; set; }

        public double Price { get; set; }

        public int ItemId { get; set; }

        public List<FoodItemIngredientViewModel> FoodIngredients { get; set; }

        public int CategoryId { get; set; }
    }
}
