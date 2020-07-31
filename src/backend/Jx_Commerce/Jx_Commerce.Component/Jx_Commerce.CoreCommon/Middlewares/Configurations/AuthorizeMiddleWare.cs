using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jx_Commerce.CoreCommon.Middlewares.Configurations
{
    public class AuthorizeMiddleWare
    {
        private readonly RequestDelegate _next;
        public AuthorizeMiddleWare(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine(context.Request.Headers["Authorization"].ToString().ToLower().Replace("bearer", "").Trim());
            if (context.Request.Headers["Authorization"].ToString().ToLower().Replace("bearer","").Trim() == "123")
            {
                await this._next.Invoke(context);
            }
            else
            {

                var url = context.Request.GetDisplayUrl();
                if (url.EndsWith("index.html"))
                {
                    await this._next.Invoke(context);
                }
                else
                {
                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "application/json";

                    await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(new { code = "0", msg = "用户认证失败,您暂无权限访问." }));
                }
            }
            //await this._next.Invoke(context);
        }
    }
}