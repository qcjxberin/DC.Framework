using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.AspNetCore.Mvc
{
    public class QueryStringRequestTemplateProvider : IRequestTemplateProvider
    {
        public HttpContext HttpContext { get; set; }

        public string QueryField { get; }

        public IServiceProvider Services { get; }

        public QueryStringRequestTemplateProvider(IServiceProvider provider, string queryField = "template")
        {
            QueryField = queryField;
            Services = provider;
        }

        public string DetermineRequestTemplate()
        {
            try
            {
                HttpContext = Services.GetRequiredService<IHttpContextAccessor>().HttpContext;
                return HttpContext.Request.Query[QueryField].ToString();
            }
            catch
            {
                return null;
            }
        }
    }
}