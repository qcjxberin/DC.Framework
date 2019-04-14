using Ding.Ui.Operations;
using Ding.Ui.Operations.Bind;
using Ding.Ui.Operations.Datas;
using Ding.Ui.Operations.Events;
using Ding.Ui.Operations.Forms;
using Ding.Ui.Operations.Forms.Validations;
using Ding.Ui.Operations.Layouts;

namespace Ding.Ui.Components {
    /// <summary>
    /// 单选框
    /// </summary>
    public interface IRadio : IComponent, IName, ILabel, IDisabled, IModel, IRequired, IOnChange, ILabelPosition, IUrl, IDataSource, IItem, IColspan,
        IStandalone, IBindName {
        /// <summary>
        /// 绑定枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        IRadio Enum<TEnum>();
    }
}
