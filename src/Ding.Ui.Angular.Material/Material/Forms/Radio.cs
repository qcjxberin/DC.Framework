using Ding.Ui.Angular.Forms.Configs;
using Ding.Ui.Components;
using Ding.Ui.Configs;
using Ding.Ui.Material.Extensions;
using Ding.Ui.Material.Forms.Renders;
using Ding.Ui.Renders;

namespace Ding.Ui.Material.Forms {
    /// <summary>
    /// 单选框
    /// </summary>
    public class Radio : ComponentBase, IRadio {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly SelectConfig _config;

        /// <summary>
        /// 初始化单选框
        /// </summary>
        public Radio() {
            _config = new SelectConfig();
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
            return new RadioRender( _config );
        }

        /// <summary>
        /// 绑定枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        public IRadio Enum<TEnum>() {
            return this.Add( Ding.Helpers.Enum.GetItems<TEnum>().ToArray() );
        }
    }
}