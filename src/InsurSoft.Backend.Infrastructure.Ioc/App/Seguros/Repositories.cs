using InsurSoft.Backend.Infrastructure.Repositories.Postgres.Seguros;
using InsurSoft.Backend.Web.Seguros.Domain.Repositories;
using SimpleInjector;

namespace InsurSoft.Backend.Infrastructure.Ioc.App.Seguros
{
    public static class Repositories
    {
        public static void RegisterSegurosIocRepositories(this Container container)
        {
            container.Register<IApoliceRepositoryAsync, ApoliceRepositoryAsync>(Lifestyle.Scoped);
        }
    }
}
