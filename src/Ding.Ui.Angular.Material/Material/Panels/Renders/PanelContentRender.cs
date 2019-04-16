using Ding.Ui.Angular.Base;
using Ding.Ui.Angular.Builders;
using Ding.Ui.Builders;
using Ding.Ui.Configs;

namespace Ding.Ui.Material.Panels.Renders {
    /// <summary>
    /// 面板内容渲染器
    /// </summary>
    public class PanelContentRender : AngularRenderBase {
        /// <summary>
        /// 初始化面板内容渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public PanelContentRender( IConfig config ) : base( config ) {
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TemplateBuilder();
            builder.AddAttribute( "matExpansionPanelContent" );
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigContent( builder );
        }
    }
}