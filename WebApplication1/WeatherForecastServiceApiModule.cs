using Autofac;
using Dummy;
using Interfaces;
using OpenWeather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Controllers;

namespace WeatherForecastService
{
    public class WeatherForecastServiceApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterModule<WeatherForecastServiceModule>();

            builder.Register(c => Log.Logger)
                .As<Serilog.ILogger>()
                .SingleInstance();

            builder.RegisterType<WeatherForecastController>();
        }
    }
}
