using Ding.Ui.Angular.Base;
using Ding.Ui.Builders;
using Ding.Ui.Configs;
using Ding.Ui.Zorro.Forms.Builders;

namespace Ding.Ui.Zorro.Forms.Renders {
    /// <summary>
    /// 表单控件渲染器
    /// </summary>
    public class FormControlRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表单控件渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public FormControlRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new FormControlBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( FormControlBuilder builder ) {
            ConfigId( builder );
            ConfigGrid( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置栅格
        /// </summary>
        private void ConfigGrid( FormControlBuilder builder ) {
            builder.AddLayout( _config );
            ConfigOffset( builder );
        }

        /// <summary>
        /// 配置偏移量
        /// </summary>
        private void ConfigOffset( TagBuilder builder ) {
            builder.AddAttribute( "[nzOffset]", _config.GetValue( UiConst.Offset ) );
        }
    }
}
