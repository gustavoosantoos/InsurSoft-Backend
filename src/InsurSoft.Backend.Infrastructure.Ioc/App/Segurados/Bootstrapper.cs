using SimpleInjector;

namespace InsurSoft.Backend.Infrastructure.Ioc.App.Segurados
{
    public static class Bootstrapper
    {
        public static void RegisterSeguradosIoc(this Container container)
        {
            container.RegisterIocSeguradosRepositories();
            container.RegisterIocSeguradosApplication();
        }
    }
}
