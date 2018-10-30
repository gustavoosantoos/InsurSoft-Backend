using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Segurados.Infra.Ioc
{
    public static class Bootstrapper
    {
        public static void RegisterSeguradosIoc(this Container container)
        {
            container.RegisterIocSeguradosApplication();
        }
    }
}
