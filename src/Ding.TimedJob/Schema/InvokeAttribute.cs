using System;

namespace Ding.TimedJob.Schema
{
    public class InvokeAttribute : Attribute
    {
        /// <summary>
        /// 是否允许执行
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// 定时时间,默认24小时
        /// </summary>
        public int Interval { get; set; } = 1000 * 60 * 60 * 24; // 24 hours

        /// <summary>
        /// 当执行时是否跳过
        /// </summary>
        public bool SkipWhileExecuting { get; set; } = false;

        /// <summary>
        /// 设置开始时间
        /// </summary>
        public string Begin
        {
            get { return _begin.ToString(); }
            set { _begin = Convert.ToDateTime(value); }
        }

        public DateTime _begin { get; set; }
    }
}
