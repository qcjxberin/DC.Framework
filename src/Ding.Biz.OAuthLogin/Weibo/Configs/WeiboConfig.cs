namespace Ding.Biz.OAuthLogin.Weibo.Configs
{
    public class WeiboConfig : ConfigBase
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
        public string API_Authorize = "https://api.weibo.com/oauth2/authorize";

        /// <summary>
        /// POST
        /// </summary>
        public string API_AccessToken = "https://api.weibo.com/oauth2/access_token";

        /// <summary>
        /// POST
        /// </summary>
        public string API_GetTokenInfo = "https://api.weibo.com/oauth2/get_token_info";

        /// <summary>
        /// GET
        /// </summary>
        public string API_UserShow = "https://api.weibo.com/2/users/show.json";

        #endregion

    }
}
