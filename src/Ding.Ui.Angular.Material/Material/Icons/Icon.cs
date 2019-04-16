using Ding.Ui.Components;
using Ding.Ui.Configs;
using Ding.Ui.Material.Icons.Configs;
using Ding.Ui.Material.Icons.Renders;
using Ding.Ui.Renders;

namespace Ding.Ui.Material.Icons {
    /// <summary>
    /// 图标
    /// </summary>
    public class Icon : ComponentBase, IIcon {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new IconRender( OptionConfig );
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        protected override IConfig GetConfig() {
            return new IconConfig();
        }
    }
}
