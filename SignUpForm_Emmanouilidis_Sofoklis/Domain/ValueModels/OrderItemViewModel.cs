
using System.Collections.Generic;

namespace Domain.ValueModels
{
    public class OrderItemViewModel
    {
        public int? IngId { get; set; }

        public int? ItemId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int? CategoryId { get; set; }

        public int? ParentId { get; set; }

        public List<OrderItemViewModel> FoodIngredients { get; set; }
    }
}
