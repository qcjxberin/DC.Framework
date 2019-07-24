using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;
using Ding.Ui.Zorro.Tabs.Renders;

namespace Ding.Ui.Zorro.Tabs {
    /// <summary>
    /// 标签选项卡
    /// </summary>
    [HtmlTargetElement( "util-tab",ParentTag = "util-tabs" )]
    public class TabTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzTitle,标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 是否延迟加载，默认值: false
        /// </summary>
        public bool Lazy { get; set; }
        /// <summary>
        /// (nzClick),单击事件
        /// </summary>
        public string OnClick { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new TabRender( new Config( context ) );
        }
    }
}