using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DC.Samples.Models;
using Ding.Helpers;
using Microsoft.Extensions.Configuration;
using DC.Samples.Service;
using Ding.Log;
using DC.Samples.Common;

namespace DC.Samples.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var s = Ioc.Create<IConfiguration>();
            var s1 = Ioc.Create<ITest>();
            XTrace.UseConsole();
            XTrace.WriteLine(AdScope.GetCount().ToString());
            return Content(s["AllowedHosts"] + " " + s1.TT());
            return View();
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
