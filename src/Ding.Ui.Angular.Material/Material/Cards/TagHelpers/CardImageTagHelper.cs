using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Material.Cards.Renders;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.Cards.TagHelpers {
    /// <summary>
    /// 卡片图片
    /// </summary>
    [HtmlTargetElement( "util-card-image", TagStructure = TagStructure.WithoutEndTag )]
    public class CardImageTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 图片路径
        /// </summary>
        public string Src { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new CardImageRender( new Config( context ) );
        }
    }
}