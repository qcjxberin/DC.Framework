using Ding.Ui.Configs;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.Icons.Configs {
    /// <summary>
    /// 图标配置
    /// </summary>
    public class IconConfig : Config {
        /// <summary>
        /// 初始化图标配置
        /// </summary>
        public IconConfig() {
        }

        /// <summary>
        /// 初始化图标配置
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        public IconConfig( Context context ) : base( context ) {
        }

        /// <summary>
        /// 验证
        /// </summary>
        public override string GetValidateMessage() {
            if ( !Contains( UiConst.FontAwesomeIcon ) && !Contains( UiConst.MaterialIcon ) )
                return "请设置FontAwesome或Material属性";
            return string.Empty;
        }
    }
}
