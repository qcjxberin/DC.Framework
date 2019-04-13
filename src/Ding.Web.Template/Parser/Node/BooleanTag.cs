using System;

namespace Ding.Web.FPTemplate.Parser.Node
{
    /// <summary>
    /// 布尔标签
    /// </summary>
    public class BooleanTag : TypeTag<Boolean>
    {
        /// <summary>
        /// 获取布布值
        /// </summary>
        /// <param name="context">上下文</param>
        public override Boolean ToBoolean(TemplateContext context)
        {
            return Value;
        }
    }
}