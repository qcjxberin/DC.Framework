using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Material.Dialogs.Renders;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.Dialogs.TagHelpers {
    /// <summary>
    /// 弹出层标题
    /// </summary>
    [HtmlTargetElement( "util-dialog-title" )]
    public class DialogTitleTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new DialogTitleRender( new Config( context ) );
        }
    }
}