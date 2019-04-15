namespace Ding.Sms.FengHuo
{
    /// <summary>
    /// 烽火万家短信配置
    /// </summary>
    public class SmsConfig
    {
        /// <summary>
        /// 短信网关地址
        /// </summary>
        public string Url { get; set; } = "http://210.51.191.35:8080/eums/sms/utf8/";

        /// <summary>
        /// 密钥Id
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 密钥密码
        /// </summary>
        public string PassWrod { get; set; }

        /// <summary>
        /// 短信签名名称
        /// </summary>
        public string SignName { get; set; }
    }
}
