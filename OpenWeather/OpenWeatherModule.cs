using Autofac;
using ConfigurationService;
using Interfaces;
using OpenWeatherMap.Standard;
using OpenWeatherMap.Standard.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather
{
    public class OpenWeatherModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterModule<ConfigurationServiceModule>();

            builder.Register(c =>
            {
                var configuration = c.Resolve<IConfigurationService>();
                var _apiToken = configuration.GetString("OpenWeatherAPIToken");
                if (string.IsNullOrWhiteSpace(_apiToken))
                    _apiToken = "2c63de453e6f9183e17349b362a589fb";
                if (string.IsNullOrWhiteSpace(_apiToken)) throw new NullReferenceException("Please set the OpenWeatherAPIToken user secret");
                return new Current(_apiToken, WeatherUnits.Metric);
            })
            .As<Current>()
            .SingleInstance();

            builder.RegisterType<OpenWeatherAdapter>()
                .As<IOpenWeatherAdapter>();

            builder.RegisterType<OpenWeatherSupplier>()
                   .Named<IWeatherSupplier>(OpenWeatherSupplier.Name);
        }
    }
}
