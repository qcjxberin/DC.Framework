using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Ding.Calendar
{
    public class Lunar
    {

        internal int year;
        // 公历月
        internal int month;
        // 公历日
        internal int day;

        // 农历数字年
        internal int lunarYear;
        /// <summary>
        /// 农历数字月
        /// </summary>
        internal int lunarMonth;
        // 农历数字日
        internal int lunarDay;

        // 农历中文数字年
        internal string cnyear;
        // 农历中文数字月
        internal string cnmonth;
        // 农历中文数字日
        internal string cnday;

        // 农历黄历年
        internal string hyear;
        // 农历黄历年
        internal string cyclicalYear;
        // 农历黄历月
        internal string cyclicalMonth;
        // 农历黄历日
        internal string cyclicalDay;

        // 宜
        internal string suit;
        // 禁忌
        internal string taboo;
        // 生肖
        internal string animal;
        // 星期
        internal string week;
        // 是否是闰月
        internal bool isLeap;
        //是否闰年
        //private boolean isLeapYear;
        //当天的节日
        internal IList<string> festivalList = new List<string>();

        internal IDictionary<int, object> jieqi;

        [NonSerialized]
        internal int maxDayInMonth = 29;

        // getter & setter method
        public virtual string Hyear => hyear;

        public virtual IList<string> FestivalList => festivalList;

        public virtual Lunar SetFestivalList(IList<string> festivalList)
        {
            this.festivalList = festivalList;
            return this;
        }

        public virtual string CyclicalYear => cyclicalYear;

        public virtual IDictionary<int, object> Jieqi
        {
            get => jieqi;
            set => jieqi = value;
        }


        public virtual Lunar SetCyclicalYear(string cyclicalYear)
        {
            this.cyclicalYear = cyclicalYear;
            return this;
        }

        public virtual string CyclicalMonth => cyclicalMonth;

        public virtual Lunar SetCyclicalMonth(string cyclicalMonth)
        {
            this.cyclicalMonth = cyclicalMonth;
            return this;
        }

        public virtual string CyclicalDay => cyclicalDay;

        public virtual Lunar SetCyclicalDay(string cyclicalDay)
        {
            this.cyclicalDay = cyclicalDay;
            return this;
        }


        public virtual string Cnyear => cnyear;

        public virtual Lunar SetCnyear(string cnyear)
        {
            this.cnyear = cnyear;
            return this;
        }

        public virtual string Cnmonth => cnmonth;

        public virtual Lunar SetCnmonth(string cnmonth)
        {
            this.cnmonth = cnmonth;
            return this;
        }

        public virtual string Cnday => cnday;

        public virtual Lunar SetCnday(string cnday)
        {
            this.cnday = cnday;
            return this;
        }

        public virtual Lunar SetHyear(string hyear)
        {
            this.hyear = hyear;
            return this;
        }
        public virtual int LunarYear => lunarYear;

        public virtual Lunar SetLunarYear(int lunarYear)
        {
            this.lunarYear = lunarYear;
            return this;
        }

        public virtual int LunarMonth => lunarMonth;

        public virtual Lunar setLunarMonth(int lunarMonth)
        {
            this.lunarMonth = lunarMonth;
            return this;
        }

        public virtual int LunarDay => lunarDay;

        public virtual Lunar setLunarDay(int lunarDay)
        {
            this.lunarDay = lunarDay;
            return this;
        }

        public virtual string Suit => suit;

        public virtual Lunar setSuit(string suit)
        {
            this.suit = suit;
            return this;
        }

        public virtual string Taboo => taboo;

        public virtual Lunar setTaboo(string taboo)
        {
            this.taboo = taboo;
            return this;
        }

        public virtual string Animal => animal;

        public virtual Lunar setAnimal(string animal)
        {
            this.animal = animal;
            return this;
        }

        public virtual string Week => week;

        public virtual Lunar setWeek(string week)
        {
            this.week = week;
            return this;
        }

        public virtual int Year => year;

        public virtual Lunar setYear(int year)
        {
            this.year = year;
            return this;
        }

        public virtual int Month => month;

        public virtual Lunar setMonth(int month)
        {
            this.month = month;
            return this;
        }

        public virtual int Day => day;

        public virtual Lunar setDay(int day)
        {
            this.day = day;
            return this;
        }

        public virtual bool Leap => isLeap;

        public virtual Lunar setLeap(bool isLeap)
        {
            this.isLeap = isLeap;
            return this;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public Lunar(DateTime date)
        {
            Build(date.Year, date.Month + 1, date.Day);
        }

        public Lunar(int year, int month, int day)
        {
            Build(year, month, day);
        }

        /// <summary>
        /// 入口
        /// </summary>
        /// <param name="year">  公历年 </param>
        /// <param name="month"> 公历月 </param>
        /// <param name="day">   公历日 </param>
        public virtual Lunar Build(int year, int month, int day)
        {
            // 保存传入的值
            this.year = year;
            this.month = month;
            this.day = day;

            var calendar = new DateTime(year, month, day);

            // 星期
            week = CultureInfo.CurrentCulture.DateTimeFormat
                .GetDayName(calendar.DayOfWeek);

            DateTime baseDate = new DateTime(1900, 1, 31);

            var calendarTicks = (calendar.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second).Ticks - new DateTime(1970, 1, 1, 8, 0, 0).Ticks) / 10000;
            var basedateTicks = (baseDate.Ticks - new DateTime(1970, 1, 1, 8, 0, 0).Ticks) / 10000;
            long offset = (calendarTicks - basedateTicks) / 86400000;
            // 按农历年递减每年的农历天数，确定农历年份
            lunarYear = 1900;
            int daysInLunarYear = GetLunarYearDays(lunarYear);
            while (lunarYear < 2100 && offset >= daysInLunarYear)
            {
                offset -= daysInLunarYear;
                daysInLunarYear = GetLunarYearDays(++lunarYear);
            }

            /* 农历年数字 */

            // 按农历月递减每月的农历天数，确定农历月份
            int lunarMonth = 1;
            // 所在农历年闰哪个月,若没有返回0
            int leapMonth = GetLunarLeapMonth(lunarYear);
            // 是否闰年
            this.isLeap = leapMonth > 0;
            // 闰月是否递减
            bool leapDec = false;
            bool isLeap = false;
            int daysInLunarMonth = 0;
            while (lunarMonth < 13 && offset > 0)
            {
                if (isLeap && leapDec)
                { // 如果是闰年,并且是闰月
                  // 所在农历年闰月的天数
                    daysInLunarMonth = GetLunarLeapDays(lunarYear);
                    leapDec = false;
                }
                else
                {
                    // 所在农历年指定月的天数
                    daysInLunarMonth = GetLunarMonthDays(lunarYear, lunarMonth);
                }
                if (offset < daysInLunarMonth)
                {
                    break;
                }
                offset -= daysInLunarMonth;

                if (leapMonth == lunarMonth && isLeap == false)
                {
                    // 下个月是闰月
                    leapDec = true;
                    isLeap = true;
                }
                else
                {
                    // 月份递增
                    lunarMonth++;
                }
            }
            maxDayInMonth = daysInLunarMonth;
            // 农历月数字
            this.lunarMonth = lunarMonth;
            // 是否闰月
            this.isLeap = (lunarMonth == leapMonth && isLeap);
            // 农历日数字
            lunarDay = (int)offset + 1;

            hyear = LunarYearString;

            cnyear = CYear(lunarYear);
            cnmonth = LunarUtils.CmonthName[this.lunarMonth - 1];
            cnday = CnDay(lunarDay);

            animal = LunarUtils.Animals[(year - 4) % 12];
            // 取得干支历
            GetCyclicalData(calendar);

            return this;
        }

        /// <summary>
        /// 获得某年中所有节气Date
        /// 
        /// @return
        /// </summary>
        public static DateTime[] jieqilist(int year)
        {
            DateTime[] returnvalue = new DateTime[LunarUtils.SolarTerm.Length];

            for (int i = 0; i < LunarUtils.SolarTerm.Length; i++)
            {

                DateTime t = GetSolarTermCalendar(year, i);
                returnvalue[i] = t;

            }
            return returnvalue;
        }

        /// <summary>
        /// 取干支历 不是历年，历月干支，而是中国的从立春节气开始的节月，是中国的太阳十二宫，阳历的。
        /// </summary>
        /// <param name="calendar">
        ///            日历对象(Tcnca) </param>
        internal virtual void GetCyclicalData(DateTime calendar)
        {
            int solarYear = calendar.Year;
            int solarMonth = calendar.Month - 1;
            int solarDay = calendar.Day;
            // 干支历
            int cYear;
            int cMonth;
            int cDay;

            // 干支年 1900年立春後为庚子年(60进制36)
            int term2 = GetSolarTermDay(solarYear, 2); // 立春日期
                                                       // 依节气调整二月分的年柱, 以立春为界
            if (solarMonth < 1 || (solarMonth == 1 && solarDay < term2))
            {
                cYear = (solarYear - 1900 + 36 - 1) % 60;
            }
            else
            {
                cYear = (solarYear - 1900 + 36) % 60;
            }

            // 干支月 1900年1月小寒以前为 丙子月(60进制12)
            int firstNode = GetSolarTermDay(solarYear, solarMonth * 2); // 传回当月「节」为几日开始
                                                                        //--
            int cMnum = (solarYear - 1900) * 12 + solarMonth + 12;
            // 依节气月柱, 以「节」为界
            if (solarDay < firstNode)
            {
                cMonth = ((solarYear - 1900) * 12 + solarMonth + 12) % 60;
            }
            else
            {
                cMonth = ((solarYear - 1900) * 12 + solarMonth + 13) % 60;
            }

            // 当月一日与 1900/1/1 相差天数
            // 1900/1/1与 1970/1/1 相差25567日, 1900/1/1 日柱为甲戌日(60进制10)
            cDay = (int)(Utc(solarYear, solarMonth + 1, solarDay, 0, 0, 0) / 86400000 + 25567 + 10) % 60;
            long dayCyclical = Utc(solarYear, solarMonth + 1, 1, 0, 0, 0) / 86400000 + 25567 + 10;
            Console.WriteLine(dayCyclical);
            // 干支年
            cyclicalYear = GetCyclicaYear(cYear);
            // 干支月
            cyclicalMonth = GetCyclicaMonth(cMonth);
            // 干支日
            cyclicalDay = GetCyclicaDay(cDay);
            if (solarDay >= firstNode)
            {
                cMnum = (solarYear - 1900) * 12 + solarMonth + 13;
            }
            int cDnum = (int)(dayCyclical + solarDay - 1);

            Console.WriteLine($@"{cMnum},{cDnum}");
            SuitAndTaboo(this, cMnum, cDnum);


            IDictionary<int, object> jieqiMap = new Dictionary<int, object>();
            //节气
            int tmp1 = STerm(solarYear, (solarMonth) * 2);
            int tmp2 = STerm(solarYear, (solarMonth) * 2 + 1);
            jieqiMap[tmp1] = LunarUtils.SolarTerm[(solarMonth) * 2];
            jieqiMap[tmp2] = LunarUtils.SolarTerm[(solarMonth) * 2 + 1];

            jieqi = jieqiMap;

            //节日计算
            IList<string> festivalList = new List<string>();

            //公历节日，当前公历去计算
            string key = Replenish(month, 2) + Replenish(day, 2);
            if (LunarUtils.FestivalJson.ContainsKey(key))
            {
                string festival = LunarUtils.FestivalJson[key];
                if (null != festival)
                {
                    festivalList.Add(festival);
                }
            }

            //农历节日，当前农历去计算
            key = Replenish(lunarMonth, 2) + Replenish(lunarDay, 2);
            if (LunarUtils.FestivalLunarJson.ContainsKey(key))
            {
                string festival_lunar = LunarUtils.FestivalLunarJson[key];
                if (null != festival_lunar)
                {
                    festivalList.Add(festival_lunar);
                }
            }

            //父亲节6月份，第三个周日。
            int fmonth = 6, fweek = 3;
            //母亲节5月份，第二个周日。
            int mmonth = 5, mweek = 2;
            //感恩节11月份，第四个星期四
            int tmonth = 11, tweek = 4;

            //获取当年的其他节日。
            var otherOfYear = LunarUtils.FestivalOtherJson.ContainsKey(solarYear) ? LunarUtils.FestivalOtherJson[solarYear] : new Dictionary<string, string>();
            DateTime cal = new DateTime();

            //如果当年没有生成过，生成一次，并且存储。
            if (null == otherOfYear)
            {
                otherOfYear = new Dictionary<string, string>();
                cal = new DateTime(solarYear, mmonth, 1).AddDays(-1);
                //母亲节计算
                var maxDate = DateTime.DaysInMonth(solarYear, mmonth);
                var sundays = 0;
                for (int i = 1; i <= maxDate; i++)
                {
                    cal = cal.AddDays(1);
                    if (cal.DayOfWeek == DayOfWeek.Sunday)
                    {
                        sundays++;
                        if (sundays == mweek)
                        {
                            break;
                        }
                    }
                }
                otherOfYear[cal.ToString("MMdd")] = "母亲节";

                //父亲节计算
                cal = new DateTime(solarYear, fmonth, 1).AddDays(-1);
                maxDate = DateTime.DaysInMonth(solarYear, fmonth);
                sundays = 0;
                for (int i = 1; i <= maxDate; i++)
                {
                    cal = cal.AddDays(1);
                    if (cal.DayOfWeek == DayOfWeek.Sunday)
                    {
                        sundays++;
                        if (sundays == fweek)
                        {
                            break;
                        }
                    }
                }
                otherOfYear[cal.ToString("MMdd")] = "父亲节";

                //感恩节
                cal = new DateTime(solarYear, tmonth, 1).AddDays(-1);
                maxDate = DateTime.DaysInMonth(solarYear, fmonth);
                sundays = 0;
                for (int i = 1; i <= maxDate; i++)
                {
                    cal = cal.AddDays(1);
                    if ((int)cal.DayOfWeek == (tweek + 1))
                    { //因为星期是从0开始
                        sundays++;
                        if (sundays == tweek)
                        {
                            break;
                        }
                    }
                }
                otherOfYear[cal.ToString("MMdd")] = "感恩节";
                LunarUtils.FestivalOtherJson[solarYear] = otherOfYear;
            }
            //判断是否存在 父亲节，母亲节，感恩节

            otherOfYear = LunarUtils.FestivalOtherJson.ContainsKey(solarYear) ? LunarUtils.FestivalOtherJson[solarYear] : new Dictionary<string, string>();
            //格式化当前时间做Key，去命中节日
            key = calendar.ToString("MMdd");
            var otherFestival = otherOfYear.ContainsKey(key) ? otherOfYear[key] : "";
            if (null != otherFestival)
            {
                festivalList.Add(otherFestival);
            }
            //有节日再输出，保证JSON的值
            if (festivalList.Count > 0)
            {
                this.festivalList = festivalList;
            }
        }

        internal static int[] STermInfo = { 0, 21208, 42467, 63836, 85337, 107014, 128867, 150921, 173149, 195551, 218072, 240693, 263343, 285989, 308563, 331033, 353350, 375494, 397447, 419210, 440795, 462224, 483532, 504758 };
        //===== 某年的第n个节气为几日(从0小寒起算)
        public static int STerm(int y, int n)
        {
            DateTime baseDateAndTime = new DateTime(1900, 1, 6, 2, 5, 0); //#1/6/1900 2:05:00 AM#
            for (int i = 0; i < 24; i++)
            {
                var num = 525948.76 * (y - 1900) + STermInfo[i];
                var newDate = baseDateAndTime.AddMinutes(num);
                if (i == n)
                {
                    return newDate.Day;
                }
            }

            return 0;
        }
        /// <summary>
        /// 取得干支年字符串
        /// </summary>
        /// <param name="CyclicalYear"></param>
        /// <returns> 干支年字符串 </returns>
        public virtual string GetCyclicaYear(int CyclicalYear)
        {
            return GetCyclicalString(CyclicalYear);
        }

        /// <summary>
        /// 取得干支月字符串
        /// </summary>
        /// <returns> 干支月字符串 </returns>
        public virtual string GetCyclicaMonth(int cyclicalMonth)
        {
            return GetCyclicalString(cyclicalMonth);
        }

        /// <summary>
        /// 取得干支日字符串
        /// </summary>
        /// <returns> 干支日字符串 </returns>
        public virtual string GetCyclicaDay(int cyclicalDay)
        {
            return GetCyclicalString(cyclicalDay);
        }

        /// <summary>
        /// 干支字符串
        /// </summary>
        /// <param name="cyclicalNumber">
        ///            指定干支位置(数字,0为甲子) </param>
        /// <returns> 干支字符串 </returns>
        internal static string GetCyclicalString(int cyclicalNumber)
        {
            return LunarUtils.Tianan[GetTianan(cyclicalNumber)] + LunarUtils.Deqi[GetDeqi(cyclicalNumber)];
        }

        /// <summary>
        /// 年份天干
        /// </summary>
        /// <returns> 年份天干 </returns>
        public virtual int GetTiananY(int cyclicalYear)
        {
            return GetTianan(cyclicalYear);
        }

        /// <summary>
        /// 月份天干
        /// </summary>
        /// <returns> 月份天干 </returns>
        public virtual int GetTiananM(int cyclicalMonth)
        {
            return GetTianan(cyclicalMonth);
        }

        /// <summary>
        /// 日期天干
        /// </summary>
        /// <returns> 日期天干 </returns>
        public virtual int GetTiananD(int cyclicalDay)
        {
            return GetTianan(cyclicalDay);
        }

        /// <summary>
        /// 年份地支
        /// </summary>
        /// <returns> 年分地支 </returns>
        public virtual int GetDeqiY(int cyclicalYear)
        {
            return GetDeqi(cyclicalYear);
        }

        /// <summary>
        /// 月份地支
        /// </summary>
        /// <returns> 月份地支 </returns>
        public virtual int GetDeqiM(int cyclicalMonth)
        {
            return GetDeqi(cyclicalMonth);
        }

        /// <summary>
        /// 日期地支
        /// </summary>
        /// <returns> 日期地支 </returns>
        public virtual int GetDeqiD(int cyclicalDay)
        {
            return GetDeqi(cyclicalDay);
        }

        /// <summary>
        /// 获得地支
        /// </summary>
        /// <param name="cyclicalNumber"> </param>
        /// <returns> 地支 (数字) </returns>
        internal static int GetDeqi(int cyclicalNumber)
        {
            return cyclicalNumber % 12;
        }

        /// <summary>
        /// 获得天干
        /// </summary>
        /// <param name="cyclicalNumber"> </param>
        /// <returns> 天干 (数字) </returns>
        internal static int GetTianan(int cyclicalNumber)
        {
            return cyclicalNumber % 10;
        }

        /// <summary>
        /// 黑色星期五
        /// </summary>
        /// <returns> 是否黑色星期五 </returns>
        public virtual bool IsBlackFriday(DateTime calendar)
        {
            return (day == 13 && (int)calendar.DayOfWeek == 6);
        }

        /// <summary>
        /// 是否是今日
        /// </summary>
        /// <returns> 是否是今日 </returns>
        public virtual bool IsToday(DateTime calendar)
        {
            var clr = new DateTime();
            return clr.Year == calendar.Year && clr.Month == calendar.Month && clr.Day == calendar.Day;
        }


        public static Lunar SuitAndTaboo(Lunar lunar, int cM, int cD)
        {

            var month = (cM - 2) % 12; ////3
            var jianxing = ((cD - month) % 12).ToString(); ////4
            var jiazi = ((cD % 60)).ToString(); ////43

            if (jianxing.Length == 1)
            {
                jianxing = "0" + jianxing;
            }
            if (jiazi.Length == 1)
            {
                jiazi = "0" + jiazi;
            }
            var key = jianxing + "" + jiazi;
            var single = LunarUtils.BuildLunarMap()[key];
            if (null != single && single.Count > 0)
            {
                //宜
                var suit = single["Y"];
                //禁忌
                var taboo = single["J"];
                lunar.setSuit(suit).setTaboo(taboo);
            }
            return lunar;
        }
        // ====================== 中文日期//农历日期
        public static string CnDay(int d)
        {
            string s;
            switch (d)
            {
                case 10:
                    s = "初十";
                    break;
                case 20:
                    s = "二十";
                    break;
                case 30:
                    s = "三十";
                    break;
                default:
                    s = LunarUtils.DayFirstNumber[(int)Math.Floor((decimal)d / 10)];
                    s += LunarUtils.DayNumber[d % 10];
                    break;
            }
            return s;
        }

        internal static string CYear(int y)
        {
            var s = " ";
            while (y > 0)
            {
                var d = y % 10;
                y = (y - d) / 10;
                s = LunarUtils.YearName[d] + s;
            }
            return (s);
        }

        /// <summary>
        /// 返回农历日期字符串
        /// </summary>
        /// <returns> 农历日期字符串 </returns>
        public virtual string LunarYearString => GetLunarYearString(lunarYear);

        /// <summary>
        /// 当前农历月是否是大月
        /// </summary>
        /// <returns> 当前农历月是大月 </returns>
        public virtual bool BigMonth => MaxDayInMonth > 29;

        /// <summary>
        /// 当前农历月有多少天
        /// </summary>
        /// <returns> 当前农历月有多少天 </returns>
        public virtual int MaxDayInMonth => maxDayInMonth;

        /// <summary>
        /// 返回农历年的总天数
        /// </summary>
        /// <param name="lunarYear">
        ///            指定农历年份(数字) </param>
        /// <returns> 该农历年的总天数(数字) </returns>
        internal static int GetLunarYearDays(int lunarYear)
        {
            // 按小月计算,农历年最少有12 * 29 = 348天
            int daysInLunarYear = 348;
            // 数据表中,每个农历年用16bit来表示,
            // 前12bit分别表示12个月份的大小月,最后4bit表示闰月
            // 每个大月累加一天
            for (int i = 0x8000; i > 0x8; i >>= 1)
            {
                daysInLunarYear += ((LunarUtils.LunarInfo[lunarYear - 1900] & i) != 0) ? 1 : 0;
            }
            // 加上闰月天数
            daysInLunarYear += GetLunarLeapDays(lunarYear);

            return daysInLunarYear;
        }

        /// <summary>
        /// 返回农历年闰月的天数
        /// </summary>
        /// <param name="lunarYear">
        ///            指定农历年份(数字) </param>
        /// <returns> 该农历年闰月的天数(数字) </returns>
        internal static int GetLunarLeapDays(int lunarYear)
        {
            // 下一年最后4bit为1111,返回30(大月)
            // 下一年最后4bit不为1111,返回29(小月)
            // 若该年没有闰月,返回0
            return GetLunarLeapMonth(lunarYear) > 0 ? ((LunarUtils.LunarInfo[lunarYear - 1899] & 0xf) == 0xf ? 30 : 29) : 0;
        }

        /// <summary>
        /// 返回农历年闰月月份
        /// </summary>
        /// <param name="lunarYear">
        ///            指定农历年份(数字) </param>
        /// <returns> 该农历年闰月的月份(数字,没闰返回0) </returns>
        internal static int GetLunarLeapMonth(int lunarYear)
        {
            // 数据表中,每个农历年用16bit来表示,
            // 前12bit分别表示12个月份的大小月,最后4bit表示闰月
            // 若4bit全为1或全为0,表示没闰, 否则4bit的值为闰月月份
            var leapMonth = LunarUtils.LunarInfo[lunarYear - 1900] & 0xf;
            leapMonth = (leapMonth == 0xf ? 0 : leapMonth);
            return leapMonth;
        }

        /// <summary>
        /// 返回农历年正常月份的总天数
        /// </summary>
        /// <param name="lunarYear">
        ///            指定农历年份(数字) </param>
        /// <param name="lunarMonth">
        ///            指定农历月份(数字) </param>
        /// <returns> 该农历年闰月的月份(数字,没闰返回0) </returns>
        internal static int GetLunarMonthDays(int lunarYear, int lunarMonth)
        {
            // 数据表中,每个农历年用16bit来表示,
            // 前12bit分别表示12个月份的大小月,最后4bit表示闰月
            var daysInLunarMonth = ((LunarUtils.LunarInfo[lunarYear - 1900] & (0x10000 >> lunarMonth)) != 0) ? 30 : 29;
            return daysInLunarMonth;
        }

        /// <summary>
        /// 返回公历年节气的日期
        /// </summary>
        /// <param name="solarYear">
        ///            指定公历年份(数字) </param>
        /// <param name="index">
        ///            指定节气序号(数字,0从小寒算起) </param>
        /// <returns> 日期(数字,所在月份的第几天) </returns>
        internal static int GetSolarTermDay(int solarYear, int index)
        {

            return GetUtcDay(GetSolarTermCalendar(solarYear, index));
        }

        /// <summary>
        /// 返回公历年节气的日期
        /// </summary>
        /// <param name="solarYear">
        ///            指定公历年份(数字) </param>
        /// <param name="index">
        ///            指定节气序号(数字,0从小寒算起) </param>
        /// <returns> 日期(数字,所在月份的第几天) </returns>
        public static DateTime GetSolarTermCalendar(int solarYear, int index)
        {
            var l = (long)31556925974.7 * (solarYear - 1900) + LunarUtils.SolarTermInfo[index] * 60000L;
            l = l + Utc(1900, 1, 6, 2, 5, 0);
            return new DateTime(1970, 1, 1, 8, 0, 0).AddMilliseconds(l);
        }

        /// <summary>
        /// 取 Date 对象中用全球标准时间 (UTC) 表示的日期
        /// </summary>
        /// <param name="date">
        ///            指定日期 </param>
        /// <returns> UTC 全球标准时间 (UTC) 表示的日期 </returns>
        public static int GetUtcDay(DateTime date)
        {
            return date.ToUniversalTime().Day;
        }

        /// <summary>
        /// 返回全球标准时间 (UTC) (或 GMT) 的 1970 年 1 月 1 日到所指定日期之间所间隔的毫秒数。
        /// </summary>
        /// <param name="y">
        ///            指定年份 </param>
        /// <param name="m">
        ///            指定月份 </param>
        /// <param name="d">
        ///            指定日期 </param>
        /// <param name="h">
        ///            指定小时 </param>
        /// <param name="min">
        ///            指定分钟 </param>
        /// <param name="sec">
        ///            指定秒数 </param>
        /// <returns> 全球标准时间 (UTC) (或 GMT) 的 1970 年 1 月 1 日到所指定日期之间所间隔的毫秒数 </returns>
        public static long Utc(int y, int m, int d, int h, int min, int sec)
        {
            var dt19700101 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var dateTime = new DateTimeOffset(new DateTime(y, m, d, h, min, sec));
            return (long)(dateTime - dt19700101).TotalMilliseconds;
        }

        /// <summary>
        /// 返回指定数字的农历年份表示字符串
        /// </summary>
        /// <param name="lunarYear">
        ///            农历年份(数字,0为甲子) </param>
        /// <returns> 农历年份字符串 </returns>
        internal static string GetLunarYearString(int lunarYear)
        {
            return GetCyclicalString(lunarYear - 1900 + 36);
        }

        /// <summary>
        /// 补充位数，把数字转换成String </summary>
        /// <param name="number">	待转换的数字 </param>
        /// <param name="count">		补充为几位 </param>
        /// <param name="m">			true:前面补充，false：后面补充 </param>
        /// <param name="marker">	补充的内容{占位}
        /// @return </param>
        public static string Replenish(int number, int count, bool m, string marker)
        {
            var result = number.ToString();
            if (result.Length >= count)
            {
                return result;
            }
            //补充位数
            for (var i = 1; i < (count - result.Length); i++)
            {
                marker += marker;
            }
            return m ? marker + result : result + marker;
        }

        //默认从前面补充，用0补充
        public static string Replenish(int number, int count)
        {
            return Replenish(number, count, true, "0");
        }

    }
}
