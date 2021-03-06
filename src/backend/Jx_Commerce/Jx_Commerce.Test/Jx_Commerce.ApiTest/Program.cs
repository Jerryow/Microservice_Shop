using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Jx_Commerce.ApiTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())//autofac
             .ConfigureLogging((context, loggingBuilder) =>
             {
                 loggingBuilder.AddFilter("System", LogLevel.Warning);//���˵������ռ�
                 loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);
                 loggingBuilder.AddLog4Net();//Microsoft.Extensions.Logging.Log4Net.AspNetCore
             })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
