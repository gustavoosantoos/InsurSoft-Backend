using SimpleInjector;

namespace InsurSoft.Backend.Infrastructure.Ioc.App.Seguros
{
    public static class Bootstrapper
    {
        public static void RegisterSegurosIoc(this Container container)
        {
            container.RegisterSegurosIocRepositories();
            container.RegisterSegurosIocApplication();
        }
    }
}
