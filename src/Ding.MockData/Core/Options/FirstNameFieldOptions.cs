using Ding.MockData.Abstractions.Options;

namespace Ding.MockData.Core.Options
{
    /// <summary>
    /// 名字配置
    /// </summary>
    public class FirstNameFieldOptions : FieldOptionsBase, IStringFieldOptions
    {
        /// <summary>
        /// 是否男性
        /// </summary>
        public bool Male { get; set; } = true;

        /// <summary>
        /// 是否女性
        /// </summary>
        public bool Female { get; set; } = true;
    }
}
