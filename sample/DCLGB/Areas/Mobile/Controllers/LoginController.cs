using System.Threading.Tasks;
using Ding.Webs.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DCLGB.Areas.Mobile.Controllers
{
    [Area("Mobile")]
    public class LoginController : WebControllerBase
    {
        [Route("Mobile/Login")]
        public async Task<IActionResult> Index()
        {

            return Content("123456");
        }
    }
}
