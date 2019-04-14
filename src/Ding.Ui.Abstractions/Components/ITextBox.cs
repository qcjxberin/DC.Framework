using Ding.Ui.Operations.Forms;
using Ding.Ui.Operations.Forms.Validations;

namespace Ding.Ui.Components {
    /// <summary>
    /// 文本框
    /// </summary>
    public interface ITextBox : IFormControl, IReadOnly, IMinLength, IMaxLength,IMin,IMax, IRegex {
    }
}
