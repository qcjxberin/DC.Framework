// Copyright (c) 深圳云企微商网络科技有限公司. All Rights Reserved.
// 丁川 QQ：2505111990 微信：i230760 qq群:774046050 邮箱:2505111990@qq.com
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace PushNuget
{
    using System.ComponentModel;
    using HaoCoding.Xml;

    /// <summary>
    /// Nuget上传设置
    /// </summary>
    [DisplayName("Nuget上传设置")]
    [XmlConfigFile(@"Config\Nuget.config", 15_000)]
    public class Setting : XmlConfig<Setting>
    {
        /// <summary>
        /// Nuget密钥
        /// </summary>
        [Description("Nuget密钥")]
        public string Key { get; set; } = "oy2bgjipflkutt4wcdgaoa4judpw235udho5jqpxgyzxiy";

        /// <summary>
        /// Nuget地址
        /// </summary>
        [Description("Nuget地址")]
        public string Source { get; set; } = "https://api.nuget.org/v3/index.json";
    }
}
