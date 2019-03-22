using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.Api.Filter;
using NetCore.Infrastructures.JwtToken;
using NetCore.Infrastructures.Service;
using NetCore.Repository;
using NetCore.Repository.Interface;
using NetCore.Services;
using NetCore.Services.Interface;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCore.Api
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
            //注册 Token
            TokenAuthHelper.AddTokenService(services, Configuration);

            //注册 swagger
            AddSwagger(services);

            // 注册自定义实例
            AddInstance(services);

            // =================== 注册 MVC 中间件=========================
            services.AddMvc(option =>
            {
                option.Filters.Add<GlobalExceptionFilter>();
                //option.Filters.Add<AccessAuthorizeFilter>();
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
            //启用 Token 验证
            app.UseAuthentication();
            //启用默态页面文件
            app.UseStaticFiles();

            // ==================  Swagger ===================
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetCore.Api");
            });

            //启用 MVC
            app.UseMvc();

        }


        /// <summary>
        /// 注册自定义实例服务
        /// </summary>
        /// <param name="services"></param>
        private void AddInstance(IServiceCollection services)
        {
            // AddScoped 在请求开始到请求结束中，在此次请求中获取的对象都是同一个
            // AddTransient 每次从容器(IServiceProvider)中获取的都是一个新的实例，每次使用时都是一个新的实例
            // AddSingleton 每次从容器(IServiceProvider)中获取的都是同一个实例，项目启动-项目关闭,相当于单例 

            #region 注入单个实例

            // 注入 数据库连接项
            //services.Configure<DbConnectionOptions>(Configuration.GetSection("DbConnectionOptions"));
            // 注入 UnitOfWork 工作单元
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            // 注入 DbContext 数据库上下文
            //services.AddScoped<IDbContext, DbContext>();

            //===================  注入 Repository 仓储 ======================
            //services.AddScoped<ISysRoleRepository, SysRoleRepository>();
            //services.AddScoped<ISysUserRepository, SysUserRepository>();

            //====================  注入 Service 服务 =========================          
            //services.AddScoped<ISysRoleService, SysRoleService>();
            //services.AddScoped<ISysUserService, SysUserService>(); 

            #endregion

            #region 注入多个实例

            // 注入 数据库上下文
            services.AddDbService(Configuration);
            // 注入 Service 服务
            services.AddServices(typeof(Service).Assembly, typeof(IService).Assembly, typeof(IService), "Service");
            // 注入 Repository 仓储
            services.AddServices(typeof(DbService).Assembly, typeof(IDbService).Assembly, typeof(IDbService), "Repository");

            #endregion

        }


        /// <summary>
        /// 注册 Swagger 接口文档服务
        /// </summary>
        /// <param name="services"></param>
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info()
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

                //添加 token 验证
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", Enumerable.Empty<string>() }
                });
            });
        }
    }
}
