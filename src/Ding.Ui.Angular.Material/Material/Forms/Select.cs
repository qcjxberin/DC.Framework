using Ding.Ui.Angular.Forms.Configs;
using Ding.Ui.Components;
using Ding.Ui.Configs;
using Ding.Ui.Material.Extensions;
using Ding.Ui.Material.Forms.Renders;
using Ding.Ui.Renders;

namespace Ding.Ui.Material.Forms {
    /// <summary>
    /// 下拉列表
    /// </summary>
    public class Select : ComponentBase, ISelect {
        /// <summary>
        /// 下拉列表配置
        /// </summary>
        private readonly SelectConfig _config;

        /// <summary>
        /// 初始化下拉列表
        /// </summary>
        public Select() {
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
            return new SelectRender( _config );
        }

        /// <summary>
        /// 绑定枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        public ISelect Enum<TEnum>() {
            return this.Add( Ding.Helpers.Enum.GetItems<TEnum>().ToArray() );
        }
    }
}
