using System;

namespace Ding.Web.FPTemplate
{
    /// <summary>
    /// 方法标签委托
    /// </summary>
    /// <param name="args">方法参数</param>
    /// <returns>Object</returns>
    public delegate Object FuncHandler(params Object[] args);
}