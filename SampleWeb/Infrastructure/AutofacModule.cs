using Autofac;
using Autofac.Integration.Mvc;

namespace SampleWeb.Infrastructure
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var assembly = GetType().Assembly;

            builder.RegisterControllers(assembly);
        }
    }
}