using System;
using Ding.Offices.Excels.Mappings.Abstractions;

namespace Ding.Offices.Excels.Mappings.Attributes
{
    public class ExcelAttribute:Attribute,IExcelMap
    {
        public bool AutoIndex { get; set; }
        public string Title { get; set; }
    }
}
