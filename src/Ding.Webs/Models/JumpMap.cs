using Ding.Data;

namespace Ding.Webs.Models
{
    /// <summary>
    /// 跳转表
    /// </summary>
    public class JumpMap: CacheObject
    {
        /// <summary>
        /// 网址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string JumpTo { get; set; }
    }
}
