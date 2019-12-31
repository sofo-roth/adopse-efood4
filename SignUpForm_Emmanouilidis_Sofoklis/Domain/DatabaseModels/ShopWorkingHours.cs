using System;


namespace Domain.DatabaseModels
{
    internal class ShopWorkingHours
    {
        
        public int ShopId { get; set; }
        public int Duration { get; set; }
        public DateTime WorkStart { get; set; }
    }
}
