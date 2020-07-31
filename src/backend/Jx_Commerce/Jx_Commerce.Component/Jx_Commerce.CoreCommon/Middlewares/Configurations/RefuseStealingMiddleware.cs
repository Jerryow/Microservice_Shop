using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Jx_Commerce.CoreCommon.Middlewares.Configurations
{
    public class RefuseStealingMiddleware
    {
        private readonly RequestDelegate next;

        public RefuseStealingMiddleware(RequestDelegate _next)
        {
            next = _next;
        }

        public async Task Invoke(HttpContext context)
        {
            string url = context.Request.Path.Value;
            if (url.ToLower().EndsWith(".jpg")||
                url.ToLower().EndsWith(".png") ||
                url.ToLower().EndsWith(".gif")
                )
            {
                string urlReferrer = context.Response.Headers["Referer"];//http头的信息,包含当前请求的页面域名
                if (string.IsNullOrWhiteSpace(urlReferrer))//直接访问
                {
                    await this.SetForBiddenImg(context);//返回404图片
                }
                else if (!urlReferrer.Contains("localhost"))//非当前域名
                {
                    await this.SetForBiddenImg(context);//返回404图片
                }
                else
                {
                    await next(context);
                }
            }
            await next(context);
        }

        public async Task SetForBiddenImg(HttpContext context)
        {
            string defaultImgPath = @"C:\Users\Administrator\Pictures\f.jpg";
            //string path = Path.Combine(Directory.GetCurrentDirectory(), defaultImgPath);

            FileStream fs = File.OpenRead(defaultImgPath);
            byte[] bs = new byte[fs.Length];
            await fs.ReadAsync(bs, 0, bs.Length);
            await context.Response.Body.WriteAsync(bs, 0, bs.Length);
        }

    }
}
