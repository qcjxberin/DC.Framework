using Ding.Localization;
using Ding.Localization.Filters;
using Ding.Localization.Listeners;
using Ding.Webs.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDingLocalization(this IServiceCollection self, Action<MemoryCultureSet> InitCultureSource = null)
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
            self.AddScoped<IEntityStateListener, LocalizationEntityStateListener>();
            self.Configure<MvcOptions>(x => x.Filters.Add(typeof(DbContextModelBindingFilter)));
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

    }
}
