using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;
using Ding.Ui.Zorro.Forms.Renders;

namespace Ding.Ui.Zorro.Forms {
    /// <summary>
    /// 表单标签
    /// </summary>
    [HtmlTargetElement( "util-form-label" )]
    public class FormLabelTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// 标签文本
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// 是否必填项，显示红色星号
        /// </summary>
        public string Required { get; set; }
        /// <summary>
        /// nzFor,设置标签指向的组件Id,注意：请设置组件的raw-id属性
        /// </summary>
        public string LabelFor { get; set; }
        /// <summary>
        /// nzColon,是否显示冒号，默认值：true
        /// </summary>
        public bool ShowColon { get; set; }
        /// <summary>
        /// [nzSpan],24栅格占位格数，可选值: 0 - 24, 为 0 时隐藏
        /// </summary>
        public int Span { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new FormLabelRender( new Config( context ) );
        }
    }
}