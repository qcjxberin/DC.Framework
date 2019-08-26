using Ding.Biz.OAuthLogin.MicroSoft.Configs;
using Ding.Extension;
using Ding.Helpers;
using System;

namespace Ding.Biz.OAuthLogin
{
    /// <summary>
    /// Step1：获取authorize Code
    /// </summary>
    public class MicroSoft_Authorize_RequestEntity
    {
        /// <summary>
        /// MicroSoft登录配置
        /// </summary>
        protected static readonly MicroSoftConfig MicroSoftConfig;

        /// <summary>
        /// 初始化一个<see cref="MicroSoft_Authorize_RequestEntity"/>类型的实例
        /// </summary>
        static MicroSoft_Authorize_RequestEntity()
        {
            var provider = Ioc.Create<IMicroSoftConfigProvider>();
            provider.CheckNotNull(nameof(provider));
            MicroSoftConfig = provider.GetConfigAsync().Result;
        }

        /// <summary>
        /// 注册应用时的获取的client_id
        /// </summary>
        [Required]
        public string client_id { get; set; } = MicroSoftConfig.APPID;

        /// <summary>
        /// 必须包括授权代码流的 code
        /// </summary>
        [Required]
        public string response_type { get; set; } = "code";

        /// <summary>
        /// 作用域
        /// </summary>
        [Required]
        public string scope { get; set; } = "wl.signin";


        /// <summary>
        /// 鉴权成功之后，重定向到网站
        /// </summary>
        [Required]
        public string redirect_uri { get; set; } = MicroSoftConfig.Redirect_Uri;


        /// <summary>
        /// 自己设定，用于防止跨站请求伪造攻击
        /// </summary>
        [Required]
        public string state { get; set; } = Guid.NewGuid().ToString("N");
    }
}
