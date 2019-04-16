﻿using Ding.Ui.Components;
using Ding.Ui.Material.Tabs.Renders;
using Ding.Ui.Renders;

namespace Ding.Ui.Material.Tabs {
    /// <summary>
    /// 链接选项卡
    /// </summary>
    public class TabLink : ComponentBase, ITabLink {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new TabLinkRender( OptionConfig );
        }
    }
}