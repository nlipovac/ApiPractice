using Dummy;
using Types;

namespace WeatherForecastService
{
    public class WeatherForecastService
    {
        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts(int days)
        {
            var supplier = new DummyWeatherSupplier();
            return await supplier.GetWeatherForecast(days);

        }
    }
}