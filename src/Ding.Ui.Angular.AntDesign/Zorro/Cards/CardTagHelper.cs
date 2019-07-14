using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;
using Ding.Ui.Zorro.Cards.Renders;

namespace Ding.Ui.Zorro.Cards {
    /// <summary>
    /// 卡片
    /// </summary>
    [HtmlTargetElement( "util-card")]
    public class CardTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzTitle,标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// [nzBordered],是否显示边框，默认值：true
        /// </summary>
        public bool ShowBorder { get; set; }
        /// <summary>
        /// [nzActions],卡片操作组，位于卡片底部
        /// </summary>
        public string Actions { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new CardRender( new Config( context ) );
        }
    }
}