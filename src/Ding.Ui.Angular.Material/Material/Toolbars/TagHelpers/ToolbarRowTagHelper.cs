﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Material.Toolbars.Renders;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.Toolbars.TagHelpers {
    /// <summary>
    /// 工具栏项
    /// </summary>
    [HtmlTargetElement( "util-toolbar-row" )]
    public class ToolbarRowTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ToolbarRowRender( new Config( context ) );
        }
    }
}