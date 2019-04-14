using Ding.Ui.Operations;
using Ding.Ui.Operations.Bind;
using Ding.Ui.Operations.Events;
using Ding.Ui.Operations.Forms;
using Ding.Ui.Operations.Forms.Validations;
using Ding.Ui.Operations.Layouts;

namespace Ding.Ui.Components {
    /// <summary>
    /// 表单控件
    /// </summary>
    public interface IFormControl : IComponent,IName,IDisabled, IPlaceholder, IHint, IPrefix, ISuffix, IModel, 
        IRequired, IOnChange, IOnFocus, IOnBlur, IOnKeyup, IOnKeydown, IColspan, IStandalone,
        IBindName {
    }
}