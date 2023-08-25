namespace weather_forecast_backend
{
    public class WeatherForecast
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public string timezone { get; set; }
        public int timezone_offset { get; set; }
        public CurrentWeather current { get; set; }
        public List<MinuteForecast> minutely { get; set; }
        public List<HourlyForecast> hourly { get; set; }
        public List<DailyForecast> daily { get; set; }
    }

    public class CurrentWeather
    {
        public long dt { get; set; }
        public long sunrise { get; set; }
        public long sunset { get; set; }
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public double dew_point { get; set; }
        public int clouds { get; set; }
        public double uvi { get; set; }
        public int visibility { get; set; }
        public double wind_speed { get; set; }
        public double wind_gust { get; set; }
        public int wind_deg { get; set; }
        public List<WeatherDescription> weather { get; set; }
    }

    public class MinuteForecast
    {
        public long dt { get; set; }
        public double precipitation { get; set; }
    }

    public class HourlyForecast
    {
        public long dt { get; set; }
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public double dew_point { get; set; }
        public double uvi { get; set; }
        public int clouds { get; set; }
        public int visibility { get; set; }
        public double wind_speed { get; set; }
        public double wind_gust { get; set; }
        public int wind_deg { get; set; }
        public double pop { get; set; }
        public List<WeatherDescription> weather { get; set; }
    }

    public class DailyForecast
    {
        public long dt { get; set; }
        public long sunrise { get; set; }
        public long sunset { get; set; }
        public long moonrise { get; set; }
        public long moonset { get; set; }
        public double moon_phase { get; set; }
        public string summary { get; set; }
        public Temperature temp { get; set; }
        public Temperature feels_like { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public double dew_point { get; set; }
        public double wind_speed { get; set; }
        public double wind_gust { get; set; }
        public int wind_deg { get; set; }
        public int clouds { get; set; }
        public double uvi { get; set; }
        public double pop { get; set; }
        public List<WeatherDescription> weather { get; set; }
    }

    public class Temperature
    {
        public double morn { get; set; }
        public double day { get; set; }
        public double eve { get; set; }
        public double night { get; set; }
        public double min { get; set; }
        public double max { get; set; }
    }

    public class WeatherDescription
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

}