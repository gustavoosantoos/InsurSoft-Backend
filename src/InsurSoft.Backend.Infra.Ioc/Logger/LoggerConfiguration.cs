using Microsoft.Extensions.Logging;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Infra.Ioc.Logger
{
    public static class LoggerConfiguration
    {
        public static void RegisterLoggerIoc(this Container container)
        {
            container.Register(typeof(ILogger<>), typeof(Logger<>), Lifestyle.Scoped);
        }
    }
}
