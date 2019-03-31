using DCLGB.SignalR;
using Ding.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DCLGB.Controllers
{
    public class HomeController : Controller
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
            await signalRChatService.SendMessageAsync("测试");
            await SendHubs.Start("");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
