using Microsoft.AspNetCore.Mvc;
using Types;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get(int days=8)
        {
            var service = new WeatherForecastService.WeatherForecastService();
            var result = await service.GetWeatherForecasts(days);
            return Ok(result);  

        }
    }
}