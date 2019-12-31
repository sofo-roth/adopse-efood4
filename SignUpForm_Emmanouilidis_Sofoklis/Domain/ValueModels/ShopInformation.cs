using System;


namespace Domain.ValueModels
{
    public class ShopInformation
    {
        public int ShopId { get; set; }

        public int OwnerId { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double Elaxisti { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastSubscription { get; set; }
        public double? Rating { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public ShopInformation()
        {
            Latitude = null;
            Longitude = null;
            LastSubscription = null;
            Rating = null;
        }
    }
}
