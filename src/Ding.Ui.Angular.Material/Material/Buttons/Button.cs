using System;
using System.IO;
using Ding.Ui.Components;
using Ding.Ui.Configs;
using Ding.Ui.Material.Buttons.Configs;
using Ding.Ui.Material.Buttons.Renders;
using Ding.Ui.Renders;

namespace Ding.Ui.Material.Buttons {
    /// <summary>
    /// 按钮
    /// </summary>
    public class Button : ContainerBase<IDisposable>, IButton {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly ButtonConfig _config;

        /// <summary>
        /// 初始化按钮
        /// </summary>
        /// <param name="writer">流写入器</param>
        public Button( TextWriter writer ) : base( writer ) {
            _config = new ButtonConfig();
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        protected override IConfig GetConfig() {
            return _config;
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            if( _config.UseButtonRender() )
                return new ButtonRender( _config );
            return new ButtonWrapperRender( _config );
        }

        /// <summary>
        /// 获取容器包装器
        /// </summary>
        protected override IDisposable GetWrapper() {
            return new ContainerWrapper( this );
        }
    }
}