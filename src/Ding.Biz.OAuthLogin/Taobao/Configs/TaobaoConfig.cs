namespace Ding.Biz.OAuthLogin.Taobao.Configs
{
    public class TaobaoConfig
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
        public static string API_Authorize { get; set; } = "https://oauth.taobao.com/authorize";

        /// <summary>
        /// POST
        /// </summary>
        public static string API_AccessToken { get; set; } = "https://oauth.taobao.com/token";

        #endregion

        /// <summary>
        /// APP ID
        /// </summary>
        public static string APPID { get; set; } = "";

        /// <summary>
        /// APP Key
        /// </summary>
        public static string APPKey { get; set; } = "";

        /// <summary>
        /// 回调
        /// </summary>
        public static string Redirect_Uri { get; set; } = "";
    }
}
