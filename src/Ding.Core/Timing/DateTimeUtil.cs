using System;
using System.Globalization;

namespace Ding.Core.Timing
{
    /// <summary>
    /// 时间操作辅助类
    /// </summary>
    public static class DateTimeUtil
    {
        #region PHP时间转换
        /// <summary>
        /// PHP时间值
        /// </summary>
        /// <returns></returns>
        public static long PHP_Time()
        {
            DateTime time = new DateTime(0x7b2, 1, 1);
            return ((DateTime.UtcNow.Ticks - time.Ticks) / 0x989680L);
        }

        /// <summary>
        /// PHP时间转移为普通时间
        /// </summary>
        /// <returns></returns>
        public static DateTime PHPTOCTime(long time)
        {
            DateTime timeStamp = new DateTime(1970, 1, 1);  //得到1970年的时间戳
            long t = (time + 8 * 60 * 60) * 10000000 + timeStamp.Ticks;
            DateTime dt = new DateTime(t);
            return dt;
        }
        #endregion
    }
}
