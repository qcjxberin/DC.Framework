namespace Ding.Biz.OAuthLogin.WeChat.Configs
{
    /// <summary>
    /// 配置
    /// </summary>
    public class WeChatConfig : ConfigBase
    {
        /// <summary>
        /// 仅做说明用
        /// 请根据步骤操作：Authorization => AccessToken => OpenId => OpenAPI（UserInfo）
        /// </summary>
        public enum Step
        {
            Step1_Authorization,
            Step2_AccessToken,
            Step3_OpenAPI
        }

        #region API请求接口

        /// <summary>
        /// GET
        /// </summary>
        public string API_Authorization = "https://open.weixin.qq.com/connect/qrconnect";

        /// <summary>
        /// POST
        /// </summary>
        public string API_AccessToken = "https://api.weixin.qq.com/sns/oauth2/access_token";

        /// <summary>
        /// GET
        /// </summary>
        public string API_UserInfo = "https://api.weixin.qq.com/sns/userinfo";

        #endregion
    }
}
