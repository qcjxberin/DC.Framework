using System;
using System.IO;

namespace Ding.Web.FPTemplate
{
    /// <summary>
    /// Template 接口
    /// </summary>
    public interface ITemplate
    {
        /// <summary>
        /// 模板上下文
        /// </summary>
        TemplateContext Context { get; set; }
        /// <summary>
        /// 模板内容
        /// </summary>
        String TemplateContent { get; set; }
        /// <summary>
        /// 结果呈现
        /// </summary>
        /// <param name="writer"></param>
        void Render(TextWriter writer);
    }
}