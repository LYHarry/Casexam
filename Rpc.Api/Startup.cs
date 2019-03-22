using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rpc.Api.Filter;
using Rpc.Infrastructures.Server.RequestClient;
using Rpc.Infrastructures.Server.RPC;
using System;
using System.Collections.Generic;

namespace Rpc.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //注册 swagger
            AddSwagger(services);

            // 注册自定义实例
            AddInstance(services);

            // =================== 注册 MVC 中间件=========================
            services.AddMvc(opt =>
            {
                opt.Filters.Add<GlobalExceptionFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        /// <summary>
        /// 配置 http 请求管道
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // 当前环境为开发环境时，抛出异常错误信息
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //启用默态页面文件
            app.UseStaticFiles();

            // ==================  Swagger ===================
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rpc.Api");
            });

            //启用 MVC
            app.UseMvc();

        }


        /// <summary>
        /// 注册 Swagger 接口文档服务
        /// </summary>
        /// <param name="services"></param>
        private void AddSwagger(IServiceCollection services)
        {
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
        }


        /// <summary>
        /// 注册自定义实例服务
        /// </summary>
        /// <param name="services"></param>
        private void AddInstance(IServiceCollection services)
        {
            //得到服务器地址
            var serviceSiteOptions = Configuration.GetSection("RpcServiceOptions").Get<List<ServiceSiteOption>>();
            //注入 rpc 服务地址项
            services.AddSingleton(serviceSiteOptions);
            //注入 服务请求 操作类
            services.AddScoped<IServiceRequestClient, ServiceRequestClient>();
        }
    }
}
