﻿using System.IO;
using System.Text.Encodings.Web;
using Ding.Ui.Angular.Base;
using Ding.Ui.Angular.Builders;
using Ding.Ui.Builders;
using Ding.Ui.Configs;
using Ding.Ui.Material.Tabs.Builders;

namespace Ding.Ui.Material.Tabs.Renders {
    /// <summary>
    /// 导航选项卡渲染器
    /// </summary>
    public class TabNavRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;
        /// <summary>
        /// router-outlet生成器
        /// </summary>
        private readonly RouterOutletBuilder _routerOutletBuilder;

        /// <summary>
        /// 初始化导航选项卡渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TabNavRender( IConfig config ) : base( config ) {
            _config = config;
            _routerOutletBuilder = new RouterOutletBuilder();
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public override void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            InitBuilder( Builder );
            Builder.WriteTo( writer, encoder );
            _routerOutletBuilder.WriteTo( writer, encoder );
        }

        /// <summary>
        /// 渲染结束标签
        /// </summary>
        /// <param name="writer">流写入器</param>
        public override void RenderEndTag( TextWriter writer ) {
            Builder.RenderEndTag( writer );
            _routerOutletBuilder.WriteTo( writer, HtmlEncoder.Default );
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TabNavBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigContent( builder );
            ConfigColor( builder );
        }

        /// <summary>
        /// 配置颜色
        /// </summary>
        private void ConfigColor( TagBuilder builder ) {
            builder.AddAttribute( "backgroundColor", _config.GetValue( UiConst.BackgroundColor )?.ToLower() );
            builder.AddAttribute( "color", _config.GetValue( UiConst.Color )?.ToLower() );
        }
    }
}