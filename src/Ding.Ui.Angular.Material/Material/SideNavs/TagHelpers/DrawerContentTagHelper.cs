using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Material.SideNavs.Renders;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.SideNavs.TagHelpers {
    /// <summary>
    /// 侧边栏内容区域
    /// </summary>
    [HtmlTargetElement( "util-drawer-content" )]
    public class DrawerContentTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new DrawerContentRender( new Config( context ) );
        }
    }
}