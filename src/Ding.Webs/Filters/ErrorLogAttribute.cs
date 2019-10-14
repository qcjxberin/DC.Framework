﻿using Microsoft.AspNetCore.Mvc.Filters;
using Ding.Logs;
using Ding.Logs.Extensions;

namespace Ding.Webs.Filters {
    /// <summary>
    /// 错误日志过滤器
    /// </summary>
    public class ErrorLogAttribute : ExceptionFilterAttribute {
        /// <summary>
        /// 异常处理
        /// </summary>
        public override void OnException( ExceptionContext context ) {
            if( context == null )
                return;
            var log = Ding.Logs.Log.GetLog( context ).Caption( "WebApi全局异常" );
            context.Exception.Log( log );
        }
    }
}