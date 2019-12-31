using System.Collections.Generic;


namespace Domain.ValueModels
{
    public class ShopGridViewModel
    {
        public int Id { get; set; }

        public string ShopName { get; set; }

        public string Address { get; set; }

        public double Distance { get; set; }

        public List<int> Categories { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public ShopGridViewModel()
        {
            Latitude = null;
            Longitude = null;

        }
    }
}
