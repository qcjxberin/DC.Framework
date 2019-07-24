using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Enums;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagMode = Ding.Ui.Enums.TagMode;

namespace Ding.Ui.Zorro.Tags.Renders {
    /// <summary>
    /// 标签
    /// </summary>
    [HtmlTargetElement( "util-tag")]
    public class TagTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzColor,颜色类型
        /// </summary>
        public AntDesignColor ColorType { get; set; }
        /// <summary>
        /// nzColor,颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// [nzColor],颜色
        /// </summary>
        public string BindColor { get; set; }
        /// <summary>
        /// nzMode,标签模式
        /// </summary>
        public TagMode Mode { get; set; }
        /// <summary>
        /// [nzChecked],选中状态
        /// </summary>
        public bool Checked { get; set; }
        /// <summary>
        /// [(nzChecked)],选中状态
        /// </summary>
        public string BindOnChecked { get; set; }
        /// <summary>
        /// (nzAfterClose)，关闭后事件
        /// </summary>
        public string OnAfterClose { get; set; }
        /// <summary>
        /// (nzClose)，关闭事件
        /// </summary>
        public string OnClose { get; set; }
        /// <summary>
        /// (nzCheckedChange)，选中变更事件
        /// </summary>
        public string OnCheckedChange { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new TagRender( new Config( context ) );
        }
    }
}