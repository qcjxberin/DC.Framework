using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Extensions;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;
using Ding.Ui.Zorro.Tables.Configs;
using Ding.Ui.Zorro.Tables.Renders;

namespace Ding.Ui.Zorro.Tables {
    /// <summary>
    /// 表格行定义，该标签应放在 util-table 中，行数据变量名为 row
    /// </summary>
    [HtmlTargetElement( "util-table-row", ParentTag = "util-table" )]
    public class RowTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 表格标识
        /// </summary>
        private string _tableId;

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new RowRender( new Config( context ), _tableId );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        /// <param name="output">TagHelper输出</param>
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            var shareConfig = context.GetValueFromItems<TableShareConfig>( TableConfig.TableShareKey );
            if ( shareConfig == null )
                return;
            _tableId = shareConfig.TableId;
            shareConfig.AutoCreateRow = false;
        }
    }
}