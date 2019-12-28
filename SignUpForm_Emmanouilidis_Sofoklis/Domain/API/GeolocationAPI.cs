using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Device.Location;


namespace Domain.API
{
    class GeolocationAPI
    {
        private readonly static string _key = "AIzaSyDQI4hxPC1l6NSuuslUgZD3TLhKNMt7ESE";

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
        
        public double CalculateDistanceFromKnownCoordinates(double sourceLatitude, double sourceLongitude, double destinationLatitude, double destinationLongitude)
        {
            var sCoord = new GeoCoordinate(sourceLatitude, sourceLongitude);
            var dCoord = new GeoCoordinate(destinationLatitude, destinationLongitude);
            
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

                    var latitude = dsResult.Tables["location"].Rows[0]["lat"].ToString();
                    var longitude = dsResult.Tables["location"].Rows[0]["lng"].ToString();

                     
                    double.TryParse(latitude, out double lat);

                    double.TryParse(latitude, out double lng);

                    coordinates.Latitude = lat;
                    coordinates.Longitude = lng;
                }
            }

            return coordinates; 
        }
    }
}
