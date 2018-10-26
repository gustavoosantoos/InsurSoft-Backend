using InsurSoft.Backend.Infra.Shared.Config.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Infra.Shared.Config
{
    public class DatabaseConfig : BaseConfig
    {
        public static IConfigurationSection Section => Configuration.GetSection("ConnectionStrings");

        public static string ConnectionStringPostgreSQL => Section.GetSection("PostgreSQL").Value;
    }
}
