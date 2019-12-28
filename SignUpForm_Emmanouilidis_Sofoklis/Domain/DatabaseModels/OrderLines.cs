using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DatabaseModels
{
    internal class OrderLines
    {
        [PrimaryKey]
        public int LineId { get; set; }

        public int OrderId { get; set; }
        public int? IngredientId { get; set; }
        public int? FoodItemId { get; set; }
        public int? ParentId { get; set; }
    }
}
