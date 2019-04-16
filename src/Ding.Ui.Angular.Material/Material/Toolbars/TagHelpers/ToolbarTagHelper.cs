using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Material.Enums;
using Ding.Ui.Material.Toolbars.Renders;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.Toolbars.TagHelpers {
    /// <summary>
    /// 工具栏
    /// </summary>
    [HtmlTargetElement( "util-toolbar" )]
    public class ToolbarTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 颜色
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ToolbarRender( new Config( context ) );
        }
    }
}