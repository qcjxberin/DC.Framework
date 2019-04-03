namespace Ding.Biz.OAuthLogin
{
    public class ConfigBase
    {
        /// <summary>
        /// APP ID
        /// </summary>
        public string APPID { get; set; } = "";

        /// <summary>
        /// APP Key
        /// </summary>
        public string APPKey { get; set; } = "";

        /// <summary>
        /// 回调
        /// </summary>
        public string Redirect_Uri { get; set; } = "";
    }
}