using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Material.Cards.Renders;
using Ding.Ui.Material.Enums;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.Cards.TagHelpers {
    /// <summary>
    /// 卡片操作
    /// </summary>
    [HtmlTargetElement( "util-card-actions" )]
    public class CardActionTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 对齐方式
        /// </summary>
        public XPosition Align { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new CardActionRender( new Config( context ) );
        }
    }
}