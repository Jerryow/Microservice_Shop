using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Jx_Commerce.CoreCommon.Middlewares.ConfigureServices
{
    public static class ConfigureServicesExtension
    {
        //public static IMvcBuilder CustomJsonConfiguration(this IMvcBuilder builder)
        //{
        //   builder.AddNewtonsoftJson
        //}

        /// <summary>
        /// swagger
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblyName"></param>
        /// <param name="name"></param>
        /// <param name="title"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwaggerCollection(this IServiceCollection services, string assemblyName, string title = "OpenApi", string version = "v1")
        {
            return services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc(assemblyName, new OpenApiInfo
                {
                    Title = title,
                    Version = version,
                    Contact = new OpenApiContact()
                    {
                        Name = "jerryow",
                        Email = "jerryow.xu@outlook.com"
                    }
                });

                var xmlFile = $"{assemblyName}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath, true); //添加控制器层注释（true表示显示控制器注释） 

                //添加Bearer Token
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Please enter into field the word 'Bearer' followed by a space and the JWT value",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new List<string>()
                    }
                });
            });
        }
    }

}
