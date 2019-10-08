using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ding.Localization
{
    public class DefaultTranslatorDisabler : ITranslatorDisabler
    {
        public IServiceProvider services { get; set; }

        public DefaultTranslatorDisabler(IServiceProvider services)
        {
            this.services = services;
        }

        public bool IsDisabled()
        {
            var httpContext = services.GetRequiredService<IHttpContextAccessor>().HttpContext;
            if (httpContext.Request.Cookies.ContainsKey("ASPNET_TRANSLATOR") && Convert.ToBoolean(httpContext.Request.Cookies["ASPNET_TRANSLATOR"]))
                return true;
            return false;
        }
    }
}
