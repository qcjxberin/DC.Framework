using Ding.TimedJob.Jobs;
using Ding.TimedJob.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class TimedJobExtensions
    {
        public static IServiceCollection AddTimedJob(this IServiceCollection self)
        {
            return self.AddSingleton<IAssemblyLocator, DefaultAssemblyLocator>()
                .AddSingleton<TimedJobService>();
        }
    }
}

namespace Microsoft.AspNetCore.Builder
{
    public static class TimedJobExtensions
    {
        public static IApplicationBuilder UseTimedJob(this IApplicationBuilder self)
        {
            self.ApplicationServices.GetRequiredService<TimedJobService>();
            return self;
        }
    }
}