namespace Ding.Webs.Models
{
    /// <summary>
    /// 提示模型类
    /// </summary>
    public class PromptModel
    {
        /// <summary>
        /// 返回地址
        /// </summary>
        public string BackUrl { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 倒计时时间
        /// </summary>
        public int CountdownTime { get; set; }

        /// <summary>
        /// 是否显示返回地址
        /// </summary>
        public bool IsShowBackLink { get; set; }

        /// <summary>
        /// 是否自动返回
        /// </summary>
        public bool IsAutoBack { get; set; }

        /// <summary>
        /// 网页标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 网站名称
        /// </summary>
        public string WebName { get; set; }
    }
}
