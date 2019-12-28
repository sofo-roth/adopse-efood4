using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DatabaseModels
{
    internal class ShopWorkingHours
    {
        
        public int ShopId { get; set; }
        public int Duration { get; set; }
        public DateTime WorkStart { get; set; }
    }
}
