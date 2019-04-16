using Ding.Ui.Angular.Base;
using Ding.Ui.Builders;
using Ding.Ui.Configs;
using Ding.Ui.Material.Tables.Builders;

namespace Ding.Ui.Material.Tables.Renders {
    /// <summary>
    /// 单元格渲染器
    /// </summary>
    public class CellRender : AngularRenderBase {
        /// <summary>
        /// 初始化单元格渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CellRender( IConfig config ) : base( config ) {
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new CellBuilder();
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