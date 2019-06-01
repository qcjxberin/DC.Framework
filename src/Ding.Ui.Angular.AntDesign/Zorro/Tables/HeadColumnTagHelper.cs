﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Angular.Enums;
using Ding.Ui.Configs;
using Ding.Ui.Extensions;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;
using Ding.Ui.Zorro.Tables.Configs;
using Ding.Ui.Zorro.Tables.Renders;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Ding.Ui.Angular.Resolvers;

namespace Ding.Ui.Zorro.Tables {
    /// <summary>
    /// 表格标题列定义，该标签应放在 util-table-head 中
    /// </summary>
    [HtmlTargetElement( "util-table-head-column",ParentTag = "util-table-head" )]
    public class HeadColumnTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表格标题列定义
        /// </summary>
        public HeadColumnTagHelper() {
            _config = new Config();
        }

        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 表格列类型
        /// </summary>
        public TableColumnType Type { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 宽度，默认单位：px，范例：100，表示100px，也可以使用百分比，范例：10%
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            _config.Content = context.Content;
            return new HeadColumnRender( _config );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        /// <param name="output">TagHelper输出</param>
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config.Load( context, output );
            ResolveExpression();
            SetShareConfig();
        }

        /// <summary>
        /// 解析属性表达式
        /// </summary>
        private void ResolveExpression() {
            if( _config.Contains( UiConst.For ) == false )
                return;
            var expression = _config.GetValue<ModelExpression>( UiConst.For );
            ColumnExpressionResolver.Init( expression, _config );
        }

        /// <summary>
        /// 设置共享配置
        /// </summary>
        private void SetShareConfig() {
            var shareConfig = _config.Context.GetValueFromItems<TableShareConfig>( TableConfig.TableShareKey );
            if ( shareConfig == null )
                return;
            SetAutoCreateSort( shareConfig );
        }

        /// <summary>
        /// 设置自动创建排序列
        /// </summary>
        private void SetAutoCreateSort( TableShareConfig config ) {
            if( _config.Context.GetValueFromAttributes<string>( UiConst.Sort ).IsEmpty() )
                return;
            config.AutoCreateSort = false;
            config.IsSort = true;
        }
    }
}