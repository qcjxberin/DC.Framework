using Ding.Ui.Operations;
using Ding.Ui.Operations.Events;
using Ding.Ui.Operations.Styles;

namespace Ding.Ui.Components {
    /// <summary>
    /// 按钮
    /// </summary>
    public interface IButton : IText, IDisabled, IColor, ITooltip, IButtonStyle, IOnClick {
    }
}
