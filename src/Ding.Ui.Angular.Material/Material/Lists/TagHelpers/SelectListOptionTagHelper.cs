using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Material.Enums;
using Ding.Ui.Material.Lists.Renders;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.Lists.TagHelpers {
    /// <summary>
    /// 选择列表项，该标签应放到 util-select-list 中
    /// </summary>
    [HtmlTargetElement( "util-select-list-item" )]
    public class SelectListOptionTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// [value],值属性绑定
        /// </summary>
        public string BindValue { get; set; }
        /// <summary>
        /// 复选框位置
        /// </summary>
        public XPosition CheckboxPosition { get; set; }
        /// <summary>
        /// 选中
        /// </summary>
        public string Selected { get; set; }
        /// <summary>
        /// 禁用
        /// </summary>
        public string Disabled { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            var config = new Config( context );
            SetCheckboxPosition( config, context );
            return new SelectListOptionRender( config );
        }

        /// <summary>
        /// 设置复选框位置
        /// </summary>
        private void SetCheckboxPosition( Config config, Context context ) {
            var position = context.GetValueFromItems<XPosition?>( MaterialConst.CheckboxPosition );
            if( position == null )
                return;
            config.SetAttribute( MaterialConst.CheckboxPosition, position, false );
        }
    }
}