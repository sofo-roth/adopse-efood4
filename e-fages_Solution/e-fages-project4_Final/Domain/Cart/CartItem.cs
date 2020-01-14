using System.Collections.Generic;


namespace Domain.ValueModels
{
    public class CartItem
    {

        public int ShopId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public int? FoodItemId { get; set; }

        public List<CartItemIngredient> Ingredients { get; set; }

    }
}
