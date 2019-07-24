using Ding.Ui.ColorPickers.Renders;
using Ding.Ui.Components;
using Ding.Ui.Renders;

namespace Ding.Ui.ColorPickers {
    /// <summary>
    /// 颜色选择器
    /// </summary>
    public class ColorPicker : ComponentBase, IColorPicker {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new ColorPickerRender( OptionConfig );
        }
    }
}