using Ding.Parameters.Formats;

namespace Ding.Tests.Samples {
    /// <summary>
    /// 参数格式化器样例
    /// </summary>
    public class ParameterFormatterSample : ParameterFormatBase {
        /// <summary>
        /// 格式化分割符
        /// </summary>
        protected override string FormatSeparator => ":";

        /// <summary>
        /// 连接符
        /// </summary>
        protected override string JoinSeparator => "|";
    }
}
