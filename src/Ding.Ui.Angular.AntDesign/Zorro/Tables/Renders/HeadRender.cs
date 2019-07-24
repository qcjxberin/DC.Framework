using Ding.Ui.Angular.Base;
using Ding.Ui.Builders;
using Ding.Ui.Configs;
using Ding.Ui.Zorro.Tables.Builders;
using Ding.Ui.Zorro.Tables.Configs;

namespace Ding.Ui.Zorro.Tables.Renders {
    /// <summary>
    /// 表格头渲染器
    /// </summary>
    public class HeadRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表格头渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public HeadRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TableHeadBuilder();
            ConfigHead( builder );
            var rowBuilder = new TableRowBuilder();
            builder.AppendContent( rowBuilder );
            ConfigRow( rowBuilder );
            return builder;
        }

        /// <summary>
        /// 配置thead
        /// </summary>
        private void ConfigHead( TableHeadBuilder builder ) {
            AddSortChange( builder );
        }

        /// <summary>
        /// 添加排序变更事件处理
        /// </summary>
        private void AddSortChange( TableHeadBuilder builder ) {
            if( _config.Contains( UiConst.OnSortChange ) ) {
                builder.AddSortChange( _config.GetValue( UiConst.OnSortChange ) );
                return;
            }
            var shareConfig = GetShareConfig();
            if ( shareConfig == null )
                return;
            if ( shareConfig.IsSort == false )
                return;
            builder.AddSortChange( $"{shareConfig.TableWrapperId}.sort($event)" );
        }

        /// <summary>
        /// 获取共享配置
        /// </summary>
        private TableShareConfig GetShareConfig() {
            return _config.GetValueFromItems<TableShareConfig>();
        }

        /// <summary>
        /// 配置tr
        /// </summary>
        private void ConfigRow( TableRowBuilder builder ) {
            InitBuilder( builder );
            ConfigId( builder );
            ConfigContent( builder );
        }
    }
}