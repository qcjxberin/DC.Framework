﻿using Ding.Ui.Builders;

namespace Ding.Ui.Material.Panels.Builders {
    /// <summary>
    /// Mat面板生成器
    /// </summary>
    public class PanelBuilder : TagBuilder {
        /// <summary>
        /// 初始化面板生成器
        /// </summary>
        public PanelBuilder() : base( "mat-expansion-panel" ) {
        }
    }
}