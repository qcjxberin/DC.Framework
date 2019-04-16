using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Material.Panels.Renders;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.Panels.TagHelpers {
    /// <summary>
    /// 面板头部
    /// </summary>
    [HtmlTargetElement( "util-panel-header" )]
    public class PanelHeaderTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 面板折叠时标题的高度
        /// </summary>
        public double CollapsedHeight { get; set; }
        /// <summary>
        /// 面板展开时标题的高度
        /// </summary>
        public double ExpandedHeight { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new PanelHeaderRender( new Config( context ) );
        }
    }
}