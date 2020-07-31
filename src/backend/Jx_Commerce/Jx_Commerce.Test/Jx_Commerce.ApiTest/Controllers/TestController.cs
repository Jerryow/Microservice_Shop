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
    }
}
