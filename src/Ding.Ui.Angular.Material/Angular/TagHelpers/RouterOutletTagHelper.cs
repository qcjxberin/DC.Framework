using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Angular.Renders;
using Ding.Ui.Configs;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Angular.TagHelpers {
    /// <summary>
    /// router-outlet路由出口
    /// </summary>
    [HtmlTargetElement( "util-router-outlet" )]
    public class RouterOutletTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new RouterOutletRender( new Config( context ) );
        }
    }
}