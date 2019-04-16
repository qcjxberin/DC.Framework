﻿using Ding.Ui.Angular.Base;
using Ding.Ui.Builders;
using Ding.Ui.Configs;
using Ding.Ui.Material.Tables.Builders;

namespace Ding.Ui.Material.Tables.Renders {
    /// <summary>
    /// 列头渲染器
    /// </summary>
    public class HeaderCellRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化列头渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public HeaderCellRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new HeaderCellBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigTitle( builder );
            ConfigSort( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        private void ConfigTitle( TagBuilder builder ) {
            if ( _config.Contains( UiConst.Title ) == false )
                return;
            builder.AppendContent( _config.GetValue( UiConst.Title ) );
        }

        /// <summary>
        /// 配置排序
        /// </summary>
        private void ConfigSort( TagBuilder builder ) {
            if( _config.GetValue<bool?>( UiConst.Sort ) != true )
                return;
            builder.AddAttribute( "mat-sort-header" );
        }
    }
}