﻿using Ding.Properties;
using Ding.Ui.Angular.Base;
using Ding.Ui.Angular.Enums;
using Ding.Ui.Configs;
using Ding.Ui.Extensions;
using Ding.Ui.Zorro.Tables.Builders;
using Ding.Ui.Zorro.Tables.Configs;

namespace Ding.Ui.Zorro.Tables.Renders {
    /// <summary>
    /// 列渲染器
    /// </summary>
    public class ColumnRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化列渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ColumnRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override Ding.Ui.Builders.TagBuilder GetTagBuilder() {
            var builder = new TableColumnBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TableColumnBuilder builder ) {
            ConfigId( builder );
            ConfigColumn( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置列
        /// </summary>
        private void ConfigColumn( TableColumnBuilder builder ) {
            var type = _config.GetValue<TableColumnType?>( UiConst.Type );
            var column = _config.GetValue( UiConst.Column );
            switch( type ) {
                case TableColumnType.LineNumber:
                    AddLineNumber( builder );
                    return;
                case TableColumnType.Checkbox:
                    AddCheckbox( builder );
                    return;
                case TableColumnType.Bool:
                    AddBoolColumn( builder, column );
                    return;
                case TableColumnType.Date:
                    AddDateColumn( builder, column );
                    return;
                default:
                    AddDefaultColumn( builder, column );
                    return;
            }
        }

        /// <summary>
        /// 添加序号
        /// </summary>
        private void AddLineNumber( TableColumnBuilder builder ) {
            if( _config.GetValue<TableColumnType?>( UiConst.Type ) != TableColumnType.LineNumber )
                return;
            builder.AppendContent( "{{row.lineNumber}}" );
        }

        /// <summary>
        /// 添加复选框
        /// </summary>
        private void AddCheckbox( TableColumnBuilder builder ) {
            if( _config.GetValue<TableColumnType?>( UiConst.Type ) != TableColumnType.Checkbox )
                return;
            var tableId = _config.Context.GetValueFromItems<TableShareConfig>( TableConfig.TableShareKey )?.TableId;
            builder.AddAttribute( "nzShowCheckbox" );
            builder.AddAttribute( "(click)", "$event.stopPropagation()" );
            builder.AddAttribute( "(nzCheckedChange)", $"{tableId}_wrapper.checkedSelection.toggle(row)" );
            builder.AddAttribute( "[nzChecked]", $"{tableId}_wrapper.checkedSelection.isSelected(row)" );
        }

        /// <summary>
        /// 添加布尔类型列
        /// </summary>
        private void AddBoolColumn( TableColumnBuilder builder, string column ) {
            if( column.IsEmpty() )
                return;
            builder.AppendContent( $"{{{{row.{column}?'{R.Yes}':'{R.No}'}}}}" );
        }

        /// <summary>
        /// 添加日期类型列
        /// </summary>
        private void AddDateColumn( TableColumnBuilder builder, string column ) {
            if( column.IsEmpty() )
                return;
            var format = _config.GetValue( UiConst.DateFormat );
            if( string.IsNullOrWhiteSpace( format ) )
                format = "yyyy-MM-dd";
            builder.AppendContent( $"{{{{ row.{column} | date:\"{format}\" }}}}" );
        }

        /// <summary>
        /// 添加默认列
        /// </summary>
        private void AddDefaultColumn( TableColumnBuilder builder, string column ) {
            if( column.IsEmpty() )
                return;
            var length = _config.GetValue<int?>( UiConst.Truncate );
            if( length == null ) {
                builder.AppendContent( $"{{{{row.{column}}}}}" );
                return;
            }
            builder.Truncate( column, length.SafeValue() );
        }
    }
}