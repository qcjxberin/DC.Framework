using System;
using System.Threading.Tasks;
using Ding.Dependency;

namespace Ding.Samples.Schedulers.Services {
    /// <summary>
    /// 测试服务1 - 通过自动扫描IScopeDependency注册
    /// </summary>
    public interface ITestService1 : IDisposable, IScopeDependency {
        Task HelloAsync();
    }
}
