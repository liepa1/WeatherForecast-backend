using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace weather_forecast_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet]

        public async Task<ActionResult<WeatherForecastSubset>> Get(string locationName)
        {

            try {
                string apiKey = "75c89a6ae681e86d1c82ede7bb5184d8";
                string locationUrl = $"http://api.openweathermap.org/geo/1.0/direct?q={locationName}&limit=1&appid={apiKey}";

                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var locationResponse = await httpClient.GetAsync(locationUrl);

                    if(locationResponse.IsSuccessStatusCode)
                    {
                        var locationResponseAsString = await locationResponse.Content.ReadAsStringAsync();
                        var locationData = JsonSerializer.Deserialize<List<LocationResponse>>(locationResponseAsString);

                        if(locationData != null && locationData.Count > 0)
                        {
                            double latitutde = locationData[0].lat;
                            double longtitude = locationData[0].lon;

                            var weatherResponse = await httpClient.GetAsync($"https://api.openweathermap.org/data/3.0/onecall?lat={latitutde}&lon={longtitude}&units=metric&appid={apiKey}");

                            if (weatherResponse.IsSuccessStatusCode) 
                            {   
                                var WeatherResponseAsString = await weatherResponse.Content.ReadAsStringAsync();
                                var weatherForecastData = JsonSerializer.Deserialize<WeatherForecast>(WeatherResponseAsString);

                                if (weatherForecastData != null) {

                                    DateTime currentTime = DateTimeOffset.FromUnixTimeSeconds(weatherForecastData.current.dt + weatherForecastData.timezone_offset).DateTime;
                                    string formattedTime = currentTime.ToString("HH:mm");


                                    var subset = new WeatherForecastSubset
                                    ( 
                                       locationData[0].name,
                                       formattedTime,
                                       (int)Math.Round(weatherForecastData.current.temp),
                                       (int)Math.Round(weatherForecastData.current.feels_like),
                                       weatherForecastData.current.weather[0].description,
                                       (int)Math.Round(weatherForecastData.daily[0].temp.max),
                                       (int)Math.Round(weatherForecastData.daily[0].temp.min),
                                       weatherForecastData.daily[0].summary,
                                       weatherForecastData.current.weather[0].icon,
                                       weatherForecastData.hourly
                                     );

                                    return Ok(subset);
                                }   
                                else
                                {
                                    return NotFound("No weather data has been found. Try again or enter different area name.");
                                }


                            }
                            else
                            {
                                return NotFound("No weather data has been found. Try again or enter different area name.");
                            }
                        }   
                        else
                        {
                            return NotFound("No location has been found by the provided name. Try again...");
                        }
         
                        
                    }
                    else
                    {
                        return BadRequest("Something went wrong. Try again...");
                    }
                }
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            


        }
    }
}