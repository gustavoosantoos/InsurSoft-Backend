using AutoMapper;
using InsurSoft.Backend.Web.Segurados.Application.Mapping;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Infra.Ioc.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterAutoMapperIoc(this Container container)
        {
            container.RegisterSingleton(() => BuildMapper());
        }

        private static IMapper BuildMapper()
        {
            var config = new MapperConfiguration(builder =>
            {
                builder.AddProfile(new EntityToOutput());
            });

            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
