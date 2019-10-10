﻿using Ding.CookieManager;
using Ding.Helpers;
using Ding.Localization;
using Ding.Logs;
using Ding.Properties;
using Ding.Webs.Commons;
using Ding.Webs.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Ding.Webs.Controllers
{
    /// <summary>
    /// WebApi控制器
    /// </summary>
    [Route( "api/[controller]" )]
    [ExceptionHandler]
    [ErrorLog]
    [TraceLog]
    public abstract class WebApiControllerBase : Controller {

        public WebApiControllerBase()
        {
            var _cookie = Ioc.Create<ICookie>();
            if (_cookie != null)
            {
                Sid = _cookie.Get("sid");
                if (string.IsNullOrEmpty(Sid))
                {
                    // 生成sid
                    Sid = Id.GenerateSid();
                    _cookie.Set("sid", Sid, new CookieOptions() { HttpOnly = true, Expires = DateTime.Now.AddMonths(1) });
                }
            }
        }

        /// <summary>
        /// 用户惟一标识符
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// Cookie操作类
        /// </summary>
        public SmartCookies Cookies { get { return Ioc.Create<SmartCookies>(); } }

        /// <summary>
        /// 多语言对象
        /// </summary>
        public IStringReader SR { get { return Ioc.Create<IStringReader>(); } }

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
        public virtual Ding.Sessions.ISession Session => Sessions.Session.Instance;

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