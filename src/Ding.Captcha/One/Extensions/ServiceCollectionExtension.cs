using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ding.Captcha
{
    public static class ServiceCollectionExtension
    {
        public static void AddCaptchaService(this IServiceCollection services, Action<CaptchaOptions> options)
        {
            services.Configure(options);
            services.AddSingleton<ICaptchaFactory, CaptchaFactory>();
        }
    }
}
