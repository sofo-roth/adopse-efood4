
using System;

namespace Domain.ValueModels
{
    public class OrderDetails
    {
        public int? UserId { get; set; }

        public int ShopId { get; set; }

        public string Name { get; set; }

        public string ShopName { get; set; }

        public DateTime OrderTime { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public string UserAddress { get; set; }

        public string Comments { get; set; }

        public double FinalPrice { get; set; }

        public OrderDetails()
        {
            OrderTime = DateTime.Now; 
        }
        
    }
}
