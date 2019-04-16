using System;
using Ding.Web.FPTemplate.Parser.Node;

namespace Ding.Web.FPTemplate.Parser
{
    /// <summary>
    /// ELSE IF标签分析器
    /// </summary>
    public class ElseifParser : ITagParser
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
            if (tc != null
                && parser != null
                && tc.Count > 3
                && Common.Utility.IsEqual(tc.First.Text, Field.KEY_ELSEIF))
            {

                if (tc[1].TokenKind == TokenKind.LeftParentheses
                   && tc.Last.TokenKind == TokenKind.RightParentheses)
                {
                    ElseifTag tag = new ElseifTag();

                    TokenCollection coll = new TokenCollection();
                    coll.Add(tc, 2, tc.Count - 2);
                    tag.Test = parser.Read(coll);

                    return tag;
                }
                else
                {
                    throw new Exception.ParseException(String.Concat("syntax error near if:", tc), tc.First.BeginLine, tc.First.BeginColumn);
                }
            }

            return null;
        }

        #endregion
    }
}