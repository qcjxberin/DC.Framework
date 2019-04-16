using System;

namespace Ding.Web.FPTemplate
{
    /// <summary>
    /// 系统常用字段
    /// </summary>
    public class Field
    {
        /// <summary>
        /// 当前程序版本
        /// </summary>
        public const String Version = "1.3";
        internal const String KEY_FOREACH = "foreach";
        internal const String KEY_IF = "if";
        internal const String KEY_ELSEIF = "elseif";
        internal const String KEY_ELSE = "else";
        internal const String KEY_SET = "set";
        internal const String KEY_LOAD = "load";
        internal const String KEY_INCLUDE = "include";
        internal const String KEY_END = "end";
        internal const String KEY_FOR = "for";
        internal const String KEY_IN = "in";
        /// <summary>
        /// 默认标签解析器
        /// </summary>
        internal static readonly String[] RSEOLVER_TYPES = new String[] {
                "FivePower.Web.FPTemplate.Parser.BooleanParser",
                "FivePower.Web.FPTemplate.Parser.NumberParser",
                "FivePower.Web.FPTemplate.Parser.EleseParser",
                "FivePower.Web.FPTemplate.Parser.EndParser",
                "FivePower.Web.FPTemplate.Parser.VariableParser",
                "FivePower.Web.FPTemplate.Parser.StringParser",
                "FivePower.Web.FPTemplate.Parser.ForeachParser",
                "FivePower.Web.FPTemplate.Parser.ForParser",
                "FivePower.Web.FPTemplate.Parser.SetParser",
                "FivePower.Web.FPTemplate.Parser.IfParser",
                "FivePower.Web.FPTemplate.Parser.ElseifParser",
                "FivePower.Web.FPTemplate.Parser.LoadParser",
                "FivePower.Web.FPTemplate.Parser.IncludeParser",
                "FivePower.Web.FPTemplate.Parser.FunctionParser",
                "FivePower.Web.FPTemplate.Parser.ComplexParser" };
    }


}