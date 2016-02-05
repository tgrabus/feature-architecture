using Autofac;
using Business.CommandHandlers;
using Business.Dispatchers;
using Business.Implementation.Dispatchers;
using Module = Autofac.Module;

namespace Business.Infrastructure
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var thisAssembly = GetType().Assembly;

            builder.RegisterAssemblyTypes(thisAssembly).AsClosedTypesOf(typeof (ICommandHandler<>));
            builder.RegisterAssemblyTypes(thisAssembly).AsClosedTypesOf(typeof (ICommandHandlerAsync<>));

            builder.RegisterType<CommandDispatcher>().AsImplementedInterfaces();
        }
    }
}