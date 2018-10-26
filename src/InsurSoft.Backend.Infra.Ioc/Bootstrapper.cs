using InsurSoft.Backend.Infra.Ioc.AutoMapper;
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

namespace InsurSoft.Backend.Infra.Ioc
{
    public static class Bootstrapper
    {
        private static Container container = new Container();

        public static void Init(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(container));

            services.EnableSimpleInjectorCrossWiring(container);
            services.UseSimpleInjectorAspNetRequestScoping(container);
        }

        public static void InitContainer(this IApplicationBuilder app)
        {
            container.Options.DefaultLifestyle = Lifestyle.Scoped;
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.RegisterMvcControllers(app);

            container.RegisterLoggerIoc();
            container.RegisterMediatorIoc();
            container.RegisterSeguradosIoc();
            container.RegisterAutoMapperIoc();

            container.AutoCrossWireAspNetComponents(app);
        }

        public static void Verify(this IApplicationBuilder app)
        {
            container.Verify();
        }
    }
}
