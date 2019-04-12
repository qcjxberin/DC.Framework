using System;
using System.Text;
using System.Threading.Tasks;
using DCLGB.Common;
using Ding.Biz.OAuthLogin;
using Ding.Helpers;
using Ding.Log;
using Ding.Sms;
using Ding.Utils.Helpers;
using Ding.Utils.Webs;
using Ding.Webs.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.Containers;

namespace DCLGB.Controllers
{
    /// <summary>
    /// 第三方登录
    /// </summary>
    public class OauthController : WebControllerBase
    {
        //private readonly ILoginFactory loginFactory;

        //private readonly IBspOauthService BspOauthService;

        //private readonly IBspUsersService BspUsersService;

        //public OauthController(ILoginFactory _loginFactory, IBspOauthService _bspOauthService, IBspUsersService bspUsersService)
        //{
        //    loginFactory = _loginFactory;
        //    BspOauthService = _bspOauthService;
        //    BspUsersService = bspUsersService;
        //}

        ///// <summary>
        ///// 登录回调处理
        ///// </summary>
        ///// <returns></returns>
        ///// <param name="code">请求链接得到的code</param>
        ///// <param name="state">返回的状态数据</param>
        ///// <param name="returnUrl">用户尝试进入的需要登录的页面</param>
        //[HttpGet("Oauth/Return_Url")]
        //public async Task<IActionResult> ReturnUrl(string returnUrl, string code, string state)
        //{
        //    if (HttpContext.Session.GetString("oauth_state").IsNullOrEmpty() || HttpContext.Session.GetString("login_type").IsNullOrEmpty())
        //    {
        //        return Fail("出错了，无法获取Session信息！");
        //    }

        //    if (state != HttpContext.Session.GetString("oauth_state"))  // 对比返回参数
        //    {
        //        return Fail("出错了，state未初始化！");
        //    }

        //    var login_type = HttpContext.Session.GetInt32("login_type");
        //    switch ((LoginBase.LoginType)login_type)
        //    {
        //        case LoginBase.LoginType.QQ:
        //            await AuthCallback(code, LoginBase.LoginType.QQ);
        //            break;

        //        case LoginBase.LoginType.WeChat:
        //            await AuthCallback(code, LoginBase.LoginType.WeChat);
        //            break;
        //    }

        //    if (!returnUrl.IsNullOrEmpty())
        //    {
        //        return Redirect(returnUrl);
        //    }

        //    if (HttpContext.Request.IsMobileBrowser())
        //    {
        //        return Redirect(SiteSetting.Current.Url + "/Mobile/");
        //    }
        //    return Redirect(SiteSetting.Current.Url);
        //}

        ///// <summary>
        ///// 生成请求链接
        ///// </summary>
        ///// <param name="loginType">第三方平台类型</param>
        ///// <param name="returnUrl">用户尝试进入的需要登录的页面</param>
        ///// <returns></returns>
        //public async Task<IActionResult> Auth(string returnUrl, int loginType = 0)
        //{
        //    switch ((LoginBase.LoginType)loginType)
        //    {
        //        default:
        //        case LoginBase.LoginType.QQ:
        //            var request = new QQ_Authorization_RequestEntity();
        //            HttpContext.Session.SetString("oauth_state", request.state); //防止CSRF攻击
        //            HttpContext.Session.SetInt32("login_type", (int)LoginBase.LoginType.QQ);
        //            return Redirect(await loginFactory.AuthorizationHref(request) + "?returnUrl=".UrlEncode() + returnUrl);
        //        //case LoginBase.LoginType.WeiBo:
        //        //    url = Weibo.AuthorizeHref(new Weibo_Authorize_RequestEntity());
        //        //    break;
        //        //case LoginBase.LoginType.WeChat:
        //        //    url = WeChat.AuthorizationHref(new WeChat_Authorization_RequestEntity());
        //        //    break;
        //        //case LoginBase.LoginType.GitHub:
        //        //    url = GitHub.AuthorizeHref(new GitHub_Authorize_RequestEntity());
        //        //    break;
        //        //case LoginBase.LoginType.TaoBao:
        //        //    url = Taobao.AuthorizeHref(new Taobao_Authorize_RequestEntity());
        //        //    break;
        //        //case LoginBase.LoginType.MicroSoft:
        //        //    url = MicroSoft.AuthorizeHref(new MicroSoft_Authorize_RequestEntity());
        //        //    break;
        //    }
        //}

        ///// <summary>
        ///// 回调方法
        ///// </summary>
        ///// <param name="code">请求链接得到的code</param>
        ///// <param name="loginType">登录类型</param>
        //private async Task<IActionResult> AuthCallback(string code, LoginBase.LoginType loginType)
        //{
        //    if (string.IsNullOrWhiteSpace(code))
        //    {
        //        return RedirectToAction("Index", "Login", new { area = "Mobile" });
        //    }
        //    else
        //    {
        //        BspUsersDto UserInfo;

        //        //唯一标示
        //        string openId = string.Empty;

        //        switch (loginType)
        //        {
        //            case LoginBase.LoginType.QQ:
        //                {
        //                    //获取 access_token
        //                    var tokenEntity = await loginFactory.AccessToken(new QQ_AccessToken_RequestEntity()
        //                    {
        //                        code = code
        //                    });

        //                    //获取 OpendId
        //                    var openidEntity = await loginFactory.OpenId(new QQ_OpenId_RequestEntity()
        //                    {
        //                        access_token = tokenEntity.access_token
        //                    });

        //                    //身份唯一标识
        //                    openId = openidEntity.openid;

        //                    // 判断此用户是否已经存在
        //                    if (openId.IsNullOrEmpty())
        //                    {
        //                        return RedirectToAction("Index", "Login", new { area = "Mobile" });
        //                    }

        //                    var uid = await BspOauthService.GetUidByOpenIdAndServer(openId, SiteSetting.Current.Login.QQ.Server);

        //                    if (uid > 0)
        //                    {
        //                        async Task<BspUsersDto> func(int c)
        //                        {
        //                            UserInfo = await BspUsersService.GetUserByIdAsync(c);
        //                            if (UserInfo != null)
        //                            {
        //                                if (UserInfo.Nickname.IsNullOrEmpty() || UserInfo.Avatar.IsNullOrEmpty())
        //                                {
        //                                    //获取 UserInfo
        //                                    var userEntity = await loginFactory.OpenId_Get_User_Info(new QQ_OpenAPI_RequestEntity()
        //                                    {
        //                                        access_token = tokenEntity.access_token,
        //                                        openid = openId
        //                                    });
        //                                    await BspUsersService.UpdateAvaterAndNickName(uid, userEntity.nickname, userEntity.figureurl_qq_1, userEntity.gender == "男" ? (byte)1 : (byte)2);
        //                                }
        //                            }
        //                            return UserInfo;
        //                        }

        //                        await OauthLogin(func, uid, openId, SiteSetting.Current.Login.QQ.Server);
        //                    }
        //                    else
        //                    {
        //                        async Task<BspUsersDto> func(int c)
        //                        {
        //                            //获取 UserInfo
        //                            var userEntity = await loginFactory.OpenId_Get_User_Info(new QQ_OpenAPI_RequestEntity()
        //                            {
        //                                access_token = tokenEntity.access_token,
        //                                openid = openId
        //                            });
        //                            return await BspUsersService.Register(userEntity.nickname, userEntity.figureurl_qq_1, userEntity.gender == "男" ? (byte)1 : (byte)2, LoginBase.LoginType.QQ);
        //                        }

        //                        await OauthLogin(func, uid, openId, SiteSetting.Current.Login.QQ.Server);
        //                    }
        //                }
        //                break;
        //            //case LoginBase.LoginType.WeiBo:
        //            //    {
        //            //        //获取 access_token
        //            //        var tokenEntity = Weibo.AccessToken(new Weibo_AccessToken_RequestEntity()
        //            //        {
        //            //            code = code
        //            //        });

        //            //        //获取 access_token 的授权信息
        //            //        var tokenInfoEntity = Weibo.GetTokenInfo(new Weibo_GetTokenInfo_RequestEntity()
        //            //        {
        //            //            access_token = tokenEntity.access_token
        //            //        });

        //            //        //获取 users/show
        //            //        var userEntity = Weibo.UserShow(new Weibo_UserShow_RequestEntity()
        //            //        {
        //            //            access_token = tokenEntity.access_token,
        //            //            uid = Convert.ToInt64(tokenInfoEntity.uid)
        //            //        });

        //            //        openId = tokenEntity.access_token;
        //            //    }
        //            //    break;
        //            //case LoginBase.LoginType.WeChat:
        //            //    {
        //            //        //获取 access_token
        //            //        var tokenEntity = WeChat.AccessToken(new WeChat_AccessToken_RequestEntity()
        //            //        {
        //            //            code = code
        //            //        });

        //            //        //获取 user
        //            //        var userEntity = WeChat.Get_User_Info(new WeChat_OpenAPI_RequestEntity()
        //            //        {
        //            //            access_token = tokenEntity.access_token,
        //            //            openid = tokenEntity.openid
        //            //        });

        //            //        //身份唯一标识
        //            //        openId = tokenEntity.openid;
        //            //    }
        //            //    break;

        //            case LoginBase.LoginType.WeChat:
        //                {
        //                    var useragent = HttpContext.Request.Headers["User-Agent"];
        //                    if (useragent.ToString().Contains("MicroMessenger"))
        //                    {
        //                        var Access_Token = "";
        //                        var result = await OAuthApi.GetAccessTokenAsync(Config.SenparcWeixinSetting.WeixinAppId, Config.SenparcWeixinSetting.WeixinAppSecret, code);

        //                        if (result.errcode == ReturnCode.请求成功)
        //                        {
        //                            Access_Token = result.access_token;
        //                            openId = result.openid;
        //                        }

        //                        // 判断此用户是否已经存在
        //                        if (openId.IsNullOrEmpty())
        //                        {
        //                            return RedirectToAction("Index", "Login", new { area = "Mobile" });
        //                        }

        //                        if (Access_Token.IsNullOrEmpty())
        //                        {
        //                            Access_Token = await AccessTokenContainer.TryGetAccessTokenAsync(Config.SenparcWeixinSetting.WeixinAppId, Config.SenparcWeixinSetting.WeixinAppSecret);
        //                        }

        //                        var uid = await BspOauthService.GetUidByOpenIdAndServer(openId, SiteSetting.Current.Login.WeChat.Server);
        //                        if (uid > 0)
        //                        {
        //                            async Task<BspUsersDto> func(int c)
        //                            {
        //                                UserInfo = await BspUsersService.GetUserByIdAsync(c);
        //                                if (UserInfo != null)
        //                                {
        //                                    if (UserInfo.Nickname.IsNullOrEmpty() || UserInfo.Avatar.IsNullOrEmpty())
        //                                    {
        //                                        var resultuser = await OAuthApi.GetUserInfoAsync(Access_Token, openId);
        //                                        await BspUsersService.UpdateAvaterAndNickName(uid, resultuser.nickname, resultuser.headimgurl, (byte)resultuser.sex);
        //                                    }
        //                                }
        //                                return UserInfo;
        //                            }

        //                            await OauthLogin(func, uid, openId, SiteSetting.Current.Login.WeChat.Server);
        //                        }
        //                        else
        //                        {
        //                            async Task<BspUsersDto> func (int c)
        //                            {
        //                                var resultuser = await OAuthApi.GetUserInfoAsync(Access_Token, openId);
        //                                return await BspUsersService.Register(resultuser.nickname, resultuser.headimgurl, (byte)resultuser.sex, LoginBase.LoginType.WeChat);
        //                            }

        //                            await OauthLogin(func, uid, openId, SiteSetting.Current.Login.WeChat.Server);
        //                        }
        //                    }
        //                }
        //                break;

        //                //case LoginBase.LoginType.GitHub:
        //                //    {
        //                //        //申请的应用名称，非常重要
        //                //        GitHubConfig.ApplicationName = "netnrf";

        //                //        //获取 access_token
        //                //        var tokenEntity = GitHub.AccessToken(new GitHub_AccessToken_RequestEntity()
        //                //        {
        //                //            code = code
        //                //        });

        //                //        //获取 user
        //                //        var userEntity = GitHub.User(new GitHub_User_RequestEntity()
        //                //        {
        //                //            access_token = tokenEntity.access_token
        //                //        });

        //                //        openId = userEntity.id.ToString();
        //                //    }
        //                //    break;
        //                //case LoginBase.LoginType.TaoBao:
        //                //    {
        //                //        //获取 access_token
        //                //        var tokenEntity = Taobao.AccessToken(new Taobao_AccessToken_RequestEntity()
        //                //        {
        //                //            code = code
        //                //        });

        //                //        openId = tokenEntity.open_uid;
        //                //    }
        //                //    break;
        //                //case LoginBase.LoginType.MicroSoft:
        //                //    {
        //                //        //获取 access_token
        //                //        var tokenEntity = MicroSoft.AccessToken(new MicroSoft_AccessToken_RequestEntity()
        //                //        {
        //                //            code = code
        //                //        });

        //                //        //获取 user
        //                //        var userEntity = MicroSoft.User(new MicroSoft_User_RequestEntity()
        //                //        {
        //                //            access_token = tokenEntity.access_token
        //                //        });

        //                //        openId = userEntity.id.ToString();
        //                //    }
        //                //    break;
        //        }

        //        //拿到登录标识
        //        if (string.IsNullOrWhiteSpace(openId))
        //        {
                    

        //            //TO DO
        //        }
        //    }
        //    return Ok();
        //}

        //private async Task OauthLogin(Func<int, Task<BspUsersDto>> func, int uid, string openId, string Server)
        //{
        //    var BspCreditlogsService = Ioc.Create<IBspCreditlogsService>();
        //    var BspOrderproductsService = Ioc.Create<IBspOrderproductsService>();
        //    var BspUserranksService = Ioc.Create<IBspUserranksService>();
        //    var EmailsService = Ioc.Create<IEmailsService>();
        //    var SmsService = Ioc.Create<ISmsService>();

        //    BspUsersDto UserInfo = await func?.Invoke(uid);
        //    if (uid > 0)
        //    {
        //        if (UserInfo != null)
        //        {
        //            // 发放登陆积分
        //            UserInfo = await BspCreditlogsService.SendLoginCredits(UserInfo, DateTime.Now);
        //            // 更新购物车中用户id
        //            await BspOrderproductsService.UpdateCartUidBySid(uid, Sid);

        //            var GroupName = await BspUserranksService.GetGroupName(UserInfo.Userrid); //获取用户等级

        //            await BspUsersService.Login(uid.ToString(), GroupName, UserInfo.Avatar, UserInfo.Nickname, UserInfo.Username, openId, UserInfo.Userrid.ToString());
        //        }
        //    }
        //    else
        //    {
        //        if (UserInfo != null)
        //        {
        //            uid = UserInfo.Id.ToInt();
        //            await BspOauthService.CreateOrUpdateOAuthUser(new BspOauthDto { Uid = uid, Openid = openId, Server = Server });

        //            // 发放注册积分
        //            UserInfo = await BspCreditlogsService.SendRegisterCredits(UserInfo, DateTime.Now);
        //            // 更新购物车中用户id
        //            await BspOrderproductsService.UpdateCartUidBySid(uid, Sid);

        //            var GroupName = await BspUserranksService.GetGroupName(UserInfo.Userrid); //获取用户等级

        //            // 发送注册欢迎信息
        //            if (SiteSetting.Current.WebConfig.IsWebcomeMsg == 1)
        //            {
        //                if (!UserInfo.Email.IsNullOrEmpty())
        //                {
        //                    await EmailsService.SendWebcomeEmail(UserInfo.Email);  // 发送邮件
        //                }
        //                if (!UserInfo.Mobile.IsNullOrEmpty())
        //                {
        //                    var body = new StringBuilder(SiteSetting.Current.Messages.SmsWebcomeBody);
        //                    body.Replace("{shopname}", SiteSetting.Current.WebConfig.webname);
        //                    body.Replace("{regtime}", DateTime.Now.ToString());
        //                    var resultsend = await SmsService.SendAsync(UserInfo.Mobile, $"[{SiteSetting.Current.Sms.passKey}]{body}");
        //                    if (!resultsend.Success)
        //                    {
        //                        Log.Error($"短信发送失败：{UserInfo.Mobile}_{body}");
        //                    }
        //                }
        //            }

        //            await BspUsersService.Login(UserInfo.Id, GroupName, UserInfo.Avatar, UserInfo.Nickname, UserInfo.Username, openId, UserInfo.Userrid.ToString());
        //        }
        //    }
        //}
    }
}
