﻿using Ding.Biz.OAuthLogin.Weibo.Configs;
using Ding.Extension;
using Ding.Helpers;

namespace Ding.Biz.OAuthLogin
{
    /// <summary>
    /// Step2：Oauth2/access token
    /// Url：http://open.weibo.com/wiki/Oauth2/access_token
    /// </summary>
    public class Weibo_AccessToken_RequestEntity
    {
        /// <summary>
        /// Weibo登录配置
        /// </summary>
        protected static readonly WeiboConfig WeiboConfig;

        /// <summary>
        /// 初始化一个<see cref="Weibo_Authorize_RequestEntity"/>类型的实例
        /// </summary>
        static Weibo_AccessToken_RequestEntity()
        {
            var provider = Ioc.Create<IWeiboConfigProvider>();
            provider.CheckNotNull(nameof(provider));
            WeiboConfig = provider.GetConfigAsync().Result;
        }

        /// <summary>
        /// 申请应用时分配的AppKey。
        /// </summary>
        [Required]
        public string client_id { get; set; } = WeiboConfig.APPID;

        /// <summary>
        /// 申请应用时分配的AppSecret。
        /// </summary>
        [Required]
        public string client_secret { get; set; } = WeiboConfig.APPKey;

        /// <summary>
        /// 请求的类型，填写authorization_code
        /// </summary>
        [Required]
        public string grant_type { get; set; } = "authorization_code";

        /// <summary>
        /// grant_type为authorization_code时
        /// 调用authorize获得的code值。
        /// </summary>
        [Required]
        public string code { get; set; }

        /// <summary>
        /// grant_type为authorization_code时
        /// 回调地址，需需与注册应用里的回调地址一致。
        /// </summary>
        [Required]
        public string redirect_uri { get; set; } = WeiboConfig.Redirect_Uri;

    }
}
