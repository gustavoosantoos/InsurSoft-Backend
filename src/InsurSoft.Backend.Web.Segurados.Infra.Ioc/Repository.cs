using InsurSoft.Backend.Web.Segurados.Domain.Interfaces;
using InsurSoft.Backend.Web.Segurados.Infra.Repositories;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Segurados.Infra.Ioc
{
    public static class Repository
    {
        public static void RegisterIocSeguradosRepositories(this Container container)
        {
            container.Register<ISeguradoRepositoryAsync, SeguradoRepositoryAsync>(Lifestyle.Scoped);
        }
    }
}
