using Ding.Helpers;
using Ding.Ui.Angular;
using Ding.Ui.Angular.Base;
using Ding.Ui.Angular.Builders;
using Ding.Ui.Builders;
using Ding.Ui.Configs;
using Ding.Ui.Enums;
using Ding.Ui.Extensions;
using Ding.Ui.Zorro.Messages.Builders;

namespace Ding.Ui.Zorro.Messages.Renders {
    /// <summary>
    /// 警告提示渲染器
    /// </summary>
    public class AlertRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化警告提示渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public AlertRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new AlertBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigType( builder );
            ConfigShowIcon( builder );
            ConfigMessage( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置警告提示样式
        /// </summary>
        private void ConfigType( TagBuilder builder ) {
            builder.AddAttribute( "nzType", _config.GetValue<AlertType?>( UiConst.Type )?.Description() );
        }

        /// <summary>
        /// 配置显示图标
        /// </summary>
        private void ConfigShowIcon( TagBuilder builder ) {
            builder.AddAttribute( "[nzShowIcon]", _config.GetBoolValue( UiConst.ShowIcon ) );
        }

        /// <summary>
        /// 配置消息
        /// </summary>
        private void ConfigMessage( TagBuilder builder ) {
            builder.AddAttribute( "nzMessage", _config.GetValue( UiConst.Message ) );
            builder.AddAttribute( "[nzMessage]", _config.GetValue( AngularConst.BindMessage ) );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent( TagBuilder builder ) {
            if( _config.Content.IsEmpty() )
                return;
            var id = $"m_{Id.Guid()}";
            builder.AddAttribute( "[nzMessage]", id );
            var templateBuilder = new TemplateBuilder();
            templateBuilder.AddAttribute( $"#{id}" );
            templateBuilder.AppendContent( _config.Content );
            builder.AppendContent( templateBuilder );
        }
    }
}