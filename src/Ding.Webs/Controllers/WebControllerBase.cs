using Ding.CookieManager;
using Ding.Helpers;
using Ding.Logs;
using Ding.Localization;
using Ding.Properties;
using Ding.Webs.Commons;
using Ding.Webs.Filters;
using Ding.Webs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ding.Webs.Controllers
{
    /// <summary>
    /// Web控制器
    /// </summary>
    [ExceptionHandler]
    [ErrorLog]
    [WebTraceLog]
    public abstract class WebControllerBase : Controller
    {
        public WebControllerBase()
        {
            var _cookie = Ioc.Create<ICookie>();
            if (_cookie != null)
            {
                Sid = _cookie.Get("sid");
                if (string.IsNullOrEmpty(Sid))
                {
                    // 生成sid
                    Sid = Id.GenerateSid();
                    _cookie.Set("sid", Sid, new CookieOptions() { HttpOnly = true, Expires = System.DateTime.Now.AddMonths(1) });
                }
            }
        }

        /// <summary>
        /// 用户惟一标识符
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// MarkDown解析类
        /// </summary>
        public Marked Marked { get; set; } = new Marked();

        /// <summary>
        /// 多语言对象
        /// </summary>
        public IStringReader SR
        {
            get
            {
                return Ioc.Create<IStringReader>();
            }
        }

        /// <summary>
        /// 日志
        /// </summary>
        private ILog _log;

        /// <summary>
        /// 日志
        /// </summary>
        public ILog Log => _log ?? (_log = GetLog());

        /// <summary>
        /// 获取日志操作
        /// </summary>
        protected virtual ILog GetLog()
        {
            try
            {
                return Ding.Logs.Log.GetLog(this);
            }
            catch
            {
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
        protected virtual IActionResult Success(dynamic data = null, string message = null)
        {
            if (message == null)
                message = R.Success;
            return new Result(StateCode.Ok, message, data);
        }

        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        protected virtual IActionResult Fail(string message)
        {
            return new Result(StateCode.Fail, message);
        }

        /// <summary>
        /// 获得路由中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        protected int GetRouteInt(string key, int defaultValue)
        {
            return Convert.ToInt(RouteData.Values[key], defaultValue);
        }

        /// <summary>
        /// 获得路由中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        protected int GetRouteInt(string key)
        {
            return GetRouteInt(key, 0);
        }

        /// <summary>
        /// 获得路由中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        protected string GetRouteString(string key, string defaultValue)
        {
            object value = RouteData.Values[key];
            if (value != null)
                return value.ToString();
            else
                return defaultValue;
        }

        /// <summary>
        /// 获得路由中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        protected string GetRouteString(string key)
        {
            return GetRouteString(key, "");
        }

        /// <summary>
        /// 提示信息视图
        /// </summary>
        /// <param name="backUrl">返回地址</param>
        /// <param name="message">提示信息</param>
        /// <returns></returns>
        protected ViewResult PromptView(string backUrl, string message)
        {
            return View("prompt", new PromptModel { BackUrl = backUrl, Message = message });
        }

        /// <summary>
        /// 提示信息视图
        /// </summary>
        /// <param name="backUrl">返回地址</param>
        /// <param name="message">提示信息</param>
        /// <param name="isAutoBack">是否自动返回</param>
        /// <returns></returns>
        protected ViewResult PromptView(string backUrl, string message, bool isAutoBack)
        {
            return View("prompt", new PromptModel { BackUrl = backUrl, Message = message, IsAutoBack = isAutoBack });
        }
    }
}
