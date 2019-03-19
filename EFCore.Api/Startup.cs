using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Api.Filter;
using EFCore.Infrastructures.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EFCore.Api
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
            services.AddMvc(opt =>
            {
                opt.Filters.Add<GlobalException>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<EfDbContext>(opt =>
            {
                opt.UseNpgsql(Configuration.GetConnectionString("Default"));
            });

            // ==================  Swagger ===================
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Title = "EFCore.Api",
                    Description = "EFCore.Demo"
                });
                c.IncludeXmlComments($"{AppContext.BaseDirectory}/EFCore.Api.xml", true);
                // 接口请求参数注释文档
                c.IncludeXmlComments($"{AppContext.BaseDirectory}/EFCore.Model.xml");
                // 接口返回参数注释文档
                c.IncludeXmlComments($"{AppContext.BaseDirectory}/EFCore.ViewModel.xml");
                c.CustomSchemaIds(p => p.FullName);
                c.DescribeAllEnumsAsStrings();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            // ==================  Swagger ===================
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetCore.Api");
            });
        }
    }
}
