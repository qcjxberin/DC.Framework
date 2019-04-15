using Ding.Biz.OAuthLogin.GitHub.Configs;
using Ding.Biz.OAuthLogin.MicroSoft.Configs;
using Ding.Biz.OAuthLogin.QQ.Configs;
using Ding.Biz.OAuthLogin.Taobao.Configs;
using Ding.Biz.OAuthLogin.WeChat.Configs;
using Ding.Biz.OAuthLogin.Weibo.Configs;
using Ding.Helpers;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ding.Biz.OAuthLogin
{
    /// <summary>
    /// 登录工厂
    /// </summary>
    public class LoginFactory : ILoginFactory
    {
        /// <summary>
        /// QQ登录配置提供器
        /// </summary>
        protected readonly IQQConfigProvider _qqConfigProvider;

        /// <summary>
        /// 微信登录配置提供器
        /// </summary>
        protected readonly IWeChatConfigProvider _wechatConfigProvider;

        /// <summary>
        /// GitHub登录配置提供器
        /// </summary>
        protected readonly IGitHubConfigProvider _githubConfigProvider;

        /// <summary>
        /// MicroSoft登录配置提供器
        /// </summary>
        protected readonly IMicroSoftConfigProvider _microsoftConfigProvider;

        /// <summary>
        /// Taobao登录配置提供器
        /// </summary>
        protected readonly ITaobaoConfigProvider _taobaoConfigProvider;

        /// <summary>
        /// Weibo登录配置提供器
        /// </summary>
        protected readonly IWeiboConfigProvider _weibaoConfigProvider;

        public LoginFactory(IQQConfigProvider qqConfigProvider, IWeChatConfigProvider wechatConfigProvider, IGitHubConfigProvider githubConfigProvider, IMicroSoftConfigProvider microsoftConfigProvider, ITaobaoConfigProvider taobaoConfigProvider, IWeiboConfigProvider weibaoConfigProvider)
        {
            _qqConfigProvider = qqConfigProvider;
            _wechatConfigProvider = wechatConfigProvider;
            _githubConfigProvider = githubConfigProvider;
            _microsoftConfigProvider = microsoftConfigProvider;
            _taobaoConfigProvider = taobaoConfigProvider;
            _weibaoConfigProvider = weibaoConfigProvider;
        }

        #region QQ登录
        /// <summary>
        /// Step1：获取Authorization Code
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<string> AuthorizationHref(QQ_Authorization_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            var config = await _qqConfigProvider.GetConfigAsync();
            config.CheckNotNull(nameof(config));

            return string.Concat(new string[] {
                config.API_Authorization_PC,
                "?client_id=",
                entity.client_id,
                "&response_type=",
                entity.response_type,
                "&state=",
                entity.state,
                "&redirect_uri=",
                entity.redirect_uri.ToEncode()});
        }

        /// <summary>
        /// Step2：通过Authorization Code获取Access Token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<QQ_AccessToken_ResultEntity> AccessToken(QQ_AccessToken_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            string pars = LoginBase.EntityToPars(entity);

            var config = await _qqConfigProvider.GetConfigAsync();
            config.CheckNotNull(nameof(config));

            string result = HttpTo.Get(config.API_AccessToken_PC + "?" + pars);

            List<string> listPars = result.Split('&').ToList();
            var jo = new JObject();
            foreach (string item in listPars)
            {
                var items = item.Split('=').ToList();
                jo[items.FirstOrDefault()] = items.LastOrDefault();
            }

            var outmo = LoginBase.ResultOutput<QQ_AccessToken_ResultEntity>(Newtonsoft.Json.JsonConvert.SerializeObject(jo));

            return outmo;
        }

        /// <summary>
        /// Step3：获取用户OpenId
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<QQ_OpenId_ResultEntity> OpenId(QQ_OpenId_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            var config = await _qqConfigProvider.GetConfigAsync();
            config.CheckNotNull(nameof(config));

            string pars = LoginBase.EntityToPars(entity);
            string result = HttpTo.Get(config.API_OpenID_PC + "?" + pars);
            result = result.Replace("callback( ", "").Replace(" );", "");

            var outmo = LoginBase.ResultOutput<QQ_OpenId_ResultEntity>(result);

            return outmo;
        }

        /// <summary>
        /// Step4：获取用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<QQ_OpenId_get_user_info_ResultEntity> OpenId_Get_User_Info(QQ_OpenAPI_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            var config = await _qqConfigProvider.GetConfigAsync();
            config.CheckNotNull(nameof(config));

            string pars = LoginBase.EntityToPars(entity);
            string result = HttpTo.Get(config.API_Get_User_Info + "?" + pars);

            var outmo = LoginBase.ResultOutput<QQ_OpenId_get_user_info_ResultEntity>(result.Replace("\r\n", ""));

            return outmo;
        }
        #endregion

        #region 微信登录
        /// <summary>
        /// Step1：获取Authorization Code
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<string> AuthorizationHref(WeChat_Authorization_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            var config = await _wechatConfigProvider.GetConfigAsync();
            config.CheckNotNull(nameof(config));

            return string.Concat(new string[] {
                config.API_Authorization,
                "?appid=",
                entity.appid,
                "&response_type=",
                entity.response_type,
                "&scope=",
                entity.scope,
                "&state=",
                entity.state,
                "&redirect_uri=",
                entity.redirect_uri.ToEncode()});
        }

        /// <summary>
        /// Step2：通过Authorization Code获取Access Token、openid
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<WeChat_AccessToken_ResultEntity> AccessToken(WeChat_AccessToken_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            var config = await _wechatConfigProvider.GetConfigAsync();
            config.CheckNotNull(nameof(config));

            string pars = LoginBase.EntityToPars(entity);
            string result = HttpTo.Get(config.API_AccessToken + "?" + pars);

            var outmo = LoginBase.ResultOutput<WeChat_AccessToken_ResultEntity>(result);

            return outmo;
        }

        /// <summary>
        /// Step3：获取用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<WeChat_OpenId_get_user_info_ResultEntity> Get_User_Info(WeChat_OpenAPI_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            var config = await _wechatConfigProvider.GetConfigAsync();
            config.CheckNotNull(nameof(config));

            string pars = LoginBase.EntityToPars(entity);
            string result = HttpTo.Get(config.API_UserInfo + "?" + pars);

            var outmo = LoginBase.ResultOutput<WeChat_OpenId_get_user_info_ResultEntity>(result.Replace("\r\n", ""));

            return outmo;
        }
        #endregion

        #region GitHub
        /// <summary>
        /// 请求授权地址
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<string> AuthorizeHref(GitHub_Authorize_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            var config = await _githubConfigProvider.GetConfigAsync();
            config.CheckNotNull(nameof(config));

            return string.Concat(new string[] {
                config.API_Authorize,
                "?client_id=",
                entity.client_id,
                "&scope=",
                entity.scope.ToEncode(),
                "&state=",
                entity.state,
                "&redirect_uri=",
                entity.redirect_uri.ToEncode()});
        }

        /// <summary>
        /// 获取 access token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<GitHub_AccessToken_ResultEntity> AccessToken(GitHub_AccessToken_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            var config = await _githubConfigProvider.GetConfigAsync();
            config.CheckNotNull(nameof(config));

            string pars = LoginBase.EntityToPars(entity);

            var hwr = HttpTo.HWRequest(config.API_AccessToken, "POST", pars);
            hwr.Accept = "application/json";//application/xml
            string result = HttpTo.Url(hwr);

            var outmo = LoginBase.ResultOutput<GitHub_AccessToken_ResultEntity>(result);

            return outmo;
        }

        /// <summary>
        /// 获取 用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<GitHub_User_ResultEntity> User(GitHub_User_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            var config = await _githubConfigProvider.GetConfigAsync();
            config.CheckNotNull(nameof(config));

            string pars = LoginBase.EntityToPars(entity);

            var hwr = HttpTo.HWRequest(config.API_User + "?" + pars);
            hwr.UserAgent = entity.ApplicationName;
            string result = HttpTo.Url(hwr);

            var outmo = LoginBase.ResultOutput<GitHub_User_ResultEntity>(result, new List<string> { "plan" });

            return outmo;
        }
        #endregion

        #region MicroSoft
        /// <summary>
        /// 请求授权地址
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<string> AuthorizeHref(MicroSoft_Authorize_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            var config = await _microsoftConfigProvider.GetConfigAsync();
            config.CheckNotNull(nameof(config));

            return string.Concat(new string[] {
                config.API_Authorize,
                "?client_id=",
                entity.client_id,
                "&scope=",
                entity.scope,
                "&response_type=",
                entity.response_type,
                "&redirect_uri=",
                entity.redirect_uri.ToEncode()});
        }

        /// <summary>
        /// 获取 access token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<MicroSoft_AccessToken_ResultEntity> AccessToken(MicroSoft_AccessToken_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            var config = await _microsoftConfigProvider.GetConfigAsync();
            config.CheckNotNull(nameof(config));

            string pars = LoginBase.EntityToPars(entity);

            string result = HttpTo.Post(config.API_AccessToken, pars);

            var outmo = LoginBase.ResultOutput<MicroSoft_AccessToken_ResultEntity>(result);

            return outmo;
        }

        /// <summary>
        /// 获取 用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<MicroSoft_User_ResultEntity> User(MicroSoft_User_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            var config = await _microsoftConfigProvider.GetConfigAsync();
            config.CheckNotNull(nameof(config));

            string pars = LoginBase.EntityToPars(entity);

            var hwr = HttpTo.HWRequest(config.API_User + "?" + pars);
            hwr.ContentType = null;
            string result = HttpTo.Url(hwr);
            var outmo = LoginBase.ResultOutput<MicroSoft_User_ResultEntity>(result, new List<string> { "emails" });

            return outmo;
        }
        #endregion

        #region TaoBao
        /// <summary>
        /// Step1：请求用户授权Token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<string> AuthorizeHref(Taobao_Authorize_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            var config = await _taobaoConfigProvider.GetConfigAsync();
            config.CheckNotNull(nameof(config));

            return string.Concat(new string[] {
                config.API_Authorize,
                "?response_type=",
                entity.response_type,
                "&client_id=",
                entity.client_id,
                "&redirect_uri=",
                entity.redirect_uri.ToEncode(),
                "&state=",
                entity.state,
                "&view=",
                entity.view});
        }

        /// <summary>
        /// Step2：获取授权过的Access Token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Taobao_AccessToken_ResultEntity> AccessToken(Taobao_AccessToken_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            var config = await _taobaoConfigProvider.GetConfigAsync();
            config.CheckNotNull(nameof(config));

            string pars = LoginBase.EntityToPars(entity);
            string result = HttpTo.Post(config.API_AccessToken, pars);
            var outmo = LoginBase.ResultOutput<Taobao_AccessToken_ResultEntity>(result);

            return outmo;
        }
        #endregion

        #region Weibo
        /// <summary>
        /// Step1：请求用户授权Token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<string> AuthorizeHref(Weibo_Authorize_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            var config = await _weibaoConfigProvider.GetConfigAsync();
            config.CheckNotNull(nameof(config));

            return string.Concat(new string[] {
                config.API_Authorize,
                "?client_id=",
                entity.client_id,
                "&response_type=",
                entity.response_type,
                "&state=",
                entity.state,
                "&redirect_uri=",
                entity.redirect_uri.ToEncode()});
        }

        /// <summary>
        /// Step2：获取授权过的Access Token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Weibo_AccessToken_ResultEntity> AccessToken(Weibo_AccessToken_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            var config = await _weibaoConfigProvider.GetConfigAsync();
            config.CheckNotNull(nameof(config));

            string pars = LoginBase.EntityToPars(entity);
            string result = HttpTo.Post(config.API_AccessToken, pars);

            var outmo = LoginBase.ResultOutput<Weibo_AccessToken_ResultEntity>(result);

            return outmo;
        }

        /// <summary>
        /// Step3：查询用户access_token的授权相关信息，包括授权时间，过期时间和scope权限。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Weibo_GetTokenInfo_ResultEntity> GetTokenInfo(Weibo_GetTokenInfo_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            var config = await _weibaoConfigProvider.GetConfigAsync();
            config.CheckNotNull(nameof(config));

            string pars = LoginBase.EntityToPars(entity);
            string result = HttpTo.Post(config.API_GetTokenInfo, pars);

            var outmo = LoginBase.ResultOutput<Weibo_GetTokenInfo_ResultEntity>(result);

            return outmo;
        }

        /// <summary>
        /// Step4：根据用户ID获取用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Weibo_UserShow_ResultEntity> UserShow(Weibo_UserShow_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            var config = await _weibaoConfigProvider.GetConfigAsync();
            config.CheckNotNull(nameof(config));

            string pars = LoginBase.EntityToPars(entity);
            string result = HttpTo.Get(config.API_UserShow + "?" + pars);

            var outmo = LoginBase.ResultOutput<Weibo_UserShow_ResultEntity>(result, new List<string> { "status" });

            return outmo;
        }
        #endregion
    }
}
