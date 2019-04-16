using Ding.Ui.Components;
using Ding.Ui.Extensions;
using Ding.Ui.Material.Extensions;
using Ding.Ui.Material.Menus.Datas;
using Ding.Ui.Material.Menus.Renders;
using Ding.Ui.Renders;

namespace Ding.Ui.Material.Menus {
    /// <summary>
    /// 菜单项
    /// </summary>
    public class MenuItem : ComponentBase, IMenuItem {
        /// <summary>
        /// 初始化菜单项
        /// </summary>
        public MenuItem() {
        }

        /// <summary>
        /// 初始化菜单项
        /// </summary>
        /// <param name="data">菜单项数据</param>
        public MenuItem( MenuItemData data ) {
            this.Label( data.Label ).Icon( data.FontAwesomeIcon ).Icon( data.MaterialIcon )
                .Disable( data.Disabled ).Link( data.Link ).OnClick( data.OnClick ).Menu( data.MenuId );
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new MenuItemRender( OptionConfig );
        }
    }
}