namespace Ding.Biz.OAuthLogin.GitHub.Configs
{
    /// <summary>
    /// 配置
    /// </summary>
    public class GitHubConfig
    {
        /// <summary>
        /// 请根据步骤操作：authorize => access_token => user
        /// </summary>
        public enum Step
        {
            /// <summary>
            /// 授权
            /// </summary>
            Step1_Authorize,
            /// <summary>
            /// token
            /// </summary>
            Step2_AccessToken,
            /// <summary>
            /// user
            /// </summary>
            Step3_User
        }

        #region API请求接口

        /// <summary>
        /// GET
        /// </summary>
        public static string API_Authorize { get; set; } = "https://github.com/login/oauth/authorize";

        /// <summary>
        /// POST
        /// </summary>
        public static string API_AccessToken { get; set; } = "https://github.com/login/oauth/access_token";

        /// <summary>
        /// GET
        /// </summary>
        public static string API_User { get; set; } = "https://api.github.com/user";

        #endregion

        /// <summary>
        /// github 申请的应用名称
        /// </summary>
        public static string ApplicationName { get; set; } =  "";

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
