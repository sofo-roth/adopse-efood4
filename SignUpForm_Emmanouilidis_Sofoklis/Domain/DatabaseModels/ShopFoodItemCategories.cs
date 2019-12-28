using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DatabaseModels
{
    internal class ShopFoodItemCategories
    {
        public int ShopId { get; set; }
        public int CategoryId { get; set; }

        public string CategoryAlias { get; set; }
    }
}
