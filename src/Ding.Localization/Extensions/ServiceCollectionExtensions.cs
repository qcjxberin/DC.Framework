using Ding.Localization;
using Ding.Localization.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPomeloLocalization(this IServiceCollection self, Action<MemoryCultureSet> InitCultureSource = null)
        {
            var set = new MemoryCultureSet();
            InitCultureSource?.Invoke(set);
            self.AddMemoryCache();
            self.AddContextAccessor();
            self.AddSingleton<ICultureSet>(set);
            self.AddScoped<ICultureProvider, DefaultCultureProvider>();
            self.AddScoped<IStringReader, DefaultStringReader>();
            self.AddSingleton<ITranslator, NonTranslator>();
            self.AddSingleton<ITranslatedCaching, MemoryTranslatedCaching>();
            self.AddScoped<ITranslatorDisabler, DefaultTranslatorDisabler>();
            return self;
        }

        public static IServiceCollection AddLocalizationViewDataFilter(this IServiceCollection self)
        {
            return self.Configure<MvcOptions>(x => x.Filters.Add(typeof(LocalizationFilter)));
        }

        public static IServiceCollection AddBaiduTranslator(this IServiceCollection self)
        {
            return self.AddSingleton<ITranslator, BaiduTranslator>();
        }

        public static IServiceCollection AddContextAccessor(this IServiceCollection self)
        {
            if (self.Count(x => x.ServiceType == typeof(IHttpContextAccessor)) == 0)
                self.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            if (self.Count(x => x.ServiceType == typeof(IActionContextAccessor)) == 0)
                self.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            return self;
        }

    }
}
