using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jx_Commerce.CoreCommon.Middlewares.Configurations.Extend
{
    public static class MiddlewareExtension
    {
        /// <summary>
        /// Swagger
        /// </summary>
        /// <param name="app"></param>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSwaggerBuilder(this IApplicationBuilder app, string assemblyName)
        {
            app.UseSwagger();

            return app.UseSwaggerUI(u =>
            {
                u.SwaggerEndpoint($"/swagger/{assemblyName}/swagger.json", assemblyName);
                u.RoutePrefix = "jerryow";
                u.DocumentTitle = "Jerryow";
            });
        }
    }
}
