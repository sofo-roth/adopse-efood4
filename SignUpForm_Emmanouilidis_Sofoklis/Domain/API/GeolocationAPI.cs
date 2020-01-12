using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Device.Location;

using Domain.ValueModels;
using System.Configuration;

namespace Domain.API
{
    internal class GeolocationAPI
    {
        private readonly static string _key = ConfigurationManager.AppSettings["APIKey"];

        public double CalculateDistance(string userAddress, GeoCoordinate userAddressCoords, ShopGridViewModel shop)
        {
            if (!shop.Latitude.HasValue || !shop.Longitude.HasValue)
                return CalculateDistance(userAddress, shop.Address);

            
            return CalculateDistanceFromKnownCoordinates(userAddressCoords, shop.Latitude.Value, shop.Longitude.Value);
        }


        public double CalculateDistance(string userAddress, string shopAdress)
        {
            double distance;
            string url = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + userAddress + "&destinations=" + shopAdress + "&key=" + _key;
            WebRequest request = WebRequest.Create(url);
            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    DataSet dsResult = new DataSet();
                    dsResult.ReadXml(reader);
                    
                    var distanceString = dsResult.Tables["distance"].Rows[0]["value"].ToString();
                    double.TryParse(distanceString, out distance);
                }
            }
            return distance;
        }
        
        public double CalculateDistanceFromKnownCoordinates(GeoCoordinate sCoord, double destinationLatitude, double destinationLongitude)
        {
            
            var dCoord = new GeoCoordinate(destinationLatitude, destinationLongitude);
            
            return sCoord.GetDistanceTo(dCoord);
        }

        public double CalculateDistanceFromKnownCoordinates(GeoCoordinate sCoord, GeoCoordinate dCoord)
        {
            return sCoord.GetDistanceTo(dCoord);
        }

        public GeoCoordinate CalculateLatLong(string address)
        {
            var coordinates = new GeoCoordinate();
            string url = "https://maps.googleapis.com/maps/api/geocode/xml?address=" + address + "&key=" + _key;
            WebRequest request = WebRequest.Create(url);
            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    DataSet dsResult = new DataSet();
                    dsResult.ReadXml(reader);

                    var latitude = dsResult.Tables["location"]?.Rows[0]["lat"].ToString();
                    var longitude = dsResult.Tables["location"]?.Rows[0]["lng"].ToString();

                     
                    double.TryParse(latitude, out double lat);

                    double.TryParse(longitude, out double lng);

                    coordinates.Latitude = lat;
                    coordinates.Longitude = lng;
                }
            }

            return coordinates; 
        }
    }
}
