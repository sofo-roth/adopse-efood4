using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DatabaseModels
{
    internal class Orders
    {
        [PrimaryKey]
        public int OrderId { get; set; }

        public int UserId { get; set; }
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string UserAddress { get; set; }
        public string Comments { get; set; }
        public DateTime OrderTime { get; set; }
        public bool Delivered { get; set; }
        public bool Canceled { get; set; }
    }
}
