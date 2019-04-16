using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Material.Panels.Renders;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.Panels.TagHelpers {
    /// <summary>
    /// 面板内容
    /// </summary>
    [HtmlTargetElement( "util-panel-content" )]
    public class PanelContentTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new PanelContentRender( new Config( context ) );
        }
    }
}