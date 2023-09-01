using Autofac;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dummy
{
    public class DummyModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<DummyWeatherSupplier>()
                .Named<IWeatherSupplier>(DummyWeatherSupplier.Name);
        }
    }
}
