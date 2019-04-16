using Ding.Ui.Components;
using Ding.Ui.Material.Buttons.Renders;
using Ding.Ui.Renders;

namespace Ding.Ui.Material.Buttons {
    /// <summary>
    /// 链接
    /// </summary>
    public class Anchor : ComponentBase, IAnchor {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new AnchorRender( OptionConfig );
        }
    }
}