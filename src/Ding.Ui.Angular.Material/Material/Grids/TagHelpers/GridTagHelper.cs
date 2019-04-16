using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Material.Grids.Renders;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.Grids.TagHelpers {
    /// <summary>
    /// 网格
    /// </summary>
    [HtmlTargetElement( "util-grid" )]
    public class GridTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 列数
        /// </summary>
        public int Columns { get; set; }
        /// <summary>
        /// 行高，可指定单位，如果仅传入数值，则单位为px
        /// </summary>
        public string RowHeight { get; set; }
        /// <summary>
        /// 单元格间距，可指定单位，如果仅传入数值，则单位为px
        /// </summary>
        public string GutterSize { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new GridRender( new Config( context ) );
        }
    }
}