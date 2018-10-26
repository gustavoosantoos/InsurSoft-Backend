using InsurSoft.Backend.Web.Segurados.Application.Interfaces;
using InsurSoft.Backend.Web.Segurados.Application.Services;
using SimpleInjector;

namespace InsurSoft.Backend.Web.Segurados.Infra.Ioc
{
    public static class Application
    {
        public static void RegisterIocSeguradosApplication(this Container container)
        {
            container.Register<ISeguradoAppService, SeguradoAppService>(Lifestyle.Scoped);
        }
    }
}
