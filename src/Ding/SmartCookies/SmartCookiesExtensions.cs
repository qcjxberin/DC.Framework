using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CookiesExtensions
    {
        public static IServiceCollection AddSmartCookies(this IServiceCollection self)
        {
            return self.AddScoped<SmartCookies>();
        }
    }
}
