using FluentValidation;
using InsurSoft.Backend.Infra.Ioc.Context;
using InsurSoft.Backend.Infra.Ioc.Logger;
using InsurSoft.Backend.Infra.Ioc.Mediator;
using InsurSoft.Backend.Infra.Ioc.Validation;
using InsurSoft.Backend.Web.Segurados.Infra.Ioc;
using InsurSoft.Backend.Web.Seguros.Infra.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using System;
using System.Linq;

namespace InsurSoft.Backend.Infra.Ioc
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
