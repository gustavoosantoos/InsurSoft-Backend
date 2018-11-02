using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Seguros.Infra.Ioc
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
