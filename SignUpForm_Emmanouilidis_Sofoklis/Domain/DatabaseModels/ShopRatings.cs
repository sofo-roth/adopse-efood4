using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DatabaseModels
{
    internal class ShopRatings
    {
        public int ShopId { get; set; }
        public int UserId { get; set; }
        public double Rating { get; set; }

    }
}
