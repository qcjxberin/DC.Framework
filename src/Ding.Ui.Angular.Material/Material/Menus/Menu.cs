using System.IO;
using Ding.Ui.Components;
using Ding.Ui.Configs;
using Ding.Ui.Material.Menus.Configs;
using Ding.Ui.Material.Menus.Renders;
using Ding.Ui.Material.Menus.Wrappers;
using Ding.Ui.Renders;

namespace Ding.Ui.Material.Menus {
    /// <summary>
    /// 菜单
    /// </summary>
    public class Menu : ContainerBase<IMenuWrapper>, IMenu {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly MenuConfig _config;

        /// <summary>
        /// 初始化菜单
        /// </summary>
        public Menu() : this( null ) {
        }

        /// <summary>
        /// 初始化菜单
        /// </summary>
        /// <param name="writer">流写入器</param>
        public Menu( TextWriter writer ) : base( writer ) {
            _config = new MenuConfig();
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
            return new MenuRender( _config );
        }

        /// <summary>
        /// 获取容器包装器
        /// </summary>
        protected override IMenuWrapper GetWrapper() {
            return new MenuWrapper( this );
        }
    }
}