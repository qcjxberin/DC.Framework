using DCLGB.Auth;
using Ding.Biz.OAuthLogin;
using Ding.Webs.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using System.Threading.Tasks;

namespace DCLGB.Areas.Mobile.Controllers
{
    [Area("Mobile")]
    public class LoginController : WebControllerBase
    {
        public LoginController()
        {
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="returnUrl">用户尝试进入的需要登录的页面</param>
        /// <returns></returns>
        public async Task<IActionResult> Index(string returnUrl)
        {
            var auth = await HttpContext.AuthenticateAsync(H5AuthorizeAttribute.H5AuthenticationScheme);
            if (auth.Succeeded)
            {
                return RedirectToAction("Index", "Home", new { area = "Mobile" });
            }

            var useragent = HttpContext.Request.Headers["User-Agent"];
            if (useragent.ToString().Contains("MicroMessenger"))
            {
                var request = new WeChat_Authorization_RequestEntity();
                HttpContext.Session.SetString("oauth_state", request.state); //防止CSRF攻击
                HttpContext.Session.SetInt32("login_type", (int)LoginBase.LoginType.WeChat);

                var url = OAuthApi.GetAuthorizeUrl(Config.SenparcWeixinSetting.WeixinAppId, SiteSetting.Current.Login.WeChat.Redirect_Uri + "?returnUrl=" + returnUrl, request.state, OAuthScope.snsapi_userinfo);
                return Redirect(url);
            }
            else
            {
                ViewData["ReturnUrl"] = returnUrl;
                return View();
            }
        }
    }
}
