using System.IO;
using Ding.Offices.Excels.Exports;

namespace Ding.Offices.Excels.Npoi.Exports
{
    /// <summary>
    /// Npoi Excel 2003 导出操作
    /// </summary>
    public class Excel2003Export:ExcelExportBase
    {
        /// <summary>
        /// 初始化一个<see cref="Excel2003Export"/>类型的实例
        /// </summary>
        public Excel2003Export() : base(ExcelVersion.Xls, new Excel2003())
        {
        }

        public override IExport Title(string title)
        {
            throw new System.NotImplementedException();
        }        
    }
}
