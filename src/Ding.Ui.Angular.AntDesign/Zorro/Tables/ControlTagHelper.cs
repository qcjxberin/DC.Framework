using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;
using Ding.Ui.Zorro.Tables.Configs;
using Ding.Ui.Zorro.Tables.Renders;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ding.Ui.Zorro.Tables {
    /// <summary>
    /// 表格编辑列控件
    /// </summary>
    [HtmlTargetElement( "util-table-column-control", ParentTag = "util-table-column" )]
    public class ControlTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表格列定义
        /// </summary>
        public ControlTagHelper() {
            _config = new Config();
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ControlRender( _config );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">上下文</param>
        protected override void ProcessBefore( Context context ) {
            _config.Load( context );
            SetTableShareConfig();
            SetColumnShareConfig();
        }

        /// <summary>
        /// 设置表格共享配置
        /// </summary>
        private void SetTableShareConfig() {
            var config = _config.GetValueFromItems<TableShareConfig>();
            if ( config == null )
                return;
            config.IsEdit = true;
        }

        /// <summary>
        /// 设置列共享配置
        /// </summary>
        private void SetColumnShareConfig() {
            var config = _config.GetValueFromItems<ColumnShareConfig>();
            if( config == null )
                return;
            config.IsEdit = true;
            config.IsCreateControl = false;
        }
    }
}