﻿using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace Ding.Swashbuckle.Filters.Documents
{
    /// <summary>
    /// 首字母小写Url 文档过滤器
    /// </summary>
    public class FirstLowercaseUrlDocumentFilter : IDocumentFilter
    {
        /// <summary>
        /// 重写操作处理
        /// </summary>
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Paths = swaggerDoc.Paths.ToDictionary(entry => FirstLowerEverythingButParameters(entry.Key),
                entry => entry.Value);
        }

        /// <summary>
        /// 除参数为，任何值首字母小写
        /// </summary>
        private static string FirstLowerEverythingButParameters(string key) => string.Join("/", key.Split('/').Select(x => x.Contains("{") ? x : FirstLower(x)));

        /// <summary>
        /// 首字母小写
        /// </summary>
        private static string FirstLower(string value) => string.IsNullOrWhiteSpace(value) ? string.Empty : $"{value.Substring(0, 1).ToLower()}{value.Substring(1)}";
    }
}
