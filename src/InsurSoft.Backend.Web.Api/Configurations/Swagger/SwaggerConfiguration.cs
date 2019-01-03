using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Web.Api.Configurations.Swagger
{
    public static class SwaggerConfiguration
    {
        public static void AddInsursoftSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "InsurSoft.Web", Version = "v1" });
            });
        }

        public static void UseInsursoftSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "InsurSoft.Web");
            });
        }
    }
}
