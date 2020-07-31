using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jx_Commerce.Common.LogHelper;
using Jx_Commerce.CoreCommon.Middlewares.Controller;
using Jx_Commerce.DataAccess.DapperAccess.DapperBase;
using Jx_Commerce.DataAccess.Models.Sys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jx_Commerce.SystemModule.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [TypeFilter(typeof(HandleActionExcuteLogAttribute))]
    public class SystemUserApiController : HandlerResultController
    {
        private readonly ILogService _logService;
        private readonly IQueryRepository<System_User, int> _queryRepository;
        private readonly IExcuteDapper<System_User> _excuteDapper;
        public SystemUserApiController(
            ILogService logService,
             IQueryRepository<System_User, int> queryRepository,
             IExcuteDapper<System_User> excuteDapper)
        {
            _logService = logService;
            _queryRepository = queryRepository;
            _excuteDapper = excuteDapper;
        }

        /// <summary>
        /// 根据ID获取单个用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSystemUserByID(int id)
        {
            return Succcess(await _queryRepository.GetByIDAsync(id));
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSystemUserList()
        {
            return Succcess(await _queryRepository.GetAllListAsync());
        }

        
    }
}
