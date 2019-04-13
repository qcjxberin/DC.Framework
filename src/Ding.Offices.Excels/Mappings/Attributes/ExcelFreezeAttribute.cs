using System;
using Ding.Offices.Excels.Mappings.Abstractions;

namespace Ding.Offices.Excels.Mappings.Attributes
{
    public class ExcelFreezeAttribute:Attribute,IFreezeMap
    {
        public int ColumnSplit { get; set; }
        public int RowSpit { get; set; }
        public int LeftMostColumn { get; set; }
        public int TopRow { get; set; }
    }
}
