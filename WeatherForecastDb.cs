using Microsoft.EntityFrameworkCore;

namespace weather_forecast_backend
{
    public class WeatherForecastDb : DbContext
    {
        public WeatherForecastDb (DbContextOptions<WeatherForecastDb> options) : base (options)
        {

        }

        public DbSet<Location> Locations { get; set; }
    }
}
