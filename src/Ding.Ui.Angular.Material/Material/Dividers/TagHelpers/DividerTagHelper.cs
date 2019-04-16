using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Material.Dividers.Renders;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.Dividers.TagHelpers {
    /// <summary>
    /// 分隔线
    /// </summary>
    [HtmlTargetElement( "util-divider",TagStructure = TagStructure.WithoutEndTag)]
    public class DividerTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 分隔线两端是否存在间距
        /// </summary>
        public bool Inset { get; set; }
        /// <summary>
        /// 垂直方向
        /// </summary>
        public bool Vertical { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new DividerRender( new Config( context ) );
        }
    }
}