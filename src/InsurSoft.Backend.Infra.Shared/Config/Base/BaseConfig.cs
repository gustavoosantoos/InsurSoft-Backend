﻿using Microsoft.Extensions.Configuration;
using System.IO;

namespace InsurSoft.Backend.Infra.Shared.Config.Base
{
    public class BaseConfig
    {
        public static IConfiguration _config { get; private set; }

        public static IConfiguration Configuration
        {
            get
            {
                if (_config == null)
                {
                    var dir = Directory.GetCurrentDirectory();

                    _config = new ConfigurationBuilder()
                      .SetBasePath(dir)
                      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                      .Build();
                }

                return _config;
            }
        }
    }
}
