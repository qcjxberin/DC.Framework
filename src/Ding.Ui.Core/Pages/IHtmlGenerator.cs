using System.Threading.Tasks;
using Ding.Dependency;

namespace Ding.Ui.Pages {
    /// <summary>
    /// Html生成器
    /// </summary>
    public interface IHtmlGenerator : IScopeDependency {
        /// <summary>
        /// 构建并生成Html
        /// </summary>
        Task BuildAsync();
    }
}