namespace Ding.Biz.OAuthLogin.Weibo.Configs
{
    public class WeiboConfig
    {
        /// <summary>
        /// 请根据步骤操作：authorize => access_token => get_token_info => users/show
        /// </summary>
        public enum Step
        {
            Step1_Authorize,
            Step2_AccessToken,
            Step3_GetTokenInfo,
            Step4_UserShow
        }

        #region API请求接口

        /// <summary>
        /// GET
        /// </summary>
        public static string API_Authorize { get; set; } = "https://api.weibo.com/oauth2/authorize";

        /// <summary>
        /// POST
        /// </summary>
        public static string API_AccessToken { get; set; } = "https://api.weibo.com/oauth2/access_token";

        /// <summary>
        /// POST
        /// </summary>
        public static string API_GetTokenInfo { get; set; } = "https://api.weibo.com/oauth2/get_token_info";

        /// <summary>
        /// GET
        /// </summary>
        public static string API_UserShow { get; set; } = "https://api.weibo.com/2/users/show.json";

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
