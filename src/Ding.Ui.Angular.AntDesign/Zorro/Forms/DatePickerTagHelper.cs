using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Forms.Configs;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;
using Ding.Ui.Zorro.Forms.Base;
using Ding.Ui.Zorro.Forms.Renders;

namespace Ding.Ui.Zorro.Forms {
    /// <summary>
    /// 日期选择
    /// </summary>
    [HtmlTargetElement( "util-date-picker" )]
    public class DatePickerTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            var config = new TextBoxConfig( context ) { IsDatePicker = true };
            return new TextBoxRender( config );
        }
    }
}