using InsurSoft.Backend.Infra.Repository.PostgreSQL.Context;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Infra.Ioc.Context
{
    public static class ContextConfiguration
    {
        public static void RegisterContextIoc(this Container container)
        {
            container.Register<InsurSoftContext>(Lifestyle.Scoped);
        }
    }
}
