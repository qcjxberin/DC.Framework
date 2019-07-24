using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Angular.Renders;
using Ding.Ui.Configs;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Angular.TagHelpers {
    /// <summary>
    /// ng-template模板
    /// </summary>
    [HtmlTargetElement( "util-template" )]
    public class TemplateTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new TemplateRender( new Config( context ) );
        }
    }
}