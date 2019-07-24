using Ding.Ui.Angular.Base;
using Ding.Ui.Builders;
using Ding.Ui.Configs;
using Ding.Ui.Zorro.Tables.Builders;
using Ding.Ui.Zorro.Tables.Configs;

namespace Ding.Ui.Zorro.Tables.Renders {
    /// <summary>
    /// 表格编辑列显示内容渲染器
    /// </summary>
    public class DisplayRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表格编辑列显示内容渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public DisplayRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var config = _config.GetValueFromItems<ColumnShareConfig>();
            var builder = EditColumnBuilderBase.CreateContainerBuilder( config?.EditTableId, config?.TemplateId );
            ConfigContent( builder );
            return builder;
        }
    }
}