using Ding.Ui.Operations;
using Ding.Ui.Operations.Bind;
using Ding.Ui.Operations.Events;
using Ding.Ui.Operations.Forms;
using Ding.Ui.Operations.Forms.Validations;
using Ding.Ui.Operations.Layouts;
using Ding.Ui.Operations.Styles;

namespace Ding.Ui.Components {
    /// <summary>
    /// 复选框
    /// </summary>
    public interface ICheckBox : IComponent, IName, ILabel, IDisabled, IModel, IRequired, IOnChange, ILabelPosition,IColor, IColspan, 
        IStandalone, IBindName {
    }
}
