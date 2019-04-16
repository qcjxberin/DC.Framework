using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Material.Enums;
using Ding.Ui.Material.Tabs.Renders;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.Tabs.TagHelpers {
    /// <summary>
    /// 导航选项卡组
    /// </summary>
    [HtmlTargetElement( "util-nav-tabs" )]
    public class TabNavTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 背景色
        /// </summary>
        public Color BackgroundColor { get; set; }
        /// <summary>
        /// 主题色
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new TabNavRender( new Config( context ) );
        }
    }
}