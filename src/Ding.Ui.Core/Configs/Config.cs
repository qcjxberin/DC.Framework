﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Ding.Ui.TagHelpers;

namespace Ding.Ui.Configs {
    /// <summary>
    /// 配置
    /// </summary>
    public class Config : IConfig {
        /// <summary>
        /// 类
        /// </summary>
        private readonly List<string> _classList;

        /// <summary>
        /// 初始化配置
        /// </summary>
        public Config() : this( null ) {
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        public Config( Context context ) {
            _classList = new List<string>();
            Load( context );
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="context">上下文</param>
        public void Load( Context context ) {
            if( context == null ) {
                AllAttributes = new TagHelperAttributeList();
                OutputAttributes = new TagHelperAttributeList();
                return;
            }
            AllAttributes = context.AllAttributes;
            OutputAttributes = context.OutputAttributes;
            Content = context.Content;
            Context = new TagHelperContext( AllAttributes, context.TagHelperContext.Items, context.TagHelperContext.UniqueId );
            Output = context.Output;
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="output">输出</param>
        public void Load( TagHelperContext context, TagHelperOutput output ) {
            Load( new Context( context, output, null ) );
        }

        /// <summary>
        /// 全部属性集合
        /// </summary>
        public TagHelperAttributeList AllAttributes { get; private set; }

        /// <summary>
        /// 输出属性集合，TagHelper中未明确定义的属性从该集合获取
        /// </summary>
        public TagHelperAttributeList OutputAttributes { get; private set; }

        /// <summary>
        /// 内容
        /// </summary>
        public TagHelperContent Content { get; set; }

        /// <summary>
        /// TagHelper上下文
        /// </summary>
        public TagHelperContext Context { get; private set; }

        /// <summary>
        /// TagHelper输出
        /// </summary>
        public TagHelperOutput Output { get; private set; }

        /// <summary>
        /// 属性集合是否包含指定属性
        /// </summary>
        /// <param name="name">属性名</param>
        public bool Contains( string name ) {
            return AllAttributes.ContainsName( name );
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="name">属性名</param>
        public string GetValue( string name ) {
            return Contains( name ) ? AllAttributes[name].Value.SafeString() : string.Empty;
        }

        /// <summary>
        /// 获取属性值，无值则返回null
        /// </summary>
        /// <param name="name">属性名</param>
        public string GetValueOrNull( string name ) {
            return Contains( name ) ? AllAttributes[name].Value.SafeString() : null;
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="name">属性名</param>
        public T GetValue<T>( string name ) {
            return Contains( name ) ? Ding.Helpers.Convert.To<T>( AllAttributes[name].Value ) : default( T );
        }

        /// <summary>
        /// 获取布尔属性值
        /// </summary>
        /// <param name="name">属性名</param>
        public string GetBoolValue( string name ) {
            return Ding.Helpers.String.FirstLowerCase( GetValue( name ) );
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">值</param>
        /// <param name="replaceExisting">是否替换已存在的属性</param>
        public void SetAttribute( string name, object value, bool replaceExisting = true ) {
            if( replaceExisting == false && Contains( name ) )
                return;
            AllAttributes.SetAttribute( new TagHelperAttribute( name, value ) );
        }

        /// <summary>
        /// 移除属性
        /// </summary>
        /// <param name="name">属性名</param>
        public void Remove( string name ) {
            AllAttributes.RemoveAll( name );
        }

        /// <summary>
        /// 添加类
        /// </summary>
        public void AddClass( string @class ) {
            if( string.IsNullOrWhiteSpace( @class ) )
                return;
            if( _classList.Contains( @class ) )
                return;
            _classList.Add( @class );
        }

        /// <summary>
        /// 获取类列表
        /// </summary>
        public List<string> GetClassList() {
            return _classList;
        }

        /// <summary>
        /// 是否验证
        /// </summary>
        public static bool IsValidate { get; set; } = true;

        /// <summary>
        /// 验证
        /// </summary>
        public string Validate() {
            if( IsValidate )
                return GetValidateMessage();
            return string.Empty;
        }

        /// <summary>
        /// 获取验证消息
        /// </summary>
        public virtual string GetValidateMessage() {
            return string.Empty;
        }
    }
}
