using System;
using System.Data;
using System.Threading.Tasks;

namespace Ding.Datas.Sql {
    /// <summary>
    /// Sql查询对象扩展 - 查询相关
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 获取字符串值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<string> ToStringAsync( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return ( await sqlQuery.ToScalarAsync( connection ) ).SafeString();
        }

        /// <summary>
        /// 获取整型值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static int ToInt( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToInt( sqlQuery.ToScalar( connection ) );
        }

        /// <summary>
        /// 获取整型值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<int> ToIntAsync( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToInt( await sqlQuery.ToScalarAsync( connection ) );
        }

        /// <summary>
        /// 获取可空整型值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static int? ToIntOrNull( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToIntOrNull( sqlQuery.ToScalar( connection ) );
        }

        /// <summary>
        /// 获取可空整型值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<int?> ToIntOrNullAsync( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToIntOrNull( await sqlQuery.ToScalarAsync( connection ) );
        }

        /// <summary>
        /// 获取float值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static float ToFloat( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToFloat( sqlQuery.ToScalar( connection ) );
        }

        /// <summary>
        /// 获取float值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<float> ToFloatAsync( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToFloat( await sqlQuery.ToScalarAsync( connection ) );
        }

        /// <summary>
        /// 获取可空float值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static float? ToFloatOrNull( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToFloatOrNull( sqlQuery.ToScalar( connection ) );
        }

        /// <summary>
        /// 获取可空float值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<float?> ToFloatOrNullAsync( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToFloatOrNull( await sqlQuery.ToScalarAsync( connection ) );
        }

        /// <summary>
        /// 获取double值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static double ToDouble( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToDouble( sqlQuery.ToScalar( connection ) );
        }

        /// <summary>
        /// 获取double值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<double> ToDoubleAsync( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToDouble( await sqlQuery.ToScalarAsync( connection ) );
        }

        /// <summary>
        /// 获取可空double值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static double? ToDoubleOrNull( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToDoubleOrNull( sqlQuery.ToScalar( connection ) );
        }

        /// <summary>
        /// 获取可空double值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<double?> ToDoubleOrNullAsync( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToDoubleOrNull( await sqlQuery.ToScalarAsync( connection ) );
        }

        /// <summary>
        /// 获取decimal值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static decimal ToDecimal( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToDecimal( sqlQuery.ToScalar( connection ) );
        }

        /// <summary>
        /// 获取decimal值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<decimal> ToDecimalAsync( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToDecimal( await sqlQuery.ToScalarAsync( connection ) );
        }

        /// <summary>
        /// 获取可空decimal值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static decimal? ToDecimalOrNull( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToDecimalOrNull( sqlQuery.ToScalar( connection ) );
        }

        /// <summary>
        /// 获取可空decimal值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<decimal?> ToDecimalOrNullAsync( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToDecimalOrNull( await sqlQuery.ToScalarAsync( connection ) );
        }

        /// <summary>
        /// 获取布尔值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static bool ToBool( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToBool( sqlQuery.ToScalar( connection ) );
        }

        /// <summary>
        /// 获取布尔值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<bool> ToBoolAsync( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToBool( await sqlQuery.ToScalarAsync( connection ) );
        }

        /// <summary>
        /// 获取可空布尔值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static bool? ToBoolOrNull( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToBoolOrNull( sqlQuery.ToScalar( connection ) );
        }

        /// <summary>
        /// 获取可空布尔值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<bool?> ToBoolOrNullAsync( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToBoolOrNull( await sqlQuery.ToScalarAsync( connection ) );
        }

        /// <summary>
        /// 获取日期值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static DateTime ToDate( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToDate( sqlQuery.ToScalar( connection ) );
        }

        /// <summary>
        /// 获取日期值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<DateTime> ToDateAsync( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToDate( await sqlQuery.ToScalarAsync( connection ) );
        }

        /// <summary>
        /// 获取可空日期值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static DateTime? ToDateOrNull( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToDateOrNull( sqlQuery.ToScalar( connection ) );
        }

        /// <summary>
        /// 获取可空日期值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<DateTime?> ToDateOrNullAsync( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToDateOrNull( await sqlQuery.ToScalarAsync( connection ) );
        }

        /// <summary>
        /// 获取Guid值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static Guid ToGuid( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToGuid( sqlQuery.ToScalar( connection ) );
        }

        /// <summary>
        /// 获取Guid值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<Guid> ToGuidAsync( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToGuid( await sqlQuery.ToScalarAsync( connection ) );
        }

        /// <summary>
        /// 获取可空Guid值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static Guid? ToGuidOrNull( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToGuidOrNull( sqlQuery.ToScalar( connection ) );
        }

        /// <summary>
        /// 获取可空Guid值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<Guid?> ToGuidOrNullAsync( this ISqlQuery sqlQuery, IDbConnection connection = null ) {
            return Ding.Utils.Helpers.Conv.ToGuidOrNull( await sqlQuery.ToScalarAsync( connection ) );
        }
    }
}
