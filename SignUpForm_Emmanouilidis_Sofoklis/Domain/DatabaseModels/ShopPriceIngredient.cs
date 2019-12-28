using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DatabaseModels
{
    internal class ShopPriceIngredient
    {

        public int IngId { get; set; }
        public int ShopId { get; set; }
       
        public double Price { get; set; }
    }
}
