#if __CORE__
using Ding.Tools.AspNetCore.Extensions;
using Ding.Tools.AspNetCore.ResumeFileResult;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Ding.Tools.AspNetCore.Executor
{
    /// <summary>
    /// 使用本地虚拟路径的可断点续传的FileResult
    /// </summary>
    internal class ResumeVirtualFileResultExecutor : VirtualFileResultExecutor, IActionResultExecutor<ResumeVirtualFileResult>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="loggerFactory"></param>
        /// <param name="hostingEnvironment"></param>
        public ResumeVirtualFileResultExecutor(ILoggerFactory loggerFactory, IHostingEnvironment hostingEnvironment) : base(loggerFactory, hostingEnvironment)
        {
        }

        /// <summary>
        /// 执行FileResult
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public virtual Task ExecuteAsync(ActionContext context, ResumeVirtualFileResult result)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            context.SetContentDispositionHeaderInline(result);

            return base.ExecuteAsync(context, result);
        }
    }
}
#endif