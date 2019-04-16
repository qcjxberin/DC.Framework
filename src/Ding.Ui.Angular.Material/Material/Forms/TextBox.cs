using Ding.Ui.Angular.Forms.Configs;
using Ding.Ui.Components;
using Ding.Ui.Configs;
using Ding.Ui.Material.Forms.Renders;
using Ding.Ui.Renders;

namespace Ding.Ui.Material.Forms {
    /// <summary>
    /// 文本框
    /// </summary>
    public class TextBox : ComponentBase,ITextBox {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly TextBoxConfig _config;

        /// <summary>
        /// 初始化文本框
        /// </summary>
        public TextBox() {
            _config = new TextBoxConfig();
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        protected override IConfig GetConfig() {
            return _config;
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new TextBoxRender( _config );
        }
    }
}
