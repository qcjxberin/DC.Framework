using Ding.Ui.Angular.Base;
using Ding.Ui.Builders;
using Ding.Ui.Configs;
using Ding.Ui.Enums;
using Ding.Ui.Extensions;
using Ding.Ui.Zorro.Forms.Builders;
using Ding.Ui.Zorro.Grid.Configs;
using Ding.Ui.Zorro.Grid.Helpers;

namespace Ding.Ui.Zorro.Forms.Renders {
    /// <summary>
    /// 表单项渲染器
    /// </summary>
    public class FormItemRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表单项渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public FormItemRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new FormItemBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( FormItemBuilder builder ) {
            ConfigId( builder );
            ConfigGrid( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置栅格
        /// </summary>
        private void ConfigGrid( FormItemBuilder builder ) {
            ConfigGutter( builder );
            ConfigFlex( builder );
            ConfigAlign( builder );
            ConfigJustify( builder );
        }

        /// <summary>
        /// 配置间隔
        /// </summary>
        private void ConfigGutter( FormItemBuilder builder ) {
            builder.AddGutter( GridHelper.GetGutter( _config ) );
        }

        /// <summary>
        /// 配置浮动布局模式
        /// </summary>
        private void ConfigFlex( TagBuilder builder ) {
            var isFlex = _config.GetValue<bool?>( UiConst.IsFlex );
            if( isFlex == true )
                builder.AddAttribute( "[nzFlex]", "true" );
        }

        /// <summary>
        /// 配置对齐
        /// </summary>
        private void ConfigAlign( TagBuilder builder ) {
            if( _config.Contains( UiConst.Align ) == false )
                return;
            builder.AddAttribute( "nzType", "flex" );
            builder.AddAttribute( "nzAlign", _config.GetValue<Align?>( UiConst.Align )?.Description() );
        }

        /// <summary>
        /// 配置水平排列方式
        /// </summary>
        private void ConfigJustify( TagBuilder builder ) {
            if( _config.Contains( UiConst.Justify ) == false )
                return;
            builder.AddAttribute( "nzType", "flex" );
            builder.AddAttribute( "nzJustify", _config.GetValue<Justify?>( UiConst.Justify )?.Description() );
        }
    }
}
