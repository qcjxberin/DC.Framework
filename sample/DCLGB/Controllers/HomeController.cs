using DCLGB.SignalR;
using Ding.Helpers;
using Ding.MailKit;
using Ding.MailKit.Configs;
using Ding.Maps;
using Ding.Net.Mail.Configs;
using Ding.Net.Mail.Core;
using Ding.Sms;
using Ding.Webs.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DCLGB.Controllers
{
    public class HomeController : WebControllerBase
    {
        private readonly ISignalRChatService signalRChatService;

        public HomeController(ISignalRChatService _signalRChatService)
        {
            signalRChatService = _signalRChatService;
        }

        public async Task<IActionResult> Index()
        {
            //var ApplicationLifetime = Ioc.Create<IApplicationLifetime>();
            //ApplicationLifetime.StopApplication();

            //await signalRChatService.SendMessageAsync("测试");
            //await SendHubs.Start("");

            // MailKit邮件发送器
            //var MailKitEmailSender = Ioc.Create<IMailKitEmailSender>();

            //var box = new EmailBox
            //{
            //    Subject = "测试邮件",
            //    To = new System.Collections.Generic.List<string> { "100538511@qq.com" },
            //    Body = "<p style='color:red'>测试内容</p>",
            //    IsBodyHtml = true
            //};

            //await MailKitEmailSender.SendAsync(box);

            //var sms = Ioc.Create<ISmsService>();
            //var body = new StringBuilder(SiteSetting.Current.Messages.SmsWebcomeBody);
            //body.Replace("{shopname}", SiteSetting.Current.WebConfig.webname);
            //body.Replace("{regtime}", DateTime.Now.ToString());
            //await sms.SendAsync("18307555593", $"[{SiteSetting.Current.Sms.passKey}]{body}");

            //var BspLoginfaillogsService = Ioc.Create<IBspLoginfaillogsService>();

            //var model = new BspLoginfaillogsDto
            //{
            //    Loginip = 245079650,
            //    Failtimes = 1,
            //    Lastlogintime = DateTime.Now
            //};

            //var id = await BspLoginfaillogsService.CreateAsync(model);

            //Console.WriteLine((await BspLoginfaillogsService.GetAllAsync()).Count + "   " + id);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
