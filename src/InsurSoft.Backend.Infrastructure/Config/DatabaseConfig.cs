using InsurSoft.Backend.Infrastructure.Config.Base;
using Microsoft.Extensions.Configuration;

namespace InsurSoft.Backend.Infrastructure.Config
{
    public class DatabaseConfig : BaseConfig
    {
        public static IConfigurationSection Section => Configuration.GetSection("ConnectionStrings");

        public static string ConnectionStringPostgreSQL => Section.GetSection("PostgreSQL").Value;
    }
}
