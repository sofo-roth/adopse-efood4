
using Domain.Infrastructure;

namespace Domain.DatabaseModels
{
    internal class ShopRatings : IDataTable
    {
        public int ShopId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }

    }
}
