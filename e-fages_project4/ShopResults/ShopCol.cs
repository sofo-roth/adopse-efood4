using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopResults
{
    class ShopCol
    {
        public int Id { get; set; }
        public string ShopName { get; set; }

        public string Address { get; set; }

        public double distance { get; set; }

        public List<string> ingrad { get; set; }
    }
}
