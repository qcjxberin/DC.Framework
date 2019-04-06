using System;
using System.Threading.Tasks;
using Ding.Biz.OAuthLogin;
using Ding.Webs.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DCLGB.Apis
{
    /// <summary>
    /// 第三方登录
    /// </summary>
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OauthController : WebApiControllerBase
    {
        private readonly ILoginFactory loginFactory;

        public OauthController(ILoginFactory _loginFactory)
        {
            loginFactory = _loginFactory;
        }

        /// <summary>
        /// 登录回调处理
        /// </summary>
        /// <returns></returns>
        /// <param name="code">请求链接得到的code</param>
        /// <param name="state"></param>
        [HttpGet("Return_Url")]
        public async Task<IActionResult> ReturnUrl(string code, string state)
        {
            if (HttpContext.Session.GetString("oauth_state").IsNullOrEmpty() || HttpContext.Session.GetString("login_type").IsNullOrEmpty())
            {
                return Fail("出错了，无法获取Session信息！");
            }

            if (state != HttpContext.Session.GetString("oauth_state"))  // 对比返回参数
            {
                return Fail("出错了，state未初始化！");
            }

            var login_type = HttpContext.Session.GetInt32("login_type");
            switch ((LoginBase.LoginType)login_type)
            {
                case LoginBase.LoginType.QQ:

                    break;
            }

            return Redirect(SiteSetting.Current.Url);
        }

        /// <summary>
        /// QQ登录
        /// </summary>
        /// <returns></returns>
        [HttpGet("qq_connect")]
        public async Task<IActionResult> QQConnect()
        {
            var request = new QQ_Authorization_RequestEntity();
            HttpContext.Session.SetString("oauth_state", request.state); //防止CSRF攻击
            HttpContext.Session.SetInt32("login_type", (int)LoginBase.LoginType.QQ);
            return Redirect(await loginFactory.AuthorizationHref(request));
        }

        /// <summary>
        /// 生成请求链接
        /// </summary>
        /// <returns></returns>
        private async Task<string> Auth(LoginBase.LoginType loginType)
        {
            var url = string.Empty;

            switch (loginType)
            {
                //case LoginBase.LoginType.WeiBo:
                //    url = Weibo.AuthorizeHref(new Weibo_Authorize_RequestEntity());
                //    break;
                //case LoginBase.LoginType.WeChat:
                //    url = WeChat.AuthorizationHref(new WeChat_Authorization_RequestEntity());
                //    break;
                //case LoginBase.LoginType.GitHub:
                //    url = GitHub.AuthorizeHref(new GitHub_Authorize_RequestEntity());
                //    break;
                //case LoginBase.LoginType.TaoBao:
                //    url = Taobao.AuthorizeHref(new Taobao_Authorize_RequestEntity());
                //    break;
                //case LoginBase.LoginType.MicroSoft:
                //    url = MicroSoft.AuthorizeHref(new MicroSoft_Authorize_RequestEntity());
                //    break;
                default:
                    break;
            }

            return url;
        }

        /// <summary>
        /// 回调方法
        /// </summary>
        /// <param name="code">请求链接得到的code</param>
        /// <param name="loginType">登录类型</param>
        private async void AuthCallback(string code, LoginBase.LoginType loginType)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                //打开链接没登录授权
            }
            else
            {
                //唯一标示
                string openId = string.Empty;

                switch (loginType)
                {
                    case LoginBase.LoginType.QQ:
                        {
                            //获取 access_token
                            var tokenEntity = await loginFactory.AccessToken(new QQ_AccessToken_RequestEntity()
                            {
                                code = code
                            });

                            //获取 OpendId
                            var openidEntity = await loginFactory.OpenId(new QQ_OpenId_RequestEntity()
                            {
                                access_token = tokenEntity.access_token
                            });

                            //获取 UserInfo
                            var userEntity = await loginFactory.OpenId_Get_User_Info(new QQ_OpenAPI_RequestEntity()
                            {
                                access_token = tokenEntity.access_token,
                                openid = openidEntity.openid
                            });

                            //身份唯一标识
                            openId = openidEntity.openid;
                        }
                        break;
                        //case LoginBase.LoginType.WeiBo:
                        //    {
                        //        //获取 access_token
                        //        var tokenEntity = Weibo.AccessToken(new Weibo_AccessToken_RequestEntity()
                        //        {
                        //            code = code
                        //        });

                        //        //获取 access_token 的授权信息
                        //        var tokenInfoEntity = Weibo.GetTokenInfo(new Weibo_GetTokenInfo_RequestEntity()
                        //        {
                        //            access_token = tokenEntity.access_token
                        //        });

                        //        //获取 users/show
                        //        var userEntity = Weibo.UserShow(new Weibo_UserShow_RequestEntity()
                        //        {
                        //            access_token = tokenEntity.access_token,
                        //            uid = Convert.ToInt64(tokenInfoEntity.uid)
                        //        });

                        //        openId = tokenEntity.access_token;
                        //    }
                        //    break;
                        //case LoginBase.LoginType.WeChat:
                        //    {
                        //        //获取 access_token
                        //        var tokenEntity = WeChat.AccessToken(new WeChat_AccessToken_RequestEntity()
                        //        {
                        //            code = code
                        //        });

                        //        //获取 user
                        //        var userEntity = WeChat.Get_User_Info(new WeChat_OpenAPI_RequestEntity()
                        //        {
                        //            access_token = tokenEntity.access_token,
                        //            openid = tokenEntity.openid
                        //        });

                        //        //身份唯一标识
                        //        openId = tokenEntity.openid;
                        //    }
                        //    break;
                        //case LoginBase.LoginType.GitHub:
                        //    {
                        //        //申请的应用名称，非常重要
                        //        GitHubConfig.ApplicationName = "netnrf";

                        //        //获取 access_token
                        //        var tokenEntity = GitHub.AccessToken(new GitHub_AccessToken_RequestEntity()
                        //        {
                        //            code = code
                        //        });

                        //        //获取 user
                        //        var userEntity = GitHub.User(new GitHub_User_RequestEntity()
                        //        {
                        //            access_token = tokenEntity.access_token
                        //        });

                        //        openId = userEntity.id.ToString();
                        //    }
                        //    break;
                        //case LoginBase.LoginType.TaoBao:
                        //    {
                        //        //获取 access_token
                        //        var tokenEntity = Taobao.AccessToken(new Taobao_AccessToken_RequestEntity()
                        //        {
                        //            code = code
                        //        });

                        //        openId = tokenEntity.open_uid;
                        //    }
                        //    break;
                        //case LoginBase.LoginType.MicroSoft:
                        //    {
                        //        //获取 access_token
                        //        var tokenEntity = MicroSoft.AccessToken(new MicroSoft_AccessToken_RequestEntity()
                        //        {
                        //            code = code
                        //        });

                        //        //获取 user
                        //        var userEntity = MicroSoft.User(new MicroSoft_User_RequestEntity()
                        //        {
                        //            access_token = tokenEntity.access_token
                        //        });

                        //        openId = userEntity.id.ToString();
                        //    }
                        //    break;
                }

                //拿到登录标识
                if (string.IsNullOrWhiteSpace(openId))
                {
                    //TO DO
                }
            }
        }
    }
}
