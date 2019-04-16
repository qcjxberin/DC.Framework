using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Material.Lists.Renders;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.Lists.TagHelpers {
    /// <summary>
    /// 列表头像，该标签应放到 util-list-item 中
    /// </summary>
    [HtmlTargetElement( "util-list-avatar", TagStructure = TagStructure.WithoutEndTag )]
    public class ListAvatarTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 图片路径
        /// </summary>
        public string Src { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ListAvatarRender( new Config( context ) );
        }
    }
}