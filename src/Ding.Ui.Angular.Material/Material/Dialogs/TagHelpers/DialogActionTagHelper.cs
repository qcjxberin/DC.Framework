using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Material.Dialogs.Renders;
using Ding.Ui.Material.Enums;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.Dialogs.TagHelpers {
    /// <summary>
    /// 弹出层操作
    /// </summary>
    [HtmlTargetElement( "util-dialog-actions" )]
    public class DialogActionTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 对齐方式
        /// </summary>
        public Align Align { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new DialogActionRender( new Config( context ) );
        }
    }
}