using Ding.Ui.Components;
using Ding.Ui.Operations;
using Ding.Ui.Operations.Events;
using Ding.Ui.Operations.Navigation;

namespace Ding.Ui.Material.Menus {
    /// <summary>
    /// 菜单项
    /// </summary>
    public interface IMenuItem : IComponent,ILabel,ISetIcon,IDisabled,ILink,IOnClick, IMenuId {
    }
}