﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Material.Grids.Renders;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.Grids.TagHelpers {
    /// <summary>
    /// 网格列
    /// </summary>
    [HtmlTargetElement( "util-grid-column" )]
    public class GridColumnTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 合并列
        /// </summary>
        public int Colspan { get; set; }
        /// <summary>
        /// 合并行
        /// </summary>
        public int Rowspan { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new GridColumnRender( new Config( context ) );
        }
    }
}