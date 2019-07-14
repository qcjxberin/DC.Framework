using Ding.Ui.Angular.Base;
using Ding.Ui.Builders;
using Ding.Ui.Configs;
using Ding.Ui.Enums;
using Ding.Ui.Zorro.Menus.Builders;

namespace Ding.Ui.Zorro.Menus.Renders {
    /// <summary>
    /// 菜单渲染器
    /// </summary>
    public class MenuRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化菜单渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public MenuRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new MenuBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigModel( builder );
            ConfigSelectable( builder );
            ConfigTheme( builder );
            ConfigInline( builder );
            ConfigEvents( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置模式
        /// </summary>
        private void ConfigModel( TagBuilder builder ) {
            builder.AddAttribute( "nzMode", _config.GetValue<MenuMode?>( UiConst.Mode )?.Description() );
        }

        /// <summary>
        /// 配置允许选中
        /// </summary>
        private void ConfigSelectable( TagBuilder builder ) {
            builder.AddAttribute( "[nzSelectable]", _config.GetBoolValue( UiConst.Selectable ) );
        }

        /// <summary>
        /// 配置主题
        /// </summary>
        private void ConfigTheme( TagBuilder builder ) {
            builder.AddAttribute( "nzTheme", _config.GetValue<MenuTheme?>( UiConst.Theme )?.Description() );
        }

        /// <summary>
        /// 配置内联
        /// </summary>
        private void ConfigInline( TagBuilder builder ) {
            builder.AddAttribute( "[nzInlineCollapsed]", _config.GetBoolValue( UiConst.InlineCollapsed ) );
            builder.AddAttribute( "[nzInlineIndent]", _config.GetValue( UiConst.InlineIndent ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(nzClick)", _config.GetValue( UiConst.OnClick ) );
        }
    }
}