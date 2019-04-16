﻿using Ding.Ui.Angular.Base;
using Ding.Ui.Builders;
using Ding.Ui.Configs;
using Ding.Ui.Material.Panels.Builders;

namespace Ding.Ui.Material.Panels.Renders {
    /// <summary>
    /// 面板标题渲染器
    /// </summary>
    public class PanelTitleRender : AngularRenderBase {
        /// <summary>
        /// 初始化面板标题渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public PanelTitleRender( IConfig config ) : base( config ) {
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new PanelTitleBuilder();
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