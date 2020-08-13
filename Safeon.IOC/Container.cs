using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Safeon.Domain.Business;
using Safeon.Domain.Business.Contracts;
using Safeon.Domain.Contexts.Contracts;
using Safeon.Domain.Repositories.Contracts;
using Safeon.IOC.Contracts;
using Safeon.Mysql.Context;
using Safeon.Mysql.Repositories;
using Safeon.Systems.Contracts;
using Safeon.Systems.Core.Settings;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;

namespace Safeon.IOC
{
    public class Container : IContainer
    {
        private static SimpleInjector.Container _container;
        private static bool _verified = false;

        public static void Init()
        {
            _container = new SimpleInjector.Container();
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            //registros que precisam ser os primeiros
            _container.Register<IContainer, Container>(Lifestyle.Singleton);
            //_container.Register<ISettingsService, DotNetCoreSettingsService>(Lifestyle.Singleton);

            RegisterBusiness();
            RegisterRepository();
            RegisterData();

        }

        public static void InitServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(_container));
            services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(_container));

            services.EnableSimpleInjectorCrossWiring(_container);
            services.UseSimpleInjectorAspNetRequestScoping(_container);
        }

        public static void InitApplication(IApplicationBuilder app, IHostingEnvironment env)
        {
            _container.Register<ISettingsService>(() => {
                return new DotNetCoreSettingsService(env);
            });

            // Add application presentation components:
            _container.RegisterMvcControllers(app);
            _container.RegisterMvcViewComponents(app);

            // Allow Simple Injector to resolve services from ASP.NET Core.
            _container.AutoCrossWireAspNetComponents(app);

            if (_verified) return;
            _container.Verify();
            _verified = true;
        }

        public static void Verify()
        {
            if (_verified) return;
            _container.Verify();
            _verified = true;
        }

        private static void RegisterBusiness()
        {
            _container.Register<IExternalSupportBusiness, ExternalSupportBusiness>(Lifestyle.Transient);
            _container.Register<IPointInterestBusiness, PointInterestBusiness>(Lifestyle.Transient);
            _container.Register<IUserBusiness, UserBusiness>(Lifestyle.Transient);
            _container.Register<ICustomerBusiness, CustomerBusiness>(Lifestyle.Transient);
        }

        private static void RegisterRepository()
        {
            _container.Register<IExternalSupportRepository, ExternalSupportRepository>(Lifestyle.Transient);
            _container.Register<IPointInterestRepository, PointInterestRepository>(Lifestyle.Transient);
            _container.Register <IUserRepository, UserRepository>(Lifestyle.Transient);
            _container.Register<ICustomerRepository, CustomerRepository>(Lifestyle.Transient);
        }

        private static void RegisterData()
        {
            _container.Register<ISafeonMysqlContext>(() =>
            {
                return new SafeonMysqlContext(new DbContextOptionsBuilder<SafeonMysqlContext>()
                    .UseMySql(SettingsWrapper.GetSetting(f =>
                        f.ConnectionStrings.MysqlContext)).Options);
            });
        }

        public T GetInstance<T>() where T : class
        {
            if (_container == null)
                Init();

            return _container.GetInstance<T>();
        }

        public static SimpleInjector.Container GetContainer()
        {
            return _container;
        }
    }
}