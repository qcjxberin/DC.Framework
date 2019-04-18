using System.Threading.Tasks;

namespace DCLGB.Common
{
    public interface IEmailsService
    {
        /// <summary>
        /// 发送注册欢迎邮件
        /// </summary>
        /// <param name="to">接收邮箱</param>
        /// <returns></returns>
        Task<bool> SendWebcomeEmail(string to);

        /// <summary>
        /// 发送找回密码邮件
        /// </summary>
        /// <param name="to">接收邮箱</param>
        /// <param name="userName">接收人</param>
        /// <param name="url">url</param>
        Task<bool> SendFindPwdEmail(string to, string userName, string url);

        /// <summary>
        /// 发送注册验证码信息
        /// </summary>
        /// <param name="to">接收邮箱</param>
        /// <param name="code">验证码</param>
        /// <returns></returns>
        Task<bool> SendRegisterCode(string to, string code);
    }
}
