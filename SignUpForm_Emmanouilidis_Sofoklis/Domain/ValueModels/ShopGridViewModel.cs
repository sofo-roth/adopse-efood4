using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueModels
{
    public class ShopGridViewModel
    {
        public int Id { get; set; }

        public string ShopName { get; set; }

        public string Address { get; set; }

        public double Distance { get; set; }

        public List<int> Categories { get; set; }
    }
}
