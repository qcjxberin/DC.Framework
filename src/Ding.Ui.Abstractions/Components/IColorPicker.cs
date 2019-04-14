using Ding.Ui.Operations;
using Ding.Ui.Operations.Bind;
using Ding.Ui.Operations.Events;
using Ding.Ui.Operations.Forms;

namespace Ding.Ui.Components {
    /// <summary>
    /// 颜色选择器
    /// </summary>
    public interface IColorPicker : IComponent, IName, IDisabled, IModel, IOnChange,
        IStandalone, IBindName {
    }
}