﻿using Microsoft.AspNetCore.Mvc;
using Ding.Logs;
using Ding.Properties;
using Ding.Sessions;
using Ding.Webs.Commons;
using Ding.Webs.Filters;

namespace Ding.Webs.Controllers {
    /// <summary>
    /// WebApi控制器
    /// </summary>
    [Route( "api/[controller]" )]
    [ExceptionHandler]
    [ErrorLog]
    [TraceLog]
    public abstract class WebApiControllerBase : Controller {
        /// <summary>
        /// 日志
        /// </summary>
        private ILog _log;

        /// <summary>
        /// 日志
        /// </summary>
        public ILog Log => _log ?? ( _log = GetLog() );

        /// <summary>
        /// 获取日志操作
        /// </summary>
        protected virtual ILog GetLog() {
            try {
                return Ding.Logs.Log.GetLog( this );
            }
            catch {
                return Ding.Logs.Log.Null;
            }
        }

        /// <summary>
        /// 会话
        /// </summary>
        public virtual ISession Session => Security.Sessions.Session.Instance;

        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        protected virtual IActionResult Success( dynamic data = null, string message = null ) {
            if( message == null )
                message = R.Success;
            return new Result( StateCode.Ok, message, data );
        }

        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        protected virtual IActionResult Fail( string message ) {
            return new Result( StateCode.Fail, message );
        }
    }
}