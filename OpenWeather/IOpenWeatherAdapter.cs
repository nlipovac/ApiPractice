using OpenWeatherMap.Standard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather
{
    public interface IOpenWeatherAdapter
    {
        Task<ForecastData> GetForecastDataByCoordinatesAsync(double latitude, double longitude);
    }
}
