using InsurSoft.Backend.Web.Segurados.Domain.Interfaces.Repositories;
using InsurSoft.Backend.Web.Segurados.Infra.Repository;
using SimpleInjector;

namespace InsurSoft.Backend.Web.Segurados.Infra.Ioc
{
    public static class Repositories
    {
        public static void RegisterIocSeguradosRepositories(this Container container)
        {
            container.Register<ISeguradoRepository, SeguradoNullRepository>(Lifestyle.Scoped);
        }
    }
}
