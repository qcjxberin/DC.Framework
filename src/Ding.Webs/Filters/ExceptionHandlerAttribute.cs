﻿using Microsoft.AspNetCore.Mvc.Filters;
using Ding.Webs.Commons;

namespace Ding.Webs.Filters {
    /// <summary>
    /// 异常处理过滤器
    /// </summary>
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute {
        /// <summary>
        /// 异常处理
        /// </summary>
        public override void OnException( ExceptionContext context ) {
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = 200;
            context.Result = new Ding.Webs.Commons.Result( StateCode.Fail, context.Exception.GetPrompt() );
        }
    }
}
