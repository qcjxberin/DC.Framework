using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Extensions;
using Ding.Ui.Material.Tables.Configs;
using Ding.Ui.Material.Tables.Renders;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.Tables.TagHelpers {
    /// <summary>
    /// 表格单元格定义，该标签应放在 util-table-column 中，引用变量名为row，范例：{{row.name}}
    /// </summary>
    [HtmlTargetElement( "util-table-cell", ParentTag = "util-table-column" )]
    public class CellTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new CellRender( new Config( context ) );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        /// <param name="output">TagHelper输出</param>
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            var shareConfig = context.GetValueFromItems<ColumnShareConfig>( ColumnConfig.ColumnShareKey );
            if( shareConfig != null )
                shareConfig.AutoCreateCell = false;
        }
    }
}