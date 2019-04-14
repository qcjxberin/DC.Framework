using Ding.Logs;
using Ding.Sessions;

namespace Ding.Applications {
    /// <summary>
    /// 应用服务
    /// </summary>
    public abstract class ServiceBase : IService {
        /// <summary>
        /// 日志
        /// </summary>
        private ILog _log;

        /// <summary>
        /// 日志
        /// </summary>
        public ILog Log => _log ?? (_log = GetLog() );

        /// <summary>
        /// 获取日志操作
        /// </summary>
        protected virtual ILog GetLog() {
            try {
                return Ding.Logs.Log.GetLog( this );
            }
            catch {
                return Ding.Logs.Log.Null;
            }
        }

        /// <summary>
        /// 用户会话
        /// </summary>
        public virtual ISession Session => Ding.Security.Sessions.Session.Instance;
    }
}
