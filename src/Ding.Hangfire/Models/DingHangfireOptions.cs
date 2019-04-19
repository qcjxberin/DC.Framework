using System;
using Ding.Interfaces;
using Hangfire;

namespace Ding.Hangfire.Models
{
    public class DingHangfireOptions : IDingOptions
    {
        /// <summary>
        ///     Disable or Enable Job Dashboard, default is false. 
        /// </summary>
        public bool IsDisableJobDashboard { get; set; }

        /// <summary>
        ///     Job Dashboard url, default is "/developers/job". 
        /// </summary>
        /// <remarks> Must start with "/" </remarks>
        public string Url { get; set; } = "/developers/job";

        /// <summary>
        ///     URL for back button in Job Dashboard. Set to <see langword="null" /> to hide the Back
        ///     To Site link, default is "/".
        /// </summary>
        public string BackToUrl { get; set; } = "/";

        /// <summary>
        ///     Access Key via uri param "key", default is "" - allow anonymous. 
        /// </summary>
        public string AccessKey { get; set; } = string.Empty;

        /// <summary>
        ///     Un-authorize message when user access Job Dashboard with not correct key. Default is
        ///     "You don't have permission to view API Document, please contact your administrator."
        /// </summary>
        public string UnAuthorizeMessage { get; set; } = "您无权访问Job Dashboard，请与您的管理员联系。";

        /// <summary>
        ///     Storage provider, default is Memory. 
        /// </summary>
        public HangfireProvider Provider { get; set; } = HangfireProvider.Memory;

        /// <summary>
        ///     Database Connection if <see cref="Provider " /> is <see cref="HangfireProvider.SqlServer" /> 
        /// </summary>
        public string HangfireDatabaseConnectionString { get; set; }

        /// <summary>
        ///     The interval the /stats endpoint should be polled with (milliseconds), default is 2000.
        /// </summary>
        public int StatsPollingInterval { get; set; } = 3000;

        /// <summary>
        ///     Additional Options if you want to add your customize after FivePower add Hangfire Global Config.
        /// </summary>
        public Action<IGlobalConfiguration, DingHangfireOptions> ExtendOptions { get; set; }

        #region Berin添加

        /// <summary>
        /// 任务调度文件地址
        /// </summary>
        public string JobJsonPath { get; set; }

        /// <summary>
        /// 指定的任务接口或类
        /// </summary>
        public Type[] JobTypes { get; set; }

        /// <summary>
        /// 后台作业服务器选项
        /// </summary>
        public BackgroundJobServerOptions JobServerOptions { get; set; }

        #endregion
    }
}
