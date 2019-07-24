using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;
using Ding.Ui.Zorro.Tabs.Renders;

namespace Ding.Ui.Zorro.Tabs {
    /// <summary>
    /// 标签页
    /// </summary>
    [HtmlTargetElement( "util-tabs" )]
    public class TabSetTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzSelectedIndex],激活选项卡的索引
        /// </summary>
        public int SelectedIndex { get; set; }
        /// <summary>
        /// [(nzSelectedIndex)],激活选项卡的索引
        /// </summary>
        public string BindOnSelectedIndex { get; set; }
        /// <summary>
        /// (nzSelectedIndexChange),选项卡索引变更事件
        /// </summary>
        public string OnSelectedIndexChange { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new TabSetRender( new Config( context ) );
        }
    }
}