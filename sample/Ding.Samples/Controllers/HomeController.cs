using Ding.Captcha;
using Ding.Samples.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ding.Samples.Controllers
{
    public class HomeController : Controller
    {
        private SecurityCodeHelper _securityCode = new SecurityCodeHelper();

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 泡泡中文验证码 
        /// </summary>
        /// <returns></returns>
        public IActionResult BubbleCode()
        {
            var code = _securityCode.GetRandomCnText(2);
            var imgbyte = _securityCode.GetBubbleCodeByte(code);

            return File(imgbyte, "image/png");
        }

        /// <summary>
        /// 数字字母组合验证码
        /// </summary>
        /// <returns></returns>
        public IActionResult HybridCode()
        {
            var code = _securityCode.GetRandomEnDigitalText(4);
            var imgbyte = _securityCode.GetEnDigitalCodeByte(code);

            return File(imgbyte, "image/png");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
