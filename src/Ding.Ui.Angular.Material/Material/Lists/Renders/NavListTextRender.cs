using Ding.Ui.Angular.Base;
using Ding.Ui.Builders;
using Ding.Ui.Configs;
using Ding.Ui.Material.Lists.Builders;

namespace Ding.Ui.Material.Lists.Renders {
    /// <summary>
    /// 导航列表文本渲染器
    /// </summary>
    public class NavListTextRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化导航列表文本渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public NavListTextRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new NavListTextBuilder();
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