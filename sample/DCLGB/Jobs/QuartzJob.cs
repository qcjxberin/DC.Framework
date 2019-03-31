using System;
using System.Threading.Tasks;
using Ding.Dependency;
using Ding.Schedulers.Quartz;
using Quartz;

namespace DCLGB.Jobs
{
    public class QuartzJob : JobBase
    {
        /// <summary>
        /// 获取重复执行间隔时间，单位：分钟
        /// </summary>
        public override int? GetIntervalInMinutes()
        {
            return 1;
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <remarks>请使用 scope 参数创建实例，不要使用 Ioc.Create 方法，可能导致生命周期错误</remarks>
        protected override async Task Execute(IJobExecutionContext context, IScope scope)
        {
            Console.WriteLine("测试定时调度功能");
            await Task.FromResult(0);
        }
    }
}
