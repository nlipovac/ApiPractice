using Microsoft.Extensions.Configuration;
using OpenWeatherMap.Standard;
using OpenWeatherMap.Standard.Enums;
using OpenWeatherMap.Standard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather
{
    public class OpenWeatherAdapter : IOpenWeatherAdapter
    {
        private readonly string _apiToken;

        private readonly Current _supplier;

        //public OpenWeatherAdapter(IConfiguration configuration)
        //{
        //    //See https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows on how to set up local user secrets

        //     _apiToken = configuration.GetSection("OpenWeatherAPIToken").Value ?? string.Empty;
        //    _apiToken = "2c63de453e6f9183e17349b362a589fb";//harcoded bcz user secreet not stored on machine

        //    if (string.IsNullOrWhiteSpace(_apiToken)) throw new NullReferenceException("Please set the OpenWeatherAPIToken user secret");

        //    _supplier = new Current(_apiToken, WeatherUnits.Metric);

        //}
        public OpenWeatherAdapter(Current supplier)
        {
            _supplier = supplier;
        }
        public async Task<ForecastData> GetForecastDataByCoordinatesAsync(double latitude, double longitude)
        {
            return await _supplier.GetForecastDataByCoordinatesAsync(latitude, longitude);
        }
    }
}
