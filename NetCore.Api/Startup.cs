using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.Api.Filter;
using NetCore.Infrastructures.Repository;
using NetCore.Infrastructures.Service;
using NetCore.Repository;
using NetCore.Repository.Interface;
using NetCore.Services;
using NetCore.Services.Interface;

namespace NetCore.Api
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
            // ==================  Swagger ===================
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Title = "NetCore.Api",
                    Description = "NetCore.Demo"
                });
                c.IncludeXmlComments($"{AppDomain.CurrentDomain.BaseDirectory}/NetCore.Api.xml", true);
                // 接口请求参数注释文档
                c.IncludeXmlComments($"{AppDomain.CurrentDomain.BaseDirectory}/NetCore.Models.xml");
                // 接口返回参数注释文档
                c.IncludeXmlComments($"{AppDomain.CurrentDomain.BaseDirectory}/NetCore.ViewModels.xml");
                // 生成 API 时，如果有相同类名，但是命名空间又不相同时，
                // 则会报 See config settings - "CustomSchemaIds" for a workaround
                c.CustomSchemaIds(p => p.FullName);
                c.DescribeAllEnumsAsStrings();
                c.DocInclusionPredicate((docName, description) => true);
            });

            #region ====================  注入实例 =========================

            // 注入 数据库连接项
            services.Configure<DbConnectionOptions>(Configuration.GetSection("DbConnectionOptions"));

            // ================= 默认只能注入单个实例 =========================
            //// 注入 UnitOfWork 工作单元
            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            ////===================  注入 Repository 仓储 ======================
            //services.AddScoped<ISysRoleRepository, SysRoleRepository>();
            //services.AddScoped<ISysUserRepository, SysUserRepository>();

            ////====================  注入 Service 服务 =========================
            //// AddScoped 在请求开始到请求结束中，在此次请求中获取的对象都是同一个
            //// AddTransient 每次从容器(IServiceProvider)中获取的都是一个新的实例，每次使用时都是一个新的实例
            //// AddSingleton 每次从容器(IServiceProvider)中获取的都是同一个实例，项目启动-项目关闭,相当于单例 
            //services.AddScoped<ISysRoleService, SysRoleService>();
            //services.AddScoped<ISysUserService, SysUserService>();

            //==================== 同时注入多个实例 =========================

            // 注入 数据库上下文
            services.AddDbService(Configuration);
            // 注入 Service 服务
            services.AddServices(typeof(Service).Assembly, typeof(IService).Assembly, typeof(IService), "Service");
            // 注入 Repository 仓储
            services.AddServices(typeof(DbService).Assembly, typeof(IDbService).Assembly, typeof(IDbService), "Repository");

            #endregion

            // =================== 注册 MVC 中间件=========================
            services.AddMvc(option =>
            {
                option.Filters.Add<GlobalException>();
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseMvc();

            // ==================  Swagger ===================
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetCore.Api");
                //c.RoutePrefix = string.Empty; // 加上此句后好像页面显示不出来，swagger相关的js报404
            });


        }
    }
}
