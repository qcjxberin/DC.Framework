namespace Ding.Biz.OAuthLogin.MicroSoft.Configs
{
    /// <summary>
    /// 配置
    /// </summary>
    public class MicroSoftConfig : ConfigBase
    {
        /// <summary>
        /// 请根据步骤操作：authorize => access_token => user
        /// </summary>
        public enum Step
        {
            Step1_Authorize,
            Step2_AccessToken,
            Step3_User
        }

        #region API请求接口

        /// <summary>
        /// GET
        /// </summary>
        public string API_Authorize = "https://login.live.com/oauth20_authorize.srf";

        /// <summary>
        /// POST
        /// </summary>
        public string API_AccessToken = "https://login.live.com/oauth20_token.srf";

        /// <summary>
        /// GET
        /// </summary>
        public string API_User = "https://apis.live.net/v5.0/me";

        #endregion
    }
}
