using Ding.Helpers;
using Ding.TimedJob.Schema;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Threading.Tasks;

namespace DCLGB.Jobs
{
    public class TimedJob : Job
    {
        [Invoke(Interval = 1000 * 3600, SkipWhileExecuting = true, IsEnabled = true)]
        public async Task TimedTest()
        {
            Console.WriteLine("测试TimedJob工具");
            //var ApplicationLifetime = Ioc.Create<IApplicationLifetime>();
            //ApplicationLifetime.StopApplication();
            await Task.FromResult(0);
        }
    }
}
