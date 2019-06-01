using Ding.Ui.Angular.Base;
using Ding.Ui.Angular.Builders;
using Ding.Ui.Builders;
using Ding.Ui.Configs;

namespace Ding.Ui.Angular.Renders {
    /// <summary>
    /// ng-container容器渲染器
    /// </summary>
    public class ContainerRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化ng-container容器渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ContainerRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new ContainerBuilder();
            ConfigId( builder );
            ConfigContent( builder );
            return builder;
        }
    }
}