using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DatabaseModels
{
    internal class ShopPriceFoodItem
    {
        public int ShopId { get; set; }
        public int FoodItemId { get; set; }
        public double Price { get; set; }
    }
}
