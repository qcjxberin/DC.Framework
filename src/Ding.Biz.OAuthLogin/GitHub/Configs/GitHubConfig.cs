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
        public string API_Authorize = "https://github.com/login/oauth/authorize";

        /// <summary>
        /// POST
        /// </summary>
        public string API_AccessToken = "https://github.com/login/oauth/access_token";

        /// <summary>
        /// GET
        /// </summary>
        public string API_User = "https://api.github.com/user";

        #endregion

        /// <summary>
        /// github 申请的应用名称
        /// </summary>
        public string ApplicationName { get; set; } =  "";
    }
}
