using Consul;
using Microsoft.Extensions.Configuration;
using System;

namespace Jx_Commerce.CoreCommon.Consul.Register
{
    public static class ConsulHelper
    {
        public static void ConsulRegist(this IConfiguration configuration)
        {
            try
            {
                var url = configuration["ConsulConfig:ConsulUrl"];
                var url1 = configuration["ConsulConfig:ID"];
                var url2 = configuration["ConsulConfig:GroupName"];
                var url3 = configuration["ConsulConfig:RegistIp"];
                var url4 = configuration["ConsulConfig:RegistPort"];
                //consul启动的实例对象
                ConsulClient client = new ConsulClient(x =>
                {
                    x.Address = new Uri(configuration["ConsulConfig:ConsulUrl"]);
                    x.Datacenter = "dc1";
                });

                client.Agent.ServiceRegister(new AgentServiceRegistration()
                {
                    ID = configuration["ConsulConfig:ID"],//组成员名称
                    Name = configuration["ConsulConfig:GroupName"],//服务Group名称
                    Address = configuration["ConsulConfig:RegistIp"],//服务ip
                    Port = Convert.ToInt32(configuration["ConsulConfig:RegistPort"]),//服务端口
                    Tags = new string[] { configuration["ConsulConfig:ID"] },
                    Check = new AgentServiceCheck()
                    {
                        Interval = TimeSpan.FromSeconds(10),//10s心跳检测一次
                        HTTP = $"http://{configuration["ConsulConfig:RegistIp"]}:{Convert.ToInt32(configuration["ConsulConfig:RegistPort"])}/api/checkapi/check",//心跳检测的地址
                        Timeout = TimeSpan.FromSeconds(5),//检测等待时间
                        DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(11)//失败多久后移除
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
