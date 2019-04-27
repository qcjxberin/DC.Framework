using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.AspNetCore.Mvc
{
    public class CookieRequestTemplateProvider : IRequestTemplateProvider
    {
        public HttpContext HttpContext { get; set; }

        public IServiceProvider Services { get; }

        public string CookieField { get; }

        public CookieRequestTemplateProvider(IServiceProvider provider, string cookieField = "ASPNET_TEMPLATE")
        {
            CookieField = cookieField;
            Services = provider;
        }

        public string DetermineRequestTemplate()
        {
            try
            {
                HttpContext = Services.GetRequiredService<IHttpContextAccessor>().HttpContext;
                return HttpContext.Request.Cookies[CookieField]?.ToString();
            }
            catch
            {
                return null;
            }
        }
    }
}