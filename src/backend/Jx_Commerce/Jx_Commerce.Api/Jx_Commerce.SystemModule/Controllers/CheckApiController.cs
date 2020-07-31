using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Jx_Commerce.CoreCommon.Middlewares.Controller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jx_Commerce.SystemModule.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CheckApiController : HandlerResultController
    {
        /// <summary>
        /// Consul心跳检测
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Check()
        {
            return Success();
        }
    }
}
