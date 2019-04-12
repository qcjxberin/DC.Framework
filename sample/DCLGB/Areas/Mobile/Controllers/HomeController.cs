using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DCLGB.Auth;
using Ding.Webs.Controllers;
using Microsoft.AspNetCore.Authentication;
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

        [Route("Mobile/Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(H5AuthorizeAttribute.H5AuthenticationScheme);
            return RedirectToAction("Index", "Home", new { area = "Mobile" });
        }

        [Route("Mobile/QuanYi")]
        [H5Authorize]
        public async Task<IActionResult> QuanYi()
        {
            //return Content(Sid + "_" + User.Identities.First(u => u.IsAuthenticated).FindFirst(ClaimTypes.Sid).Value);
            return await Task.Run(() => View());
        }

    }
}
