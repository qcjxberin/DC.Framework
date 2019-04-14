using Ding.Ui.Operations;
using Ding.Ui.Operations.Events;
using Ding.Ui.Operations.Navigation;
using Ding.Ui.Operations.Styles;

namespace Ding.Ui.Components {
    /// <summary>
    /// 链接
    /// </summary>
    public interface IAnchor : IComponent, ILink, IText, IDisabled, IColor, ITooltip, IButtonStyle, IOnClick {
    }
}
