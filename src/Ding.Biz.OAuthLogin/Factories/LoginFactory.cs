using Ding.Biz.OAuthLogin.QQ.Configs;
using Ding.Utils.Helpers;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ding.Biz.OAuthLogin.Factories
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

        public LoginFactory(IQQConfigProvider qqConfigProvider)
        {
            _qqConfigProvider = qqConfigProvider;
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
            var mo = new QQ_OpenId_ResultEntity();
            var pis = mo.GetType().GetProperties();

            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            var config = await _qqConfigProvider.GetConfigAsync();
            config.CheckNotNull(nameof(config));

            string pars = LoginBase.EntityToPars(entity);
            string result = HttpTo.Get(config.API_OpenID_PC + "?" + pars);
            //callback( {"client_id":"xx12196xx","openid":"09196B48CA96A8C8ED4FFxxCBxx59Dxx"} );
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
    }
}
