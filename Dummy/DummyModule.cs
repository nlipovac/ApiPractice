using Autofac;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace Dummy
{
    public class DummyModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            //NOTE: registering the supplier with metadata attached
            builder.RegisterType<DummyWeatherSupplier>()
                   .As<IWeatherSupplier>()
                   .WithMetadata<SupplierMetadata>(meta => meta.For(sm => sm.Name, DummyWeatherSupplier.Name))
                   .InstancePerLifetimeScope();
        }
    }
}
