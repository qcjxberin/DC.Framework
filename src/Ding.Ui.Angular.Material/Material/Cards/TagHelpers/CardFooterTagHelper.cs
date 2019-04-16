using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Material.Cards.Renders;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.Cards.TagHelpers {
    /// <summary>
    /// 卡片底部
    /// </summary>
    [HtmlTargetElement( "util-card-footer" )]
    public class CardFooterTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new CardFooterRender( new Config( context ) );
        }
    }
}