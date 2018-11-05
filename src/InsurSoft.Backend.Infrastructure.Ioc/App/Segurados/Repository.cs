using InsurSoft.Backend.Infrastructure.Repositories.Postgres.Segurados;
using InsurSoft.Backend.Web.Segurados.Domain.Interfaces;
using SimpleInjector;

namespace InsurSoft.Backend.Infrastructure.Ioc.App.Segurados
{
    public static class Repository
    {
        public static void RegisterIocSeguradosRepositories(this Container container)
        {
            container.Register<ISeguradoRepositoryAsync, SeguradoRepositoryAsync>(Lifestyle.Scoped);
        }
    }
}
