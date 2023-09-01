using Dummy;
using Interfaces;
using OpenWeather;
using Types;

namespace WeatherForecastService
{
    public class WeatherForecastService:IWeatherForecastService
    {
        private readonly IWeatherSupplier _dummy;
        private readonly IWeatherSupplier _openWeather;
        private readonly ILogger _logger;


        public WeatherForecastService(IWeatherSupplier dummy,IWeatherSupplier openWeather,ILogger logger)
        {
              _dummy = dummy;
              _openWeather = openWeather; 
             _logger = logger;
        }
        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecast(WeatherForecastCriteria criteria, string supplierName)
        {
            if(supplierName == DummyWeatherSupplier.Name)
            {
                _logger.Information("Requesting weather forecast from {supplier} supplier with {@criteria}", supplierName, criteria);
                return await _dummy.GetWeatherForecast(criteria);

            }
            else if(supplierName == OpenWeatherSupplier.Name)
            {
                _logger.Information("Requesting weather forecast from {supplier} supplier with {@criteria}", supplierName, criteria);
                return await _openWeather.GetWeatherForecast(criteria);
            }
            _logger.Error($"Unknown supplier: {supplierName}");

            throw new ArgumentException($"Unknown supplier :{supplierName}");
        }
    }
}