using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Material.Lists.Renders;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.Lists.TagHelpers {
    /// <summary>
    /// 导航列表文本，该标签应放到 util-nav-list-item 中
    /// </summary>
    [HtmlTargetElement( "util-nav-list-text" )]
    public class NavListTextTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new NavListTextRender( new Config( context ) );
        }
    }
}