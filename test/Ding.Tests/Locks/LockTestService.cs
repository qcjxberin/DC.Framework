using System;
using EasyCaching.InMemory;
using Microsoft.Extensions.DependencyInjection;
using Ding.Caches;
using Ding.Caches.EasyCaching;
using Ding.Locks.Default;

namespace Ding.Tests.Locks {
    /// <summary>
    /// 业务锁测试服务
    /// </summary>
    public class LockTestService {
        /// <summary>
        /// 缓存
        /// </summary>
        private static readonly ICache Cache;
        /// <summary>
        /// 业务锁
        /// </summary>
        private readonly DefaultLock _lock;

        /// <summary>
        /// 初始化业务锁测试服务
        /// </summary>
        static LockTestService() {
            var services = new ServiceCollection();
            services.AddCache( options => options.UseInMemory() );
            var serviceProvider = services.BuildServiceProvider();
            Cache = serviceProvider.GetService<ICache>();
        }

        /// <summary>
        /// 初始化业务锁测试服务
        /// </summary>
        public LockTestService() {
            _lock = new DefaultLock( Cache );
        }

        /// <summary>
        /// 执行
        /// </summary>
        public string Execute( string key, TimeSpan? expiration = null ) {
            var result = _lock.Lock( key, expiration );
            return result ? "ok" : "fail";
        }

        /// <summary>
        /// 解锁
        /// </summary>
        public void UnLock() {
            _lock.UnLock();
        }
    }
}
