using System.Collections.Generic;
using System.Data.Entity;
using Autofac;
using Autofac.Core;
using AutoMapper;
using AutoMapper.Mappers;
using DataAccess.DbContexts;
using DataAccess.Identity;
using DataAccess.Implementation.DbContexts;
using DataAccess.Implementation.Identity;

namespace DataAccess.Infrastructure
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<AppContext>().As<IAppContext>().InstancePerRequest();
            builder.RegisterType<AppContextAdapter>().As<IAppContextAdapter>().InstancePerRequest();
            builder.RegisterType<UserManagerAdapter>().As<IUserManagerAdapter>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().As<IApplicationUserManager>().InstancePerRequest()
                .WithParameter(
                    new ResolvedParameter(
                        (param, ctx) => param.ParameterType == typeof (DbContext),
                        (param, ctx) => ctx.Resolve<IAppContext>()));

            builder.RegisterType<MappingEngine>().As<IMappingEngine>();
            builder.RegisterAssemblyTypes(GetType().Assembly).Where(x => x.Name.EndsWith("Profile")).As<Profile>().SingleInstance();
            builder.Register(ctx => new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers))
                .AsImplementedInterfaces().SingleInstance().OnActivating(config =>
                {
                    foreach (var profile in config.Context.Resolve<IEnumerable<Profile>>())
                    {
                        config.Instance.AddProfile(profile);
                    }
                });
        }
    }
}