using Types;

namespace Dummy
{
    public class DummyWeatherSupplier
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecast(int days)
        {
            return await Task.FromResult(Enumerable.Range(0, days).Select(i=> new WeatherForecast
            {
                Date = DateTime.Now.AddDays(days),
                TemperatureC = Random.Shared.Next(-20,55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }));
        }
    }
}