using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Material.Dialogs.Renders;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.Dialogs.TagHelpers {
    /// <summary>
    /// 弹出层内容
    /// </summary>
    [HtmlTargetElement( "util-dialog-content" )]
    public class DialogContentTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new DialogContentRender( new Config( context ) );
        }
    }
}