using System.Collections.Generic;


namespace Domain.ValueModels
{
    public class CartItem
    {

        public int ShopId { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public List<Ingredient> Ingredients { get; set; }

    }
}
