using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Jx_Commerce.CoreCommon.Middlewares.Controller
{
    public class HandlerResultController : ControllerBase
    {
        #region 成功
        /// <summary>
        /// 成功状态码
        /// </summary>
        /// <returns></returns>
        protected HttpResponseMessage Success()
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// 成功消息
        /// </summary>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        protected IActionResult Success(string msg)
        {
            return new JsonResult(new { code = "1", msg = msg });
        }

        /// <summary>
        /// 成功消息+数据
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        protected IActionResult Success(string msg, object data)
        {
            return new JsonResult(new { code = "1", msg = msg, data = data });
        }

        /// <summary>
        /// 成功消息+数据
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        protected IActionResult Success(object data)
        {
            return new JsonResult(new { code = "1", msg = "成功", data = data });
        }

        /// <summary>
        /// 成功消息+数据
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        protected IActionResult SuccessNull(string msg, object data)
        {
            return new JsonResult(new { code = "2", msg = msg, data = data });
        }
        #endregion

        #region 失败
        /// <summary>
        /// 失败消息Result
        /// </summary>
        /// <param name="msg">内容</param>
        /// <returns></returns>
        protected IActionResult Fail(string msg)
        {
            return new JsonResult(new { code = "0", msg = msg });
        }


        /// <summary>
        /// 失败消息+数据
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        protected IActionResult Fail(string msg, object data)
        {
            return new JsonResult(new { code = "0", msg = msg, data = data });
        }
        #endregion

    }
}
