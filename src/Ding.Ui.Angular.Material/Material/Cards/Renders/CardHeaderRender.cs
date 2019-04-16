using Ding.Ui.Angular.Base;
using Ding.Ui.Builders;
using Ding.Ui.Configs;
using Ding.Ui.Material.Cards.Builders;

namespace Ding.Ui.Material.Cards.Renders {
    /// <summary>
    /// 卡片头部渲染器
    /// </summary>
    public class CardHeaderRender : AngularRenderBase {
        /// <summary>
        /// 初始化卡片头部渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CardHeaderRender( IConfig config ) : base( config ) {
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new CardHeaderBuilder();
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