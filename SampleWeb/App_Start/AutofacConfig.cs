using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using SampleWeb.Extensions;

namespace SampleWeb
{
    public static class AutofacConfig
    { 
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            var thisAssembly = typeof(AutofacConfig).Assembly;
            var assemblies = thisAssembly.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                builder.RegisterAssemblyModules(assembly);
            }

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}