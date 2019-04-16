using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Material.Enums;
using Ding.Ui.Material.Menus.Configs;
using Ding.Ui.Material.Menus.Renders;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.Menus.TagHelpers {
    /// <summary>
    /// 菜单
    /// </summary>
    [HtmlTargetElement( "util-menu" )]
    public class MenuTagHelper : AngularTagHelperBase {
        /// <summary>
        /// X轴位置
        /// </summary>
        public XPosition XPosition { get; set; }
        /// <summary>
        /// Y轴位置
        /// </summary>
        public YPosition YPosition { get; set; }
        /// <summary>
        /// 弹出菜单是否与触发按钮重叠
        /// </summary>
        public bool Overlap { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new MenuRender( new MenuConfig( context ) );
        }
    }
}
