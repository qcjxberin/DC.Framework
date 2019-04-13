using System;

namespace Ding.Web.FPTemplate.Parser.Node
{
    /// <summary>
    /// 简单标签
    /// 可以组合的标签
    /// </summary>
    public abstract class SimpleTag : TagBase
    {
        /// <summary>
        /// 解析结果
        /// </summary>
        /// <param name="baseValue">基本值</param>
        /// <param name="context">TemplateContext</param>
        /// <returns></returns>
        public abstract Object Parse(Object baseValue, TemplateContext context);
    }
}