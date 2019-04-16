using System;
using Ding.Ui.Components;
using Ding.Ui.Operations.Navigation;

namespace Ding.Ui.Material.Buttons {
    /// <summary>
    /// 按钮
    /// </summary>
    public interface IButton : IComponent, IContainer<IDisposable>, Components.IButton, IMenuId {
    }
}