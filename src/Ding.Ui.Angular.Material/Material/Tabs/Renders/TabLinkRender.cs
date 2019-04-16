﻿using Ding.Ui.Angular;
using Ding.Ui.Angular.Base;
using Ding.Ui.Builders;
using Ding.Ui.Configs;
using Ding.Ui.Material.Icons.Builders;
using Ding.Ui.Material.Tabs.Builders;

namespace Ding.Ui.Material.Tabs.Renders {
    /// <summary>
    /// 链接选项卡渲染器
    /// </summary>
    public class TabLinkRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化链接选项卡渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TabLinkRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TabLinkBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TabLinkBuilder builder ) {
            ConfigId( builder );
            builder.ConfigRouterLink( _config );
            ConfigLink( builder );
            ConfigCaption( builder );
            ConfigDisabled( builder );
        }

        /// <summary>
        /// 配置路由链接
        /// </summary>
        private void ConfigLink( TagBuilder builder ) {
            builder.AddAttribute( "routerLink", _config.GetValue( UiConst.Link ) );
            builder.AddAttribute( "[routerLink]", _config.GetValue( AngularConst.BindLink ) );
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        private void ConfigCaption( TagBuilder builder ) {
            ConfigMaterialIcon( builder );
            ConfigFontAwesomeIcon( builder );
            ConfigLabel( builder );
        }

        /// <summary>
        /// 配置Material图标
        /// </summary>
        private void ConfigMaterialIcon( TagBuilder builder ) {
            if( _config.Contains( UiConst.MaterialIcon ) == false )
                return;
            var iconBuilder = new MaterialIconBuilder();
            iconBuilder.SetIcon( _config );
            builder.AppendContent( iconBuilder );
        }

        /// <summary>
        /// 配置FontAwesome图标
        /// </summary>
        private void ConfigFontAwesomeIcon( TagBuilder builder ) {
            if( _config.Contains( UiConst.FontAwesomeIcon ) == false )
                return;
            var iconBuilder = new FontAwesomeIconBuilder();
            iconBuilder.SetIcon( _config );
            builder.AppendContent( iconBuilder );
        }

        /// <summary>
        /// 配置标签
        /// </summary>
        private void ConfigLabel( TagBuilder builder ) {
            if( _config.Contains( UiConst.Label ) == false )
                return;
            builder.AppendContent( _config.GetValue( UiConst.Label ) );
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        private void ConfigDisabled( TagBuilder builder ) {
            builder.AddAttribute( "[disabled]", _config.GetBoolValue( UiConst.Disabled ) );
        }
    }
}