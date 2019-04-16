using Ding.MockData.Abstractions.Options;
using System.Collections.Generic;

namespace Ding.MockData.Core.Options
{
    /// <summary>
    /// 字符串列表配置
    /// </summary>
    public class StringListFieldOptions : FieldOptionsBase, IStringFieldOptions
    {
        /// <summary>
        /// 值列表
        /// </summary>
        public List<string> Values { get; set; }
    }
}
