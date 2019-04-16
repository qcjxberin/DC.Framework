using Ding.Ui.Components;
using Ding.Ui.Operations;
using Ding.Ui.Operations.Datas;
using Ding.Ui.Operations.Events;
using Ding.Ui.Operations.Forms;
using Ding.Ui.Operations.Layouts;

namespace Ding.Ui.Material.Lists {
    /// <summary>
    /// 选择列表
    /// </summary>
    public interface ISelectList : IComponent, IName, IDisabled, IModel, IOnChange, IColspan, IUrl, IDataSource, IItem,ILabel {
        /// <summary>
        /// 绑定枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        ISelectList Enum<TEnum>();
    }
}