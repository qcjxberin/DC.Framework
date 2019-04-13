using Ding.Web.FPTemplate.Parser.Node;

namespace Ding.Web.FPTemplate.Parser
{
    /// <summary>
    /// Include标签分析器
    /// </summary>
    public class IncludeParser : ITagParser
    {
        #region ITagParser 成员
        /// <summary>
        /// 分析标签
        /// </summary>
        /// <param name="parser">TemplateParser</param>
        /// <param name="tc">Token集合</param>
        /// <returns></returns>
        public Tag Parse(TemplateParser parser, TokenCollection tc)
        {
            if (Common.Utility.IsEqual(tc.First.Text, Field.KEY_INCLUDE))
            {
                if (tc != null
                    && parser != null
                    && tc.Count > 2
                    && (tc[1].TokenKind == TokenKind.LeftParentheses)
                    && tc.Last.TokenKind == TokenKind.RightParentheses)
                {
                    IncludeTag tag = new IncludeTag();
                    tag.Path = parser.Read(new TokenCollection(tc, 2, tc.Count - 2));
                    return tag;
                }
            }

            return null;
        }

        #endregion
    }
}