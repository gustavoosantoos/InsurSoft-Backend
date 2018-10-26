using InsurSoft.Backend.Infra.Ioc.Context;
using InsurSoft.Backend.Infra.Ioc.Logger;
using InsurSoft.Backend.Infra.Ioc.Mediator;
using InsurSoft.Backend.Web.Segurados.Infra.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using System;

namespace InsurSoft.Backend.Infra.Ioc
{
    public static class Bootstrapper
    {
        private static readonly Container _container = new Container();

        public static void Init(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(_container));
            services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(_container));

            services.EnableSimpleInjectorCrossWiring(_container);
            services.UseSimpleInjectorAspNetRequestScoping(_container);
        }

        public static void InitContainer(this IApplicationBuilder app, Action<Container> aditionalRegistrations = null)
        {
            _container.Options.DefaultLifestyle = Lifestyle.Scoped;
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            _container.RegisterMvcControllers(app);

            _container.RegisterContextIoc();
            _container.RegisterLoggerIoc();
            _container.RegisterMediatorIoc();
            _container.RegisterSeguradosIoc();

            aditionalRegistrations?.Invoke(_container);

            _container.AutoCrossWireAspNetComponents(app);
        }

        public static void Verify(this IApplicationBuilder app)
        {
            _container.Verify();
        }
    }
}
