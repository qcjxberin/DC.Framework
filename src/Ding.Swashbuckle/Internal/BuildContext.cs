﻿using System;
using System.Collections.Generic;
using System.Linq;
using Ding.Swashbuckle.Attributes;
using Ding.Swashbuckle.Core.Groups;
using Ding.Swashbuckle.Extensions;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;

namespace Ding.Swashbuckle.Internal
{
    /// <summary>
    /// 构建上下文
    /// </summary>
    internal class BuildContext
    {
        /// <summary>
        /// Swagger扩展选项配置
        /// </summary>
        public SwaggerExtensionOptions Options { get; set; } = new SwaggerExtensionOptions();

        /// <summary>
        /// 服务提供程序
        /// </summary>
        public IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// 对象
        /// </summary>
        /// <param name="key">键</param>
        public object this[string key]
        {
            get => Items[key];
            set => Items[key] = value;
        }

        /// <summary>
        /// 对象字典
        /// </summary>
        public IDictionary<string, object> Items { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="TItem">类型</typeparam>
        /// <param name="key">键</param>
        public TItem GetItem<TItem>(string key) => (TItem)Items[key];

        /// <summary>
        /// 设置对象
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="item">项</param>
        public void SetItem(string key, object item) => Items[key] = item;

        /// <summary>
        /// 实例
        /// </summary>
        public static BuildContext Instance = new BuildContext();

        /// <summary>
        /// 构建
        /// </summary>
        public void Build()
        {
            BuildApiDoc();
        }

        /// <summary>
        /// 构建API文档
        /// </summary>
        private void BuildApiDoc()
        {
            var apiGroupContext = this.GetApiGroupContext();
            BuildSwaggerDoc(apiGroupContext);
            BuildSwaggerEndpoint(apiGroupContext);
            BuildDocInclusionPredicate(apiGroupContext);
        }

        /// <summary>
        /// 构建SwaggerDoc
        /// </summary>
        /// <param name="context">API分组上下文</param>
        private void BuildSwaggerDoc(ApiGroupContext context)
        {
            foreach (var info in context.GetInfos())
                this.Options.SwaggerGenOptions.SwaggerDoc(info.Key, info.Value);
        }

        /// <summary>
        /// 构建Swagger入口点
        /// </summary>
        /// <param name="context">API分组上下文</param>
        private void BuildSwaggerEndpoint(ApiGroupContext context)
        {
            foreach (var endpoint in context.GetEndpoints())
                this.Options.SwaggerUiOptions.AddInfo(endpoint.Key, endpoint.Value);
        }

        /// <summary>
        /// 构建Swagger入口选择
        /// </summary>
        /// <param name="context"></param>
        private void BuildDocInclusionPredicate(ApiGroupContext context)
        {
            BuildDocInclusionPredicateByApiGroup();
            BuildDocInclusionPredicateByApiVersion();
            BuildDocInclusionPredicateByApiVersionWithGroup();
        }

        /// <summary>
        /// 构建Swagger文档入口选择 - 根据分组
        /// </summary>
        private void BuildDocInclusionPredicateByApiGroup()
        {
            if (Options.EnableApiVersion)
                return;
            if (!Options.EnableApiGroup)
                return;
            Options.SwaggerGenOptions.DocInclusionPredicate((docName, apiDescription) =>
            {
                if (docName == "NoGroup")
                    return string.IsNullOrWhiteSpace(apiDescription.GroupName);
                foreach (var obj in apiDescription.ActionDescriptor.EndpointMetadata)
                {
                    if (!(obj is SwaggerApiGroupAttribute swaggerApiGroup))
                        continue;
                    if (swaggerApiGroup.GroupName == docName)
                        return true;
                }
                return false;
            });
        }

        /// <summary>
        /// 构建Swagger文档入口选择 - 根据API版本
        /// </summary>
        private void BuildDocInclusionPredicateByApiVersion()
        {
            if (Options.EnableApiGroup)
                return;
            if (!Options.EnableApiVersion)
                return;
            Options.SwaggerGenOptions.DocInclusionPredicate((docName, apiDescription) => docName == apiDescription.GroupName);
        }

        /// <summary>
        /// 构建Swagger文档入口选择 - 根据API版本以及分组
        /// </summary>
        private void BuildDocInclusionPredicateByApiVersionWithGroup()
        {
            if (!Options.EnableApiGroup)
                return;
            if (!Options.EnableApiVersion)
                return;
            Options.SwaggerGenOptions.DocInclusionPredicate((docName, apiDescription) =>
            {
                // 无分组处理
                if (docName.StartsWith("NoGroup"))
                {
                    if (ExistsApiGroupAttribute(apiDescription.ActionDescriptor))
                        return false;
                    if (docName == $"NoGroup{apiDescription.GroupName}")
                        return true;
                    return false;
                }
                // 有分组处理

                foreach (var obj in apiDescription.ActionDescriptor.EndpointMetadata)
                {
                    if (!(obj is SwaggerApiGroupAttribute swaggerApiGroup))
                        continue;
                    if ($"{swaggerApiGroup.GroupName}{apiDescription.GroupName}" == docName)
                        return true;
                }

                return false;
            });
        }

        /// <summary>
        /// 是否存在Api分组特性
        /// </summary>
        /// <param name="actionDescriptor">操作描述器</param>
        private bool ExistsApiGroupAttribute(ActionDescriptor actionDescriptor) => actionDescriptor.EndpointMetadata.OfType<SwaggerApiGroupAttribute>().Any();
    }
}