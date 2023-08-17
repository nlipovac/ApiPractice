using Interfaces;
using Microsoft.Extensions.Configuration;
using OpenWeatherMap.Standard;
using OpenWeatherMap.Standard.Enums;
using Types;

namespace OpenWeather
{
    public class OpenWeatherSupplier:IWeatherSupplier
    {
        public static string Name => "OpenWeather";

        private readonly string _apiToken;
        private readonly Current _openWeather;

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecast(WeatherForecastCriteria criteria)
        {
            //See https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows on how to set up local user secrets
            var config = new ConfigurationBuilder().AddUserSecrets("2c63de453e6f9183e17349b362a589fb").Build();

            string token = config.GetSection("OpenWeatherAPIToken").Value ?? string.Empty;
            token="2c63de453e6f9183e17349b362a589fb";
            if (string.IsNullOrWhiteSpace(token)) throw new NullReferenceException("Please set the OpenWeatherAPIToken user secret");

            var supplier = new Current(token, WeatherUnits.Metric);
            var results = await supplier.GetForecastDataByCoordinatesAsync(criteria.Latitude, criteria.Longitude);

            return results
                .WeatherData
                .Where(w => w.AcquisitionDateTime > DateTime.Today.AddHours(23).AddMinutes(59) && w.AcquisitionDateTime < DateTime.Today.AddDays(criteria.Days))
                .ToList()
                .ConvertAll(w => new WeatherForecast
                {
                    Date = w.AcquisitionDateTime,
                    TemperatureC = (int)w.WeatherDayInfo.Temperature,
                    Summary = w.Weathers?.FirstOrDefault()?.Description ?? string.Empty
                });
        }
    }
}