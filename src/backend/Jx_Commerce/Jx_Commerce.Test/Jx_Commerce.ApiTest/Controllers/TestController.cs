using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Jx_Commerce.Common.LogHelper;
using Jx_Commerce.SystemService;
using Microsoft.Extensions.Configuration;

namespace Jx_Commerce.ApiTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly ITest _test;
        private readonly IConfiguration _configuration;
        public TestController(
            ILogService logService,
             ITest test,
             IConfiguration configuration)
        {
            _logService = logService;
            _configuration = configuration;
            _test = test;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _test.SaySomething("fvsdafdsfds");
            _logService.LogInfo("312");
            return new JsonResult(new { code = "1", msg = data , con = _configuration.GetSection("DataAccess:DbType").Value,conn= _configuration.GetSection("DataAccess:ConnectionStr:Master").Value });
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            var data = _test.GetSystemUser();
            return new JsonResult(new { code = "1", msg = data });
        }
    }
}
