using System.Text.Json.Serialization;

namespace weather_forecast_backend

{
    public class LocationResponse
    {
        
        public string name { get; set; }// location name

        
        public double lat { get; set; }// latitude

        public double lon { get; set; }// longtitude

    }
}
