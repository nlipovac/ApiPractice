using Autofac;
using Dummy;
using Interfaces;
using OpenWeather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastService
{
    public class WeatherForecastServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterModule<OpenWeatherModule>();
            builder.RegisterModule<DummyModule>();

            builder.RegisterType<WeatherForecastService>()
                .As<IWeatherForecastService>();
        }
    }
}
