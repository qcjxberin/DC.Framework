using System;

namespace Ding.Web.FPTemplate.Dynamic
{
    /// <summary>
    /// 动态执行方法委托
    /// </summary>
    /// <param name="container">对象</param>
    /// <param name="args">参数</param>
    /// <returns>返回结果（Void返回NULL）</returns>
    public delegate Object ExcuteMethodDelegate(Object container, Object[] args);
}
