using System;
using System.Threading.Tasks;
using Quartz;
using Ding.Dependency;
using Ding.Samples.Schedulers.Services;
using Ding.Schedulers.Quartz;

namespace Ding.Samples.Schedulers.Jobs {
    /// <summary>
    /// 测试作业2
    /// </summary>
    public class TestJob2 : JobBase {
        /// <summary>
        /// 执行
        /// </summary>
        protected override async Task Execute( IJobExecutionContext context, IScope scope ) {
            try {
                var service = scope.Create<ITestService2>();
                await service.WorldAsync();
            }
            catch( Exception ex ) {
                Console.WriteLine( ex );
            }
        }

        /// <summary>
        /// 获取重复执行间隔时间，单位：秒
        /// </summary>
        public override int? GetIntervalInSeconds() {
            return 5;
        }
    }
}
