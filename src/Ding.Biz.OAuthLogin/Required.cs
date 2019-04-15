using System;

namespace Ding.Biz.OAuthLogin
{
    /// <summary>
    /// 必填特性
    /// </summary>
    public class Required : Attribute
    {
        /// <summary>
        /// 说明内容
        /// </summary>
        public string Message { get; set; }
    }
}
