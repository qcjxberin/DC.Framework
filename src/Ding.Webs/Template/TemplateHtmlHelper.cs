using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Mvc.Rendering
{
    public static class TemplateHtmlHelper
    {
        public static TemplateInfo GetTemplateInfo(this IHtmlHelper self)
        {
            var template = self.ViewContext.HttpContext.RequestServices.GetRequiredService<TemplateManager>();
            return template.Current;
        }

        public static string GetTemplateIdentifier(this IHtmlHelper self)
        {
            var template = self.ViewContext.HttpContext.RequestServices.GetRequiredService<TemplateManager>();
            return template.Current.Identifier;
        }
    }
}