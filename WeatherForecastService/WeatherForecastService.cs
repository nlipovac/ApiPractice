﻿using Dummy;
using Interfaces;
using OpenWeather;
using Types;

namespace WeatherForecastService
{
    public class WeatherForecastService:IWeatherForecastService
    {
        private readonly IWeatherSupplier _dummy;
        private readonly IWeatherSupplier _openWeather;

        public WeatherForecastService(IWeatherSupplier dummy,IWeatherSupplier openWeather)
        {
              _dummy = dummy;
              _openWeather = openWeather; 
        }
        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecast(WeatherForecastCriteria criteria, string supplierName)
        {
            if(supplierName == DummyWeatherSupplier.Name)
            {
                return await _dummy.GetWeatherForecast(criteria);

            }
            else if(supplierName == OpenWeatherSupplier.Name)
            {
                return await _openWeather.GetWeatherForecast(criteria);
            }
            throw new NotImplementedException();
        }
    }
}