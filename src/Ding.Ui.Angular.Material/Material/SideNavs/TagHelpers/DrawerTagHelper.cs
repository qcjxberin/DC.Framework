﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.Angular.Base;
using Ding.Ui.Configs;
using Ding.Ui.Material.Enums;
using Ding.Ui.Material.SideNavs.Renders;
using Ding.Ui.Renders;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Material.SideNavs.TagHelpers {
    /// <summary>
    /// 侧边栏导航区域
    /// </summary>
    [HtmlTargetElement( "util-drawer" )]
    public class DrawerTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 位置
        /// </summary>
        public XPosition Position { get; set; }
        /// <summary>
        /// 是否打开
        /// </summary>
        public bool Opened { get; set; }
        /// <summary>
        /// 显示模式
        /// </summary>
        public SideNavMode Mode { get; set; }
        /// <summary>
        /// 禁用ESC键或点击背景关闭
        /// </summary>
        public bool DisableClose { get; set; }
        /// <summary>
        /// 宽度，单位：px
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new DrawerRender( new Config( context ) );
        }
    }
}