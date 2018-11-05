using InsurSoft.Backend.Infrastructure.Ioc.App.Segurados;
using InsurSoft.Backend.Infrastructure.Ioc.App.Seguros;
using InsurSoft.Backend.Infrastructure.Ioc.Context;
using InsurSoft.Backend.Infrastructure.Ioc.Logger;
using InsurSoft.Backend.Infrastructure.Ioc.Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using System;

namespace InsurSoft.Backend.Infrastructure.Ioc
{
    public static class Bootstrapper
    {
        public static readonly Container Container = new Container();

        public static void Init(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(Container));
            services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(Container));

            services.EnableSimpleInjectorCrossWiring(Container);
            services.UseSimpleInjectorAspNetRequestScoping(Container);
        }

        public static void InitContainer(this IApplicationBuilder app, Action<Container> aditionalRegistrations = null)
        {
            Container.Options.DefaultLifestyle = Lifestyle.Scoped;
            Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            Container.RegisterMvcControllers(app);

            Container.RegisterContextIoc();
            Container.RegisterLoggerIoc();
            Container.RegisterMediatorIoc();
            Container.RegisterSeguradosIoc();
            Container.RegisterSegurosIoc();
            
            aditionalRegistrations?.Invoke(Container);

            Container.AutoCrossWireAspNetComponents(app);
        }

        public static void Verify(this IApplicationBuilder app)
        {
            Container.Verify();
        }
    }
}
