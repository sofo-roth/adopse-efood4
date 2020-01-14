using Domain.Infrastructure;
using System;


namespace Domain.DatabaseModels
{
    internal class ShopWorkingHours : IDataTable
    {
        
        public int ShopId { get; set; }
        public int Duration { get; set; }
        public DateTime WorkStart { get; set; }
    }
}
