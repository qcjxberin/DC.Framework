using Ding.CookieManager;
using Ding.Helpers;
using Ding.Logs;
using Ding.Properties;
using Ding.Webs.Commons;
using Ding.Webs.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Ding.Webs.Controllers
{
    /// <summary>
    /// Razor控制基类
    /// </summary>
    [ExceptionHandler]
    [ErrorLog]
    [PageModelTraceLog]
    public class PageModelBase : PageModel
    {
        public PageModelBase()
        {
            var _cookie = Ioc.Create<ICookie>();
            if (_cookie != null)
            {
                Sid = _cookie.Get("sid");
                if (string.IsNullOrEmpty(Sid))
                {
                    // 生成sid
                    Sid = Id.GenerateSid();
                    var CookieOptions = Ioc.Create<IOptions<CookieManagerOptions>>();
                    _cookie.Set("sid", Sid, new CookieOptions() { HttpOnly = true, Expires = System.DateTime.Now.AddMonths(1), Domain = CookieOptions.Value.Domain });
                }
            }
        }

        /// <summary>
        /// 用户惟一标识符
        /// </summary>
        protected string Sid { get; set; }

        /// <summary>
        /// MarkDown解析类
        /// </summary>
        public Marked Marked { get; set; } = new Marked();

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
    }
}
