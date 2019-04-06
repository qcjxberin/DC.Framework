using System.Threading.Tasks;
using Ding.Webs.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DCLGB.Areas.Mobile.Controllers
{
    [Area("Mobile")]
    public class HomeController : WebControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Mobile/QuanYi")]
        [Authorize("Permission")]
        public async Task<IActionResult> QuanYi()
        {
            return await Task.Run(() => View());
        }

    }
}
