using System;
using Ding.Offices.Excels.Mappings.Abstractions;

namespace Ding.Offices.Excels.Mappings.Attributes
{
    public class ExcelStatisticsAttribute:Attribute,IStatisticsMap
    {
        public string Name { get; set; }
        public string Formula { get; set; }
        public int[] Columns { get; set; }
    }
}
