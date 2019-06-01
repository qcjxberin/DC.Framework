using Ding.Ui.Angular.Base;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;
using Ding.Ui.Zorro.Forms.Configs;
using Ding.Ui.Zorro.Forms.Renders;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ding.Ui.Zorro.Forms {
    /// <summary>
    /// 复选框组
    /// </summary>
    [HtmlTargetElement( "util-checkbox-group" )]
    public class CheckboxGroupTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// [(ngModel)],模型绑定
        /// </summary>
        public string NgModel { get; set; }
        /// <summary>
        /// nzName,控件的名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// [nzName],控件的名称
        /// </summary>
        public string BindName { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// [url],请求地址
        /// </summary>
        public string BindUrl { get; set; }
        /// <summary>
        /// 数据源
        /// </summary>
        public ModelExpression Data { get; set; }
        /// <summary>
        /// 数据源
        /// </summary>
        public string BindData { get; set; }
        /// <summary>
        /// [nzDisabled],禁用
        /// </summary>
        public string Disabled { get; set; }
        /// <summary>
        /// 必填项
        /// </summary>
        public string Required { get; set; }
        /// <summary>
        /// 必填项错误消息
        /// </summary>
        public string RequiredMessage { get; set; }
        /// <summary>
        /// (ngModelChange),变更事件处理函数
        /// </summary>
        public string OnChange { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new CheckboxGroupRender( new CheckboxGroupConfig( context ) );
        }
    }
}