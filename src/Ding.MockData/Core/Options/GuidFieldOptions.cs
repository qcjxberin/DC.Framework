﻿using Ding.MockData.Abstractions.Options;

namespace Ding.MockData.Core.Options
{
    /// <summary>
    /// Guid配置
    /// </summary>
    public class GuidFieldOptions : FieldOptionsBase, IGuidFieldOptions
    {
        /// <summary>
        /// 是否大写字符
        /// </summary>
        public bool Uppercase { get; set; } = true;
    }
}
