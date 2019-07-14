using Ding.Helpers;
using Ding.Ui.Angular;
using Ding.Ui.Angular.Base;
using Ding.Ui.Angular.Builders;
using Ding.Ui.Builders;
using Ding.Ui.Configs;
using Ding.Ui.Enums;
using Ding.Ui.Extensions;
using Ding.Ui.Zorro.Tabs.Builders;

namespace Ding.Ui.Zorro.Tabs.Renders {
    /// <summary>
    /// 标签页渲染器
    /// </summary>
    public class TabSetRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化标签页渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TabSetRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TabSetBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigSelectedIndex( builder );
            ConfigEvents( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置选项卡的索引
        /// </summary>
        private void ConfigSelectedIndex( TagBuilder builder ) {
            builder.AddAttribute( "[nzSelectedIndex]", _config.GetValue( UiConst.SelectedIndex ) );
            builder.AddAttribute( "[(nzSelectedIndex)]", _config.GetValue( AngularConst.BindOnSelectedIndex ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(nzSelectedIndexChange)", _config.GetValue( UiConst.OnSelectedIndexChange ) );
        }
    }
}