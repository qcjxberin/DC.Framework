using System.Threading.Tasks;
using Ding.Dependency;

namespace Ding.Sms {
    /// <summary>
    /// 短信服务
    /// </summary>
    public interface ISmsService : IScopeDependency
    {
        /// <summary>
        /// 发送短信，阿里云不适用此方法
        /// </summary>
        /// <param name="mobile">手机号,可批量，用逗号分隔开，上限为1000个</param>
        /// <param name="content">内容</param>
        Task<SmsResult> SendAsync(string mobile, string content);

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobile">手机号,可批量，用逗号分隔开，上限为1000个</param>
        /// <param name="templatecode">短信模板-可在短信控制台中找到</param>
        /// <param name="templateparam">模板中的变量替换JSON串</param>
        /// <param name="outid">为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者</param>
        Task<SmsResult> SendAsync(string mobile, string templatecode, string templateparam,
            string outid);
    }
}
