using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ding.Ui.Zorro.TreeTables {
    /// <summary>
    /// 树形表格标题行定义，该标签应放在 util-tree-table 中
    /// </summary>
    [HtmlTargetElement( "util-tree-table-head", ParentTag = "util-tree-table" )]
    public class HeadTagHelper : Ding.Ui.Zorro.Tables.HeadTagHelper {
    }
}