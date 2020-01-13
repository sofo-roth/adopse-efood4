using Domain.Infrastructure;
using System;

namespace Domain.DatabaseModels
{
    internal class UserClicks : IDataTable
    {
        [PrimaryKey]
        public int ClickId { get; set; }

        public int ShopId { get; set; }
        public int UserId { get; set; }
        public DateTime ClickDate { get; set; }
    }
}
