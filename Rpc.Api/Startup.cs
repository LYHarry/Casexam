using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Rpc.Api.Filter;
using Rpc.Infrastructures.Server.RequestClient;
using Rpc.Infrastructures.Server.RPC;

namespace Rpc.Api
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
            //注入 rpc 服务地址项
            services.Configure<List<ServiceSiteOption>>(Configuration.GetSection("RpcServiceOptions"));
            // 注入 服务请求 操作类
            services.AddScoped<IServiceRequestClient, ServiceRequestClient>();

            // ==================  Swagger ===================
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Title = "Rpc.Api",
                    Description = "Rpc.Demo"
                });
                c.IncludeXmlComments($"{AppContext.BaseDirectory}/Rpc.Api.xml", true);
                // 接口请求参数注释文档
                c.IncludeXmlComments($"{AppContext.BaseDirectory}/Rpc.Model.xml");
                // 接口返回参数注释文档
                c.IncludeXmlComments($"{AppContext.BaseDirectory}/Rpc.ViewModel.xml");
                c.CustomSchemaIds(p => p.FullName);
                c.DescribeAllEnumsAsStrings();
            });

            services.AddMvc(opt =>
            {
                opt.Filters.Add<GlobalException>();
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc();

            // ==================  Swagger ===================
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rpc.Api");
            });
        }
    }
}
