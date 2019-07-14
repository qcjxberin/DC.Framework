using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Enums;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;
using Ding.Ui.Zorro.Messages.Renders;

namespace Ding.Ui.Zorro.Messages {
    /// <summary>
    /// 警告提示
    /// </summary>
    [HtmlTargetElement( "util-alert" )]
    public class AlertTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzType,警告提示样式
        /// </summary>
        public AlertType Type { get; set; }
        /// <summary>
        /// [nzShowIcon],是否显示图标，默认值为 false,nzBanner 模式下默认值为 true
        /// </summary>
        public bool ShowIcon { get; set; }
        /// <summary>
        /// nzMessage,警告提示内容
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// [nzMessage],警告提示内容
        /// </summary>
        public string BindMessage { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new AlertRender( new Config( context ) );
        }
    }
}