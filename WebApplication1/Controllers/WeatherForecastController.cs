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
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _service = new WeatherForecastService.WeatherForecastService(
                dummy: new DummyWeatherSupplier(),
                openWeather: new OpenWeatherSupplier()
                );
        }

        [HttpPost]
        [Route("/GetWeatherForecast")]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get(WeatherForecastCriteria criteria, string supplierName = "Dummy")
        {
            var result = await _service.GetWeatherForecast(criteria,supplierName);
            return Ok(result);
  //              "longitude": 43.3438,
  //              "latitude": 17.8078,
  //              "days": 5
        }
    }
}