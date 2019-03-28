using System;
using System.Threading.Tasks;

namespace Ding.Samples.Schedulers.Services {
    /// <summary>
    /// 测试服务2 - 通过在ServiceRegister手工注册
    /// </summary>
    public interface ITestService2 : IDisposable {
        Task WorldAsync();
    }
}
