using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;
using Ding.Ui.Zorro.Enums;
using Ding.Ui.Zorro.Icons.Renders;

namespace Ding.Ui.Zorro.Icons {
    /// <summary>
    /// 图标
    /// </summary>
    [HtmlTargetElement( "util-icon" )]
    public class IconTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzType,图标类型
        /// </summary>
        public AntDesignIcon Type { get; set; }
        /// <summary>
        /// [nzType],图标类型
        /// </summary>
        public string BindType { get; set; }
        /// <summary>
        /// nzTheme,图标主题风格
        /// </summary>
        public AntDesignTheme Theme { get; set; }
        /// <summary>
        /// [nzTheme],图标主题风格
        /// </summary>
        public string BindTheme { get; set; }
        /// <summary>
        /// 持续旋转
        /// </summary>
        public bool Spin { get; set; }
        /// <summary>
        /// 旋转角度
        /// </summary>
        public string Rotate { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new IconRender( new Config( context ) );
        }
    }
}
