using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using OpenWeather;
using OpenWeatherMap.Standard.Models;
using TestHelpers;

namespace OpenWeatherTestProjectNunit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        //[Test]
        //public async Task TestSingleResult()
        //{
        //    var access = new OpenWeatherSupplier(new OpenWeatherAdapter(new ConfigurationBuilder().AddUserSecrets("2c63de453e6f9183e17349b362a589fb").Build()));
        //    var result = await access.GetWeatherForecast(Parameters.Mostar);

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(5, result.Count());

        //}

        [Test]
        public async Task TestOpenWeatherSupplierInIsolation()
        {
            var mockApi = new Mock<IOpenWeatherAdapter>();

            mockApi.Setup(s => s.GetForecastDataByCoordinatesAsync(Parameters.TarguMures.Latitude, Parameters.TarguMures.Longitude)).Returns(Task.FromResult(new ForecastData()));

            var supplier = new OpenWeatherSupplier(mockApi.Object);

            await supplier.GetWeatherForecast(Parameters.TarguMures);

            mockApi.Verify(s => s.GetForecastDataByCoordinatesAsync(Parameters.TarguMures.Latitude, Parameters.TarguMures.Longitude), Times.Once);
        }
    }
}