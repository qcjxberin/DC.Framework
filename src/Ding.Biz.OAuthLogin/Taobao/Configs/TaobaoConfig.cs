namespace Ding.Biz.OAuthLogin.Taobao.Configs
{
    public class TaobaoConfig : ConfigBase
    {
        /// <summary>
        /// 请根据步骤操作：authorize => access_token
        /// </summary>
        public enum Step
        {
            Step1_Authorize,
            Step2_AccessToken
        }

        #region API请求接口

        /// <summary>
        /// GET
        /// </summary>
        public static string API_Authorize = "https://oauth.taobao.com/authorize";

        /// <summary>
        /// POST
        /// </summary>
        public static string API_AccessToken = "https://oauth.taobao.com/token";

        #endregion
    }
}
