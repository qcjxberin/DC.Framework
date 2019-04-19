using Ding.Hangfire.Models;
using Microsoft.AspNetCore.Http;

namespace Ding.Hangfire.Utils
{
    public class HangfireHelper
    {
        internal const string AccessKeyName = "key";
        internal const string CookieAccessKeyName = "FivePower_Hangfire_AccessKey";

        public static bool IsCanAccessHangfireDashboard(HttpContext httpContext, DingHangfireOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.AccessKey))
            {
                return true;
            }

            string requestKey = httpContext.Request.Query[AccessKeyName];

            requestKey = string.IsNullOrWhiteSpace(requestKey) ? httpContext.Request.Cookies[CookieAccessKeyName] : requestKey;

            var isCanAccess = options.AccessKey == requestKey;

            return isCanAccess;
        }
    }
}
