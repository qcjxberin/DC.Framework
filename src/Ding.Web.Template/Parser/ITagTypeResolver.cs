using Ding.Web.FPTemplate.Parser.Node;

namespace Ding.Web.FPTemplate.Parser
{
    /// <summary>
    /// 标签类型分析器
    /// </summary>
    public interface ITagTypeResolver
    {
        /// <summary>
        /// 解析标签
        /// </summary>
        /// <param name="parser">TemplateParser</param>
        /// <param name="tc">Token集合</param>
        /// <returns></returns>
        Tag Resolver(TemplateParser parser, TokenCollection tc);
    }
}