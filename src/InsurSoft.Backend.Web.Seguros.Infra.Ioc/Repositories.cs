using InsurSoft.Backend.Web.Seguros.Domain.Repositories;
using InsurSoft.Backend.Web.Seguros.Infra.Repositories;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Seguros.Infra.Ioc
{
    public static class Repositories
    {
        public static void RegisterSegurosIocRepositories(this Container container)
        {
            container.Register<IApoliceRepositoryAsync, ApoliceRepositoryAsync>(Lifestyle.Scoped);
        }
    }
}
