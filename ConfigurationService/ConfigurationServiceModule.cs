using Autofac;
using Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationService
{
    public class ConfigurationServiceModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(c => new ConfigurationBuilder().AddUserSecrets("2c63de453e6f9183e17349b362a589fb").Build())
                .As<IConfigurationRoot>()
                .SingleInstance();

            builder.RegisterType<ConfigurationService>()
                .As<IConfigurationService>();
        }
    }
}
