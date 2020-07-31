using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Jx_Commerce.Common.LogHelper;
using Jx_Commerce.SystemService;
using Microsoft.Extensions.Configuration;
using Jx_Commerce.DataAccess.DapperAccess.DapperBase;
using Jx_Commerce.DataAccess.Models.Sys;
using Dapper;
using System.Net.Http;

namespace Jx_Commerce.ApiTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IQueryRepository<System_User,int> _queryRepository;
        private readonly IExcuteDapper<System_User> _excuteDapper;
        private readonly IConfiguration _configuration;
        public TestController(
            ILogService logService,
             IConfiguration configuration,
             IQueryRepository<System_User, int> queryRepository,
             IExcuteDapper<System_User> excuteDapper)
        {
            _logService = logService;
            _configuration = configuration;
            _queryRepository = queryRepository;
            _excuteDapper = excuteDapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {
            var data = await _queryRepository.GetByIDAsync(id);
            var list = await _queryRepository.GetAllListAsync();

            try
            {
                _excuteDapper.ExcuteTransaction((conn, tran) =>
                {
                    var us = conn.Query<System_User>("select * from sys_userinfo").FirstOrDefault();
                    Console.WriteLine(us.UserName);
                    us.LastModifiedTime = DateTime.Now;
                    conn.Execute($"update sys_userinfo set sys_userinfo.UserName = 'admin12321321' where sys_userinfo.PKID = {1}");
                    conn.Execute($"update sys_userinfo set sys_userinfo.PKID = 2 where sys_userinfo.PKID = {1}");
                });
            }
            catch (Exception ex)
            {

            }


            //_excuteDapper.Excute((conn) =>
            //{
            //    var us = conn.Query<System_User>("select * from sys_userinfo").FirstOrDefault();
            //    Console.WriteLine(us.UserName);
            //    us.LastModifiedTime = DateTime.Now;
            //    conn.Execute($"update sys_userinfo set sys_userinfo.UserName = 'admin' where sys_userinfo.PKID = {1}");
            //    conn.Execute($"update sys_userinfo set sys_userinfo.PKID = 2 where sys_userinfo.PKID = {1}");
            //});

            return new JsonResult(new { code = "1", msg = data, list = list });
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = Jx_Commerce.CoreCommon.Consul.Client.ConsulClientHandler.GetServices("http://192.168.200.111:8510", "Jx_Commerce.SystemModule");
            Console.WriteLine(data.Item1);
            Console.WriteLine(data.Item2);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer 123");
                HttpRequestMessage msg = new HttpRequestMessage();
                msg.Method = HttpMethod.Get;
                //msg.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer 123");
                msg.RequestUri = new Uri($"http://{data.Item1}:{data.Item2}/api/SystemUserApi/GetSystemUserList");
                var res = client.SendAsync(msg).Result;
                var list = await res.Content.ReadAsStringAsync();
                Console.WriteLine(list);
                var users = Newtonsoft.Json.JsonConvert.DeserializeObject<System_User>(list);
                return new JsonResult(new { code = "1", data = list });
            }

        }
    }
}
