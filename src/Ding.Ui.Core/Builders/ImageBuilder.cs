using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ding.Ui.Builders {
    /// <summary>
    /// 图片生成器
    /// </summary>
    public class ImageBuilder : TagBuilder {
        /// <summary>
        /// 初始化图片生成器
        /// </summary>
        public ImageBuilder() : base( "img", TagRenderMode.SelfClosing ) {
        }
    }
}