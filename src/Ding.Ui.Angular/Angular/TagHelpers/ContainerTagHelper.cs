using Ding.Ui.Angular.Base;
using Ding.Ui.Angular.Renders;
using Ding.Ui.Configs;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ding.Ui.Angular.TagHelpers {
    /// <summary>
    /// ng-container容器
    /// </summary>
    [HtmlTargetElement( "util-container" )]
    public class ContainerTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ContainerRender( new Config( context ) );
        }
    }
}
