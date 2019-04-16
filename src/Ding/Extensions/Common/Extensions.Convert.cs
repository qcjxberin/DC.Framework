using System;
using System.Collections.Generic;
using System.Linq;

namespace Ding {
    /// <summary>
    /// 系统扩展 - 类型转换
    /// </summary>
    public static partial class Extensions {
        #region SafeString(安全转换为字符串)

        /// <summary>
        /// 安全转换为字符串，去除两端空格，当值为null时返回""
        /// </summary>
        /// <param name="input">输入值</param>
        public static string SafeString( this object input ) {
            return input?.ToString().Trim() ?? string.Empty;
        }

        #endregion

        #region ToBool(转换为bool)

        /// <summary>
        /// 转换为bool
        /// </summary>
        /// <param name="obj">数据</param>
        public static bool ToBool( this string obj ) {
            return Ding.Helpers.Convert.ToBool( obj );
        }

        /// <summary>
        /// 转换为可空bool
        /// </summary>
        /// <param name="obj">数据</param>
        public static bool? ToBoolOrNull( this string obj ) {
            return Ding.Helpers.Convert.ToBoolOrNull( obj );
        }

        #endregion

        #region ToShort(转换为short)
        /// <summary>
        /// 转换为short
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static short ToShort( this string obj)
        {
            return Ding.Helpers.Convert.ToShort(obj);
        }

        /// <summary>
        /// 转换为可空short
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static short? ToShortOrNull( this string obj)
        {
            return Ding.Helpers.Convert.ToShortOrNull(obj);
        }

        #endregion

        #region ToInt(转换为int)
        /// <summary>
        /// 转换为int
        /// </summary>
        /// <param name="obj">数据</param>
        public static int ToInt( this string obj ) {
            return Ding.Helpers.Convert.ToInt( obj );
        }

        /// <summary>
        /// 转换为可空int
        /// </summary>
        /// <param name="obj">数据</param>
        public static int? ToIntOrNull( this string obj ) {
            return Ding.Helpers.Convert.ToIntOrNull( obj );
        }

        #endregion

        #region ToLong(转换为long)
        /// <summary>
        /// 转换为long
        /// </summary>
        /// <param name="obj">数据</param>
        public static long ToLong( this string obj ) {
            return Ding.Helpers.Convert.ToLong( obj );
        }

        /// <summary>
        /// 转换为可空long
        /// </summary>
        /// <param name="obj">数据</param>
        public static long? ToLongOrNull( this string obj ) {
            return Ding.Helpers.Convert.ToLongOrNull( obj );
        }

        #endregion

        #region ToDouble(转换为double)

        /// <summary>
        /// 转换为double
        /// </summary>
        /// <param name="obj">数据</param>
        public static double ToDouble( this string obj ) {
            return Ding.Helpers.Convert.ToDouble( obj );
        }

        /// <summary>
        /// 转换为可空double
        /// </summary>
        /// <param name="obj">数据</param>
        public static double? ToDoubleOrNull( this string obj ) {
            return Ding.Helpers.Convert.ToDoubleOrNull( obj );
        }

        #endregion

        #region ToDecimal(转换为decimal)

        /// <summary>
        /// 转换为decimal
        /// </summary>
        /// <param name="obj">数据</param>
        public static decimal ToDecimal( this string obj ) {
            return Ding.Helpers.Convert.ToDecimal( obj );
        }

        /// <summary>
        /// 转换为可空decimal
        /// </summary>
        /// <param name="obj">数据</param>
        public static decimal? ToDecimalOrNull( this string obj ) {
            return Ding.Helpers.Convert.ToDecimalOrNull( obj );
        }

        #endregion

        #region ToDate(转换为日期)

        /// <summary>
        /// 转换为日期
        /// </summary>
        /// <param name="obj">数据</param>
        public static DateTime ToDate( this string obj ) {
            return Ding.Helpers.Convert.ToDate( obj );
        }

        /// <summary>
        /// 转换为可空日期
        /// </summary>
        /// <param name="obj">数据</param>
        public static DateTime? ToDateOrNull( this string obj ) {
            return Ding.Helpers.Convert.ToDateOrNull( obj );
        }

        #endregion

        #region ToGuid(转换为Guid)

        /// <summary>
        /// 转换为Guid
        /// </summary>
        /// <param name="obj">数据</param>
        public static Guid ToGuid( this string obj ) {
            return Ding.Helpers.Convert.ToGuid( obj );
        }

        /// <summary>
        /// 转换为可空Guid
        /// </summary>
        /// <param name="obj">数据</param>
        public static Guid? ToGuidOrNull( this string obj ) {
            return Ding.Helpers.Convert.ToGuidOrNull( obj );
        }

        /// <summary>
        /// 转换为Guid集合
        /// </summary>
        /// <param name="obj">数据,范例: "83B0233C-A24F-49FD-8083-1337209EBC9A,EAB523C6-2FE7-47BE-89D5-C6D440C3033A"</param>
        public static List<Guid> ToGuidList( this string obj ) {
            return Ding.Helpers.Convert.ToGuidList( obj );
        }

        /// <summary>
        /// 转换为Guid集合
        /// </summary>
        /// <param name="obj">字符串集合</param>
        public static List<Guid> ToGuidList( this IList<string> obj ) {
            if( obj == null )
                return new List<Guid>();
            return obj.Select( t => t.ToGuid() ).ToList();
        }

        #endregion

        #region ToSnakeCase(将字符串转换为蛇形策略)

        /// <summary>
        /// 将字符串转换为蛇形策略
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string ToSnakeCase(this string str)
        {
            return Ding.Helpers.String.ToSnakeCase(str);
        }

        #endregion

        #region ToCamelCase(将字符串转换为骆驼策略)

        /// <summary>
        /// 将字符串转换为骆驼策略
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string ToCamelCase(this string str)
        {
            return Ding.Helpers.String.ToCamelCase(str);
        }

        #endregion
    }
}
