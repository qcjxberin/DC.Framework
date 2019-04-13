namespace Ding.Web.FPTemplate
{
    /// <summary>
    /// 表示词法分析模式的枚举值。
    /// </summary>
    /// <remarks></remarks>
    public enum LexerMode
    {
        /// <summary>
        /// 未定义状态。
        /// </summary>
        None = 0,

        /// <summary>
        /// 进入标签。
        /// </summary>
        EnterLabel,

        /// <summary>
        /// 脱离标签。
        /// </summary>
        LeaveLabel,

    }
}