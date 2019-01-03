using FluentValidation.AspNetCore;
using InsurSoft.Backend.Infrastructure.Ioc;
using InsurSoft.Backend.Infrastructure.Ioc.Validation;
using InsurSoft.Backend.Web.Api.AutoMapper;
using InsurSoft.Backend.Web.Api.Configurations.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace InsurSoft.Backend.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => fv.ValidatorFactory = new ApplicationValidatorFactory(Bootstrapper.Container));
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            services.AddInsursoftSwagger();

            services.Init();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.InitContainer(container =>
            {
                container.RegisterAutoMapperIoc();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseInsursoftSwagger();
            app.Verify();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
