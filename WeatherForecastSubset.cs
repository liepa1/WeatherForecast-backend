namespace weather_forecast_backend
{
    public class WeatherForecastSubset
    {
        public WeatherForecastSubset(string locationName, string currentTime, int currentTemperature, int feelsLike, string description, int highestTemperatureOfTheDay, int lowestTemperatureOfTheDay, string summary, string iconName, List<HourlyForecast> hourlyForecast)
        {
            LocationName = locationName;
            CurrentTime = currentTime;
            CurrentTemperature = currentTemperature;
            FeelsLike = feelsLike;
            Description = description;
            HighestTemperatureOfTheDay = highestTemperatureOfTheDay;
            LowestTemperatureOfTheDay = lowestTemperatureOfTheDay;
            Summary = summary;
            IconName = iconName;
            HourlyForecast = hourlyForecast;
        }

        public string LocationName { get; set; }

        public string CurrentTime { get; set; }

        public int CurrentTemperature { get; set; }

        public int FeelsLike { get; set; }

        public string Description { get; set; }

        public int HighestTemperatureOfTheDay { get; set; }

        public int LowestTemperatureOfTheDay { get; set; }

        public string Summary { get; set; }

        public string IconName { get; set; }

        public List<HourlyForecast> HourlyForecast {get; set;}

    }
}
