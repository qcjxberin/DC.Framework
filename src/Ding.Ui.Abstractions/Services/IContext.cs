using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ding.Ui.Services {
    /// <summary>
    /// Ui上下文
    /// </summary>
    public interface IContext<TModel> {
        /// <summary>
        /// HtmlHelper
        /// </summary>
        IHtmlHelper<TModel> Helper { get; }
    }
}
