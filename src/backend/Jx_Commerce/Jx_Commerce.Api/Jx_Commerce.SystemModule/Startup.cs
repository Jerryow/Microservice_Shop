using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Jx_Commerce.CoreCommon.DependencyConfig;
using Jx_Commerce.CoreCommon.Middlewares.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Jx_Commerce.CoreCommon.Middlewares.ConfigureServices;
using Jx_Commerce.CoreCommon.Middlewares.Configurations.Extend;
using System.Reflection;

namespace Jx_Commerce.SystemModule
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
               .AddNewtonsoftJson
               (options =>
               {
                    //设置时间格式
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                    //忽略循环引用
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    //数据格式首字母小写
                    //options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    //数据格式按原样输出
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    //忽略空值
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
               });

            services.AddSwaggerCollection(Assembly.GetExecutingAssembly().GetName().Name, "系统模块","v1");
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Add any Autofac modules or registrations.
            // This is called AFTER ConfigureServices so things you
            // register here OVERRIDE things registered in ConfigureServices.
            //
            // You must have the call to `UseServiceProviderFactory(new AutofacServiceProviderFactory())`
            // when building the host or this won't be called.
            builder.RegisterModule(new SystemContainerConfigure());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();


            //swagger
            app.UseSwaggerBuilder(Assembly.GetExecutingAssembly().GetName().Name);

            //防盗链
            app.UseMiddleware<RefuseStealingMiddleware>();

            //访问token
            app.UseMiddleware<AuthorizeMiddleWare>();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
