using Ding.Helpers;
using Ding.MailKit;
using Ding.Net.Mail.Core;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DCLGB.Common
{
    public class EmailsService : IEmailsService
    {
        /// <summary>
        /// 发送找回密码邮件
        /// </summary>
        /// <param name="to">接收邮箱</param>
        /// <param name="userName">接收人</param>
        /// <param name="url">url</param>
        public async Task<bool> SendFindPwdEmail(string to, string userName, string url)
        {
            //标题
            string subject = SiteSetting.Current.WebConfig.webname + "找回密码邮件";

            StringBuilder body = new StringBuilder(SiteSetting.Current.Messages.FindPwdBody);
            body.Replace("{shopname}", SiteSetting.Current.WebConfig.webname);
            body.Replace("{siteurl}", SiteSetting.Current.WebConfig.weburl.Replace("http://", ""));
            body.Replace("{username}", userName);
            body.Replace("{deadline}", DateTime.Now.AddMinutes(30).ToString("yyyy-MM-dd HH:mm"));
            body.Replace("{url}", url);

            return await Send(to, subject, body.ToString());
        }

        /// <summary>
        /// 发送注册时验证码
        /// </summary>
        /// <param name="to"></param>
        /// <param name="code">验证码</param>
        /// <returns></returns>
        public async Task<bool> SendRegisterCode(string to, string code)
        {
            //标题
            string subject = SiteSetting.Current.WebConfig.webname + "-会员注册";
            var body = $"您的邮箱验证码为{code}，谢谢您的使用~";
            return await Send(to, subject, body);
        }

        /// <summary>
        /// 发送注册欢迎邮件
        /// </summary>
        /// <param name="to">接收邮箱</param>
        /// <returns></returns>
        public async Task<bool> SendWebcomeEmail(string to)
        {
            string subject = string.Format("恭喜您成功注册为" + "{0}" + "会员", SiteSetting.Current.WebConfig.webname);

            StringBuilder body = new StringBuilder(SiteSetting.Current.Messages.MailWebcomeBody);
            body.Replace("{shopname}", SiteSetting.Current.WebConfig.webname);
            body.Replace("{regtime}", DateTime.Now.ToString());
            body.Replace("{email}", to);

            return await Send(to, subject, body.ToString());
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="to">接收邮件</param>
        /// <param name="subject">邮件标题</param>
        /// <param name="body">邮件内容</param>
        /// <returns>是否发送成功</returns>
        public async Task<bool> Send(string to, string subject, string body)
        {
            try
            {
                // MailKit邮件发送器
                var MailKitEmailSender = Ioc.Create<IMailKitEmailSender>();

                var box = new EmailBox
                {
                    Subject = subject,
                    To = new System.Collections.Generic.List<string> { to },
                    Body = body,
                    IsBodyHtml = true
                };

                await MailKitEmailSender.SendAsync(box);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
