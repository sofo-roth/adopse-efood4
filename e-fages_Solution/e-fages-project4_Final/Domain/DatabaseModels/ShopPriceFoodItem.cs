﻿using Domain.Infrastructure;

namespace Domain.DatabaseModels
{
    
    internal class ShopPriceFoodItem : IDataTable
    {
       
        public int ShopId { get; set; }
        
        public int FoodItemId { get; set; }
       
        public double Price { get; set; }

    }
}
