using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DatabaseModels
{
    internal class UserClicks
    {
        [PrimaryKey]
        public int ClickId { get; set; }

        public int ShopId { get; set; }
        public int UserId { get; set; }
        public DateTime ClickDate { get; set; }
    }
}
