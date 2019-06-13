#if __CORE__
using Ding.Tools.AspNetCore.Extensions;
using Ding.Tools.AspNetCore.ResumeFileResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Ding.Tools.AspNetCore.Executor
{
    /// <summary>
    /// 断点续传文件FileResult执行器
    /// </summary>
    internal class ResumeFileContentResultExecutor : FileContentResultExecutor, IActionResultExecutor<ResumeFileContentResult>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="loggerFactory"></param>
        public ResumeFileContentResultExecutor(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        /// <summary>
        /// 执行Result
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public virtual Task ExecuteAsync(ActionContext context, ResumeFileContentResult result)
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