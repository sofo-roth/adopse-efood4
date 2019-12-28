using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DatabaseModels
{
    internal class Shop
    {
        [PrimaryKey]
        public int ShopId { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double Elaxisti { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastSubscription { get; set; }
        public double Rating { get; set; }
    }
}
