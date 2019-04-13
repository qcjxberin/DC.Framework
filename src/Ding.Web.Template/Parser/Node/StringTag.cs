using System;

namespace Ding.Web.FPTemplate.Parser.Node
{
    /// <summary>
    /// 字符串标签
    /// </summary>
    public class StringTag : TypeTag<String>
    {
        /// <summary>
        /// 转换成BOOLEAN
        /// </summary>
        /// <param name="context">上下文</param>
        public override Boolean ToBoolean(TemplateContext context)
        {
            return !String.IsNullOrEmpty(Value);
        }
    }
}