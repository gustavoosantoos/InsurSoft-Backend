using Microsoft.Extensions.Logging;
using SimpleInjector;

namespace InsurSoft.Backend.Infrastructure.Ioc.Logger
{
    public static class LoggerConfiguration
    {
        public static void RegisterLoggerIoc(this Container container)
        {
            container.Register(typeof(ILogger<>), typeof(Logger<>), Lifestyle.Scoped);
        }
    }
}
