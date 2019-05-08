using System;
using System.Globalization;

namespace Ding.Timing
{
    /// <summary>
    /// 时间操作辅助类
    /// </summary>
    public static class DateTimeUtil
    {
        #region GetDays(获取总天数)

        /// <summary>
        /// 获取指定年的总天数
        /// </summary>
        /// <param name="year">指定年</param>
        /// <returns></returns>
        public static int GetDays(int year)
        {
            return GetDays(year, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// 获取指定年的总天数，使用指定区域性
        /// </summary>
        /// <param name="year">指定年</param>
        /// <param name="culture">指定区域性</param>
        /// <returns></returns>
        public static int GetDays(int year, CultureInfo culture)
        {
            var first = new DateTime(year, 1, 1, culture.Calendar);
            var last = new DateTime(year + 1, 1, 1, culture.Calendar);
            return GetDays(first, last);
        }

        /// <summary>
        /// 获取指定时间的年的总天数
        /// </summary>
        /// <param name="date">指定时间</param>
        /// <returns></returns>
        public static int GetDays(DateTime date)
        {
            return GetDays(date.Year, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// 获取两个时间之间的天数
        /// </summary>
        /// <param name="fromDate">开始时间</param>
        /// <param name="toDate">结束时间</param>
        /// <returns></returns>
        public static int GetDays(DateTime fromDate, DateTime toDate)
        {
            return Convert.ToInt32(toDate.Subtract(fromDate).TotalDays);
        }

        #endregion

        #region CalculateAge(计算年龄)

        /// <summary>
        /// 计算年龄
        /// </summary>
        /// <param name="dateOfBirth">出生日期</param>
        /// <returns></returns>
        public static int CalculateAge(DateTime dateOfBirth)
        {
            return CalculateAge(dateOfBirth, DateTime.Now.Date);
        }

        /// <summary>
        /// 计算年龄，指定参考日期
        /// </summary>
        /// <param name="dateOfBirth">出生日期</param>
        /// <param name="referenceDate">参考日期</param>
        /// <returns></returns>
        public static int CalculateAge(DateTime dateOfBirth, DateTime referenceDate)
        {
            var years = referenceDate.Year - dateOfBirth.Year;
            if (referenceDate.Month < dateOfBirth.Month ||
                (referenceDate.Month == dateOfBirth.Month && referenceDate.Day < dateOfBirth.Day))
            {
                --years;
            }
            return years;
        }
        #endregion

        #region BusinessDateFormat(业务时间格式化)
        /// <summary>
        /// 业务时间格式化，返回 xxx前
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <returns></returns>
        public static string BusinessDateFormat(DateTime dateTime)
        {
            TimeSpan span = (DateTime.Now - dateTime).Duration();
            if (span.TotalDays > 60)
            {
                return dateTime.ToString("yyyy-MM-dd");
            }
            if (span.TotalDays > 30)
            {
                return "1个月前";
            }
            if (span.TotalDays > 14)
            {
                return "2周前";
            }
            if (span.TotalDays > 7)
            {
                return "1周前";
            }
            if (span.TotalDays > 1)
            {
                return $"{(int)Math.Floor(span.TotalDays)}天前";
            }
            if (span.TotalHours > 1)
            {
                return $"{(int)Math.Floor(span.TotalHours)}小时前";
            }
            if (span.TotalMinutes > 1)
            {
                return $"{(int)Math.Floor(span.TotalMinutes)}秒前";
            }
            return "1秒前";
        }

        #endregion

        #region 格式化日期时间,0(yyyy-MM-dd),1(yyyy-MM-dd HH:mm:ss),2(yyyy/MM/dd),3(yyyy年MM月dd日),4(MM-dd),5(MM/dd),6(MM月dd日),7(yyyy-MM),8(yyyy/MM),9(yyyy年MM月),10(HH:mm:ss),11(yyyy-MM-dd HH:mm)
        /// <summary>
        /// 格式化日期时间,0(yyyy-MM-dd),1(yyyy-MM-dd HH:mm:ss),2(yyyy/MM/dd),3(yyyy年MM月dd日),4(MM-dd),5(MM/dd),6(MM月dd日),7(yyyy-MM),8(yyyy/MM),9(yyyy年MM月),10(HH:mm:ss),11(yyyy-MM-dd HH:mm)
        /// </summary>
        /// <param name="dateMode">显示模式</param>
        /// <returns>0-9种模式的日期</returns>
        public static string GetNow(int dateMode)
        {
            return FormatDate(DateTime.Now, dateMode);
        }

        /// <summary>
        /// 格式化日期时间,0(yyyy-MM-dd),1(yyyy-MM-dd HH:mm:ss),2(yyyy/MM/dd),3(yyyy年MM月dd日),4(MM-dd),5(MM/dd),6(MM月dd日),7(yyyy-MM),8(yyyy/MM),9(yyyy年MM月),10(HH:mm:ss),11(yyyy-MM-dd HH:mm)
        /// </summary>
        /// <param name="dateTime">日期时间</param>
        /// <param name="dateMode">显示模式</param>
        /// <returns>0-9种模式的日期</returns>
        public static string FormatDate(this DateTime dateTime, int dateMode)
        {
            if (dateTime.IsNull()) return "";
            switch (dateMode)
            {
                case 0:
                    return dateTime.ToString("yyyy-MM-dd");

                case 1:
                    return dateTime.ToString("yyyy-MM-dd HH:mm:ss");

                case 2:
                    return dateTime.ToString("yyyy/MM/dd");

                case 3:
                    return dateTime.ToString("yyyy年MM月dd日");

                case 4:
                    return dateTime.ToString("MM-dd");

                case 5:
                    return dateTime.ToString("MM/dd");

                case 6:
                    return dateTime.ToString("MM月dd日");

                case 7:
                    return dateTime.ToString("yyyy-MM");

                case 8:
                    return dateTime.ToString("yyyy/MM");

                case 9:
                    return dateTime.ToString("yyyy年MM月");

                case 10:
                    return dateTime.ToString("HH:mm:ss");
                case 11:
                    return dateTime.ToString("yyyy-MM-dd HH:mm");
            }

            return dateTime.ToString();
        }
        #endregion
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

        #region 根据时间来提醒打招呼
        /// <summary>
        /// 根据时间来提醒打招呼
        /// </summary>
        /// <returns></returns>
        public static string RemindTime()
        {
            var date = DateTime.Now.Hour;
            if (date >= 23 || date < 5)
            {
                return "凌晨好！";
            }
            else if (date >= 5 && date < 11)
            {
                return "上午好！";
            }
            else if (date >= 11 && date < 14)
            {
                return "中午好！";
            }
            else if (date >= 14 && date < 19)
            {
                return "下午好！";
            }
            else
            {
                return "晚上好！";
            }
        }
        #endregion

        #region 日期比较
        /// <summary>
        /// 日期比较
        /// </summary>
        /// <param name="today">距离某个日期</param>
        /// <param name="writeDate">输入日期</param>
        /// <param name="n">比较天数</param>
        /// <returns>大于天数返回true，小于返回false</returns>
        public static bool CompareDate(string today, string writeDate, int n)
        {
            DateTime Today = System.Convert.ToDateTime(today);
            DateTime WriteDate = System.Convert.ToDateTime(writeDate);
            WriteDate = WriteDate.AddDays(n);
            if (Today >= WriteDate)
                return false;
            else
                return true;
        }
        #endregion

        #region 转换日期值与今天的时间段
        /// <summary>
        /// 转换日期值与今天的时间段
        /// </summary>
        /// <param name="Date">日期值</param>
        /// <returns>时间段,N天N小时N分钟N秒</returns>
        public static string ToTimeSpan(DateTime Date)
        {
            TimeSpan span = (TimeSpan)(DateTime.Now - Date);
            if (span.TotalDays > 1.0)
            {
                return (Math.Round(span.TotalDays).ToString() + "天");
            }
            if (span.TotalHours > 1.0)
            {
                return (Math.Round(span.TotalHours).ToString() + "小时");
            }
            if (span.TotalMinutes > 1.0)
            {
                return (Math.Round(span.TotalMinutes).ToString() + "分钟");
            }
            return (Math.Round(span.TotalSeconds).ToString() + "秒");
        }

        #endregion

        #region 判断日期是否过期
        /// <summary>
        /// 判断日期是否过期
        /// </summary>
        /// <param name="myDate">所要判断的日期</param>
        public static bool ValidDate(string myDate)
        {
            if (!myDate.IsDateTime())
                return true;
            return CompareDate(myDate, DateTime.Now.Date.ToString(), 0);
        }
        #endregion

        #region 时间转换为字符格式
        /// <summary>
        /// 时间字符串转换为字符格式yyyy-MM-dd
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CDateString(string input)
        {
            DateTime time;
            if (!DateTime.TryParse(input, out time))
            {
                return string.Empty;
            }
            return time.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 格式化DateTime类型为字符串类型，精确到天，如：2008/01/01
        /// </summary>
        /// <param name="dateTime">要格式化的时间变量</param>
        /// <returns></returns>
        public static string ConvertToDayString(DateTime dateTime)
        {
            if (string.IsNullOrWhiteSpace(dateTime.ToString()))
            {
                return "";
            }
            return dateTime.ToString(@"yyyy\/MM\/dd");
        }

        /// <summary>
        /// 格式化object类型为字符串类型，精确到天，如：2008/01/01
        /// </summary>
        /// <param name="dateTime">要格式化的object</param>
        /// <returns></returns>
        public static string ConvertToDayString(object dateTime)
        {
            if (string.IsNullOrWhiteSpace(dateTime.ToString()))
            {
                return "";
            }
            return ConvertToDayString((DateTime)dateTime);
        }

        /// <summary>
        /// 格式化DateTime类型为字符串类型，精确到小时，如：2008/01/01 18
        /// </summary>
        /// <param name="dateTime">要格式化的时间变量</param>
        /// <returns></returns>
        public static string ConvertToHourString(DateTime dateTime)
        {
            if (string.IsNullOrWhiteSpace(dateTime.ToString()))
            {
                return "";
            }
            return dateTime.ToString(@"yyyy\/MM\/dd HH");
        }

        /// <summary>
        /// 格式化object类型为字符串类型，精确到小时，如：2008/01/01 18
        /// </summary>
        /// <param name="dateTime">要格式化的object</param>
        /// <returns></returns>
        public static string ConvertToHourString(object dateTime)
        {
            if (string.IsNullOrWhiteSpace(dateTime.ToString()))
            {
                return "";
            }
            return ConvertToHourString((DateTime)dateTime);
        }

        /// <summary>
        /// 格式化DateTime类型为字符串类型，精确到分钟，如：2008/01/01 18:09
        /// </summary>
        /// <param name="dateTime">要格式化的时间变量</param>
        /// <returns></returns>
        public static string ConvertToMiniuteString(DateTime dateTime)
        {
            if (string.IsNullOrWhiteSpace(dateTime.ToString()))
            {
                return "";
            }
            return dateTime.ToString(@"yyyy\/MM\/dd HH:mm");
        }

        /// <summary>
        /// 格式化object类型为字符串类型，精确到分钟，如：2008/01/01 18:09
        /// </summary>
        /// <param name="dateTime">要格式化的object</param>
        /// <returns></returns>
        public static string ConvertToMiniuteString(object dateTime)
        {
            if (string.IsNullOrWhiteSpace(dateTime.ToString()))
            {
                return "";
            }
            return ConvertToMiniuteString((DateTime)dateTime);
        }

        /// <summary>
        /// 格式化DateTime类型为字符串类型，精确到秒，如：2008/01/01 18:09:20
        /// </summary>
        /// <param name="dateTime">要格式化的时间变量</param>
        /// <returns></returns>
        public static string ConvertToSecondString(DateTime dateTime)
        {
            if (string.IsNullOrWhiteSpace(dateTime.ToString()))
            {
                return "";
            }
            return dateTime.ToString(@"yyyy\/MM\/dd HH:mm:ss");
        }

        /// <summary>
        /// 格式化object类型为字符串类型，精确到秒，如：2008/01/01 18:09:20
        /// </summary>
        /// <param name="dateTime">要格式化的object</param>
        /// <returns></returns>
        public static string ConvertToSecondString(object dateTime)
        {
            if (string.IsNullOrWhiteSpace(dateTime.ToString()))
            {
                return "";
            }
            return ConvertToSecondString((DateTime)dateTime);
        }

        #endregion

        #region 把秒转换成分钟
        /// <summary>
        /// 把秒转换成分钟
        /// </summary>
        /// <returns></returns>
        public static int SecondToMinute(int Second)
        {
            decimal mm = (decimal)((decimal)Second / (decimal)60);
            return System.Convert.ToInt32(Math.Ceiling(mm));
        }
        #endregion

        #region 返回某年某月最后一天
        /// <summary>
        /// 返回某年某月最后一天
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns>日</returns>
        public static int GetMonthLastDate(int year, int month)
        {
            DateTime lastDay = new DateTime(year, month, new GregorianCalendar().GetDaysInMonth(year, month));
            int Day = lastDay.Day;
            return Day;
        }
        #endregion

        #region 获取一个月有多少天！
        /// <summary>
        /// 获取一个月有多少天！
        /// </summary>
        /// <param name="iYear"></param>
        /// <param name="iMonth"></param>
        /// <returns></returns>
        public static int GetMonthLen(string iYear, string iMonth)
        {
            return DateTime.DaysInMonth(int.Parse(iYear), int.Parse(iMonth));
        }

        #endregion

        #region 获取一个月多少个周末日
        /// <summary>
        /// 获取一个月多少个周末日
        /// </summary>
        /// <param name="iYear"></param>
        /// <param name="iMonth"></param>
        /// <returns></returns>
        public static int GetWeekLen(string iYear, string iMonth)
        {
            int days = GetMonthLen(iYear, iMonth);
            int i;
            int num1 = 0;
            for (i = 1; i < days + 1; i++)
            {
                int num = (int)(iYear + "-" + iMonth + "-" + i).ToDate().DayOfWeek;
                if (num == 0 | num == 6)
                {
                    num1 += 1;
                }
            }
            return num1;
        }

        #endregion

        #region 取指定日期是一年中的第几周
        /// <summary>
        /// 取指定日期是一年中的第几周
        /// </summary>
        /// <param name="dtime">给定的日期</param>
        /// <returns>数字 一年中的第几周</returns>
        public static int weekofyear(DateTime dtime)
        {
            int weeknum = 0;
            DateTime tmpdate = DateTime.Parse(dtime.Year.ToString() + "-1" + "-1");
            DayOfWeek firstweek = tmpdate.DayOfWeek;
            //if(firstweek) 
            for (int i = (int)firstweek + 1; i <= dtime.DayOfYear; i = i + 7)
            {
                weeknum = weeknum + 1;
            }
            return weeknum;
        }
        #endregion

        #region 获取当前星期的第一天，i为以星期几天周期与星期日的差值
        /// <summary>
        /// 获取当前星期的第一天，i为以星期几天周期与星期日的差值
        /// </summary>
        /// <param name="dtime">日期</param>
        /// <param name="i">i为以星期几天周期与星期日的差值</param>
        /// <returns></returns>
        public static DateTime startweekday(DateTime dtime, int i)
        {
            return dtime.AddDays(Convert.ToDouble((0 - System.Convert.ToInt16(dtime.DayOfWeek) - i)));
        }
        #endregion

        #region 获取当前星期的最后一天,i为以星期几天周期与星期日的差值.
        /// <summary>
        /// 获取当前星期的最后一天,i为以星期几天周期与星期日的差值.
        /// </summary>
        /// <param name="dtime"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static DateTime endweekday(DateTime dtime, int i)
        {
            return dtime.AddDays(Convert.ToDouble(6 - System.Convert.ToInt16(dtime.DayOfWeek) - i));
        }
        #endregion

        #region 得到随机日期
        /// <summary>
        /// 得到随机日期
        /// </summary>
        /// <param name="time1">起始日期</param>
        /// <param name="time2">结束日期</param>
        /// <returns></returns>
        public static DateTime GetRandomTime(DateTime time1, DateTime time2)
        {
            Random random = new Random();
            DateTime minTime = new DateTime();
            DateTime maxTime = new DateTime();
            TimeSpan ts = new TimeSpan(time1.Ticks - time2.Ticks);
            //获取两个时间相隔的秒数
            double dTotalSecontds = ts.TotalSeconds;
            int iTotalSecontds = 0;
            if (dTotalSecontds > System.Int32.MaxValue)
            {
                iTotalSecontds = System.Int32.MaxValue;
            }
            else if (dTotalSecontds < System.Int32.MinValue)
            {
                iTotalSecontds = System.Int32.MinValue;
            }
            else
            {
                iTotalSecontds = int.Parse(dTotalSecontds.ToString());
            }
            if (iTotalSecontds > 0)
            {
                minTime = time2;
                maxTime = time1;
            }
            else if (iTotalSecontds < 0)
            {
                minTime = time1;
                maxTime = time2;
            }
            else
            {
                return time1;
            }
            int maxValue = iTotalSecontds;
            if (iTotalSecontds <= System.Int32.MinValue)
            {
                maxValue = System.Int32.MinValue + 1;
            }
            int i = random.Next(System.Math.Abs(maxValue));
            return minTime.AddSeconds(i);
        }
        #endregion

        #region 获取今天是星期几
        /// <summary>
        /// 获取今天是星期几
        /// </summary>
        /// <param name="ints">0为英文星期，1为中文星期</param>
        /// <returns></returns>
        public static string GetDateweek(int ints)
        {
            if (ints == 0)
            {
                switch (DateTime.Now.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        return "Sun";
                    case DayOfWeek.Monday:
                        return "Mon";
                    case DayOfWeek.Tuesday:
                        return "Tue";
                    case DayOfWeek.Wednesday:
                        return "Wed";
                    case DayOfWeek.Thursday:
                        return "Thu";
                    case DayOfWeek.Friday:
                        return "Fri";
                    case DayOfWeek.Saturday:
                        return "Sat";
                }
            }
            else
            {
                switch (DateTime.Now.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        return "星期天";
                    case DayOfWeek.Monday:
                        return "星期一";
                    case DayOfWeek.Tuesday:
                        return "星期二";
                    case DayOfWeek.Wednesday:
                        return "星期三";
                    case DayOfWeek.Thursday:
                        return "星期四";
                    case DayOfWeek.Friday:
                        return "星期五";
                    case DayOfWeek.Saturday:
                        return "星期六";
                }
            }
            return string.Empty;
        }
        #endregion

        #region 获得月份
        /// <summary>
        /// 获得月份
        /// </summary>
        /// <param name="ints">0为英文简写,1为中文</param>
        /// <returns></returns>
        public static string GetDateMonth(int ints)
        {
            if (ints == 0)
            {
                switch (DateTime.Now.Month)
                {
                    case 1:
                        return "Jan";
                    case 2:
                        return "Feb";
                    case 3:
                        return "Mar";
                    case 4:
                        return "Apr";
                    case 5:
                        return "May";
                    case 6:
                        return "Jun";
                    case 7:
                        return "Jul";
                    case 8:
                        return "Aug";
                    case 9:
                        return "Sep";
                    case 10:
                        return "Oct";
                    case 11:
                        return "Nov";
                    case 12:
                        return "Dec";
                }
            }
            else
            {
                switch (DateTime.Now.Month)
                {
                    case 1:
                        return "一月";
                    case 2:
                        return "二月";
                    case 3:
                        return "三月";
                    case 4:
                        return "四月";
                    case 5:
                        return "五月";
                    case 6:
                        return "六月";
                    case 7:
                        return "七月";
                    case 8:
                        return "八月";
                    case 9:
                        return "九月";
                    case 10:
                        return "十月";
                    case 11:
                        return "十一月";
                    case 12:
                        return "十二月";
                }
            }
            return string.Empty;
        }
        #endregion

        #region 返回相差的秒数
        /// <summary>
        /// 返回相差的秒数
        /// </summary>
        /// <param name="Time"></param>
        /// <param name="Sec"></param>
        /// <returns></returns>
        public static int StrDateDiffSeconds(string Time, int Sec)
        {
            TimeSpan ts = DateTime.Now - DateTime.Parse(Time).AddSeconds(Sec);
            if (ts.TotalSeconds > int.MaxValue)
                return int.MaxValue;

            else if (ts.TotalSeconds < int.MinValue)
                return int.MinValue;

            return (int)ts.TotalSeconds;
        }
        #endregion

        #region 返回相差的分钟数
        /// <summary>
        /// 返回相差的分钟数
        /// </summary>
        /// <param name="time"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static int StrDateDiffMinutes(string time, int minutes)
        {
            if (string.IsNullOrEmpty(time))
                return 1;

            TimeSpan ts = DateTime.Now - DateTime.Parse(time).AddMinutes(minutes);
            if (ts.TotalMinutes > int.MaxValue)
                return int.MaxValue;
            else if (ts.TotalMinutes < int.MinValue)
                return int.MinValue;

            return (int)ts.TotalMinutes;
        }
        #endregion

        #region  返回相差的小时数
        /// <summary>
        /// 返回相差的小时数
        /// </summary>
        /// <param name="time"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static int StrDateDiffHours(string time, int hours)
        {
            if (string.IsNullOrEmpty(time))
                return 1;

            TimeSpan ts = DateTime.Now - DateTime.Parse(time).AddHours(hours);
            if (ts.TotalHours > int.MaxValue)
                return int.MaxValue;
            else if (ts.TotalHours < int.MinValue)
                return int.MinValue;

            return (int)ts.TotalHours;
        }
        #endregion

        #region 把两个时间差，三天内的时间用今天，昨天，前天表示，后跟时间，无日期
        /// <summary>
        /// 把两个时间差，三天内的时间用今天，昨天，前天表示，后跟时间，无日期
        /// </summary>
        /// <param name="date">被比较的时间</param>
        /// <param name="currentDateTime">目标时间</param>
        /// <returns></returns>
        public static string ConvertDateTime(string date, DateTime currentDateTime)
        {
            if (string.IsNullOrEmpty(date))
                return "";

            DateTime time;
            if (!DateTime.TryParse(date, out time))
                return "";

            string result = "";
            if (DateDiff("hour", time, currentDateTime) <= 3)
            {
                if (DateDiff("hour", time, currentDateTime) > 0)
                    return DateDiff("hour", time, currentDateTime) + "小时前";

                if (DateDiff("minute", time, currentDateTime) > 0)
                    return DateDiff("minute", time, currentDateTime) + "分钟前";

                if (DateDiff("second", time, currentDateTime) > 0)
                    return DateDiff("second", time, currentDateTime) + "秒前";
            }
            else
            {
                switch (currentDateTime.Day - time.Day)
                {
                    case 0:
                        result = "今天 " + time.ToString("HH") + ":" + time.ToString("mm");
                        break;
                    case 1:
                        result = "昨天 " + time.ToString("HH") + ":" + time.ToString("mm");
                        break;
                    case 2:
                        result = "前天 " + time.ToString("HH") + ":" + time.ToString("mm");
                        break;
                    default:
                        result = time.ToString("yyyy-MM-dd HH:mm");
                        break;
                }
            }
            return result;
        }
        #endregion

        #region 返回时间差
        /// <summary>
        /// 返回时间差
        /// </summary>
        /// <param name="DateTime1"></param>
        /// <param name="DateTime2"></param>
        /// <returns></returns>
        public static string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            try
            {
                TimeSpan ts = DateTime2 - DateTime1;
                if (ts.Days >= 1)
                {
                    dateDiff = DateTime1.Month.ToString() + "月" + DateTime1.Day.ToString() + "日";
                }
                else
                {
                    if (ts.Hours > 1)
                    {
                        dateDiff = ts.Hours.ToString() + "小时前";
                    }
                    else
                    {
                        dateDiff = ts.Minutes.ToString() + "分钟前";
                    }
                }
            }
            catch
            { }
            return dateDiff;
        }

        /// <summary>
        /// 获得两个日期的间隔。
        /// </summary>
        /// <param name="DateTime1">日期一</param>
        /// <param name="Datetime2">日期二</param>
        /// <returns>日期间隔TimeSpan</returns>
        public static TimeSpan DateDiff1(DateTime DateTime1, DateTime Datetime2)
        {
            TimeSpan span = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts = new TimeSpan(Datetime2.Ticks);
            return span.Subtract(ts).Duration();
        }
        #endregion

        #region 两个时间的差值，可以为秒，小时，天，分钟
        /// <summary>
        /// 两个时间的差值，可以为秒，小时，天，分钟
        /// </summary>
        /// <param name="Interval">需要得到的时差方式</param>
        /// <param name="StartDate">起始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <returns></returns>
        public static long DateDiff(string Interval, DateTime StartDate, DateTime EndDate)
        {

            long lngDateDiffValue = 0;
            System.TimeSpan TS = new System.TimeSpan(EndDate.Ticks - StartDate.Ticks);
            switch (Interval)
            {
                case "second":
                    lngDateDiffValue = (long)TS.TotalSeconds;
                    break;
                case "minute":
                    lngDateDiffValue = (long)TS.TotalMinutes;
                    break;
                case "hour":
                    lngDateDiffValue = (long)TS.TotalHours;
                    break;
                case "day":
                    lngDateDiffValue = (long)TS.Days;
                    break;
                case "week":
                    lngDateDiffValue = (long)(TS.Days / 7);
                    break;
                case "month":
                    lngDateDiffValue = (long)(TS.Days / 30);
                    break;
                case "quarter":
                    lngDateDiffValue = (long)((TS.Days / 30) / 3);
                    break;
                case "year":
                    lngDateDiffValue = (long)(TS.Days / 365);
                    break;
            }
            return (lngDateDiffValue);
        }
        #endregion

        #region 把三天内的时间用今天，昨天，前天表示，后跟时间，无日期
        /// <summary>
        /// 把三天内的时间用今天，昨天，前天表示，后跟时间，无日期
        /// </summary>
        /// <param name="strdate">被转换的时间</param>
        /// <returns></returns>
        public static string ConvertDateTime(string date)
        {
            return ConvertDateTime(date, DateTime.Now);
        }
        #endregion
    }
}
