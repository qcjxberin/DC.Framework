using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.ColorPickers.Renders;
using Ding.Ui.Configs;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.ColorPickers.TagHelpers {
    /// <summary>
    /// 颜色选择器
    /// </summary>
    [HtmlTargetElement( "util-color-picker", TagStructure = TagStructure.WithoutEndTag )]
    public class ColorPickerTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// name,组件名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// [name],组件名称
        /// </summary>
        public string BindName { get; set; }
        /// <summary>
        /// [(ngModel)],模型绑定
        /// </summary>
        public string NgModel { get; set; }
        /// <summary>
        /// 禁用
        /// </summary>
        public string Disabled { get; set; }
        /// <summary>
        /// 是否内联，内联方式将颜色选择器嵌入页面，否则以弹出层方式选择，默认值：false
        /// </summary>
        public bool Inline { get; set; }
        /// <summary>
        /// 变更事件处理函数,范例：handle()
        /// </summary>
        public string OnChange { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ColorPickerRender( new Config( context ) );
        }
    }
}