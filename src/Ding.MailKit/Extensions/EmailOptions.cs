using Ding.MailKit.Configs;
using Ding.Net.Mail.Configs;

namespace Ding.MailKit.Extensions
{
    /// <summary>
    /// 邮件配置
    /// </summary>
    public class EmailOptions
    {
        /// <summary>
        /// 电子邮件配置
        /// </summary>
        public EmailConfig EmailConfig { get; set; } = new EmailConfig();

        /// <summary>
        /// MailKit 配置
        /// </summary>
        public MailKitConfig MailKitConfig { get; set; } = new MailKitConfig();
    }
}
