using System;
using Ding.Ui.Components;
using Ding.Ui.Operations;

namespace Ding.Ui.Material.Tabs {
    /// <summary>
    /// 选项卡
    /// </summary>
    public interface ITab : IContainer<IDisposable>, ILabel, ISetIcon,IDisabled {
    }
}