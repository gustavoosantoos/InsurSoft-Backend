using InsurSoft.Backend.Infrastructure.Repositories.Postgres.Context;
using SimpleInjector;

namespace InsurSoft.Backend.Infrastructure.Ioc.Context
{
    public static class ContextConfiguration
    {
        public static void RegisterContextIoc(this Container container)
        {
            container.Register<InsurSoftContext>(Lifestyle.Scoped);
        }
    }
}
