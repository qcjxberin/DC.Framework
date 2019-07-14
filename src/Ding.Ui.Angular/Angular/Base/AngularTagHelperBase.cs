using Ding.Ui.TagHelpers;

namespace Ding.Ui.Angular.Base {
    /// <summary>
    /// angular TagHelper基类
    /// </summary>
    public abstract class AngularTagHelperBase : TagHelperBase {
        /// <summary>
        /// id,标签的Id属性
        /// </summary>
        public string RawId { get; set; }
        /// <summary>
        /// *ngIf
        /// </summary>
        public string NgIf { get; set; }
        /// <summary>
        /// *ngFor,范例：let item of items
        /// </summary>
        public string NgFor { get; set; }
        /// <summary>
        /// ngClass指令
        /// </summary>
        public string NgClass { get; set; }
    }
}