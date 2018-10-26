using InsurSoft.Backend.Infra.Repository.PostgreSQL.Context;
using InsurSoft.Backend.Shared.Domain.Interfaces;
using InsurSoft.Backend.Shared.Domain.Repositories;
using SimpleInjector;

namespace InsurSoft.Backend.Infra.Ioc.Context
{
    public static class ContextConfiguration
    {
        public static void RegisterContextIoc(this Container container)
        {
            container.Register<InsurSoftContext>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
        }
    }
}
