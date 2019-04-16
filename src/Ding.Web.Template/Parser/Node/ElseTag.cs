using System;

namespace Ding.Web.FPTemplate.Parser.Node
{
    /// <summary>
    /// else标签
    /// </summary>
    public class ElseTag : ElseifTag
    {
        /// <summary>
        /// 获取布布值
        /// </summary>
        /// <param name="context">上下文</param>
        public override Boolean ToBoolean(TemplateContext context)
        {
            return true;
        }
    }
}