using Dummy;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using OpenWeather;
using Types;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForecastService _service;


        public WeatherForecastController(IWeatherForecastService service)
        {
            _service=service;
        }

        [HttpPost]
        [Route("/GetWeatherForecast")]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Post(WeatherForecastCriteria criteria, string supplierName = "Dummy")
        {
            var result = await _service.GetWeatherForecast(criteria,supplierName);
            return Ok(result);
  //              "longitude": 43.3438,
  //              "latitude": 17.8078,
  //              "days": 5
        }
    }
}