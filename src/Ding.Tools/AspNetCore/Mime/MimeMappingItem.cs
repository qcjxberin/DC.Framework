#if __CORE__

namespace Ding.Tools.AspNetCore.Mime
{
    /// <summary>
    /// 
    /// </summary>
    public class MimeMappingItem
    {
        /// <summary>
        /// 扩展名
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// MimeType
        /// </summary>
        public string MimeType { get; set; }
    }
}
#endif