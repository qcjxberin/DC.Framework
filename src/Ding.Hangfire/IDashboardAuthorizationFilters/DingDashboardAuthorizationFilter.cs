using Ding.Attributes;
using Ding.Hangfire.Models;
using Ding.Hangfire.Utils;
using Hangfire.Dashboard;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Ding.Hangfire.IDashboardAuthorizationFilters
{
    public class DingDashboardAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            var httpContext = context.GetHttpContext();

            var options = httpContext.RequestServices.GetService<IOptions<DingHangfireOptions>>().Value;

            var isCanAccess = HangfireHelper.IsCanAccessHangfireDashboard(httpContext, options);

            return isCanAccess;
        }
    }
}
