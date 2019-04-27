namespace Ding.Webs
{
    public class Marked
    {
        public static string Parse(string md)
        {
            return Ding.Marked.Instance.Parse(md);
        }
    }
}

namespace Microsoft.AspNetCore.Mvc.Rendering
{
    using Microsoft.AspNetCore.Html;

    public static class MarkedExtensions
    {
        public static HtmlString Marked(this IHtmlHelper self, string Content)
        {
            return new HtmlString(Ding.Marked.Instance.Parse(Content));
        }
    }
}