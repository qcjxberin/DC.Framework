using Ding.Biz.OAuthLogin.GitHub.Configs;
using Ding.Biz.OAuthLogin.QQ.Configs;
using Ding.Biz.OAuthLogin.WeChat.Configs;
using Ding.Utils.Helpers;
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
        /// 微信登录配置提供器
        /// </summary>
        protected readonly IGitHubConfigProvider _githubConfigProvider;

        public LoginFactory(IQQConfigProvider qqConfigProvider, IWeChatConfigProvider wechatConfigProvider, IGitHubConfigProvider githubConfigProvider)
        {
            _qqConfigProvider = qqConfigProvider;
            _wechatConfigProvider = wechatConfigProvider;
            _githubConfigProvider = githubConfigProvider;
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
    }
}
