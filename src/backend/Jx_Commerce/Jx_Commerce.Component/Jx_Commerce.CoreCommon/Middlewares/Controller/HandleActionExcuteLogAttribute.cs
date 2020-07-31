using Jx_Commerce.Common.LogHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jx_Commerce.CoreCommon.Middlewares.Controller
{
    public class HandleActionExcuteLogAttribute : ActionFilterAttribute
    {
        private readonly ILogService _logService;

        public HandleActionExcuteLogAttribute(ILogService logService)
        {
            _logService = logService;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("这里是OnActionExecuted");
            this._logService.LogInfo("这里是OnActionExecuted");
            base.OnActionExecuted(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("这里是OnActionExecuting");
            this._logService.LogInfo("这里是OnActionExecuting");
            //if (!context.ModelState.IsValid)
            //{
            //    var error = context.ModelState.Values.SelectMany(x => x.Errors);
            //    context.Result = new JsonResult(error.Select(x => x.ErrorMessage).Aggregate((i, next) => $"{i},{next}"));
            //}
            base.OnActionExecuting(context);
        }
    }
}
