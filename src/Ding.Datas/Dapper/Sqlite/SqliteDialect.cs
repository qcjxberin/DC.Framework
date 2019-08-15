using Ding.Datas.Sql.Builders.Core;

namespace Ding.Datas.Dapper.Sqlite
{
    /// <summary>
    /// Sqlite方言
    /// </summary>
    public class SqliteDialect : DialectBase
    {
        /// <summary>
        /// 起始转义标识符
        /// </summary>
        public override string OpeningIdentifier => "`";

        /// <summary>
        /// 结束转义标识符
        /// </summary>
        public override string ClosingIdentifier => "`";

        /// <summary>
        /// 获取安全名称
        /// </summary>
        /// <param name="name">名称</param>
        protected override string GetSafeName(string name)
        {
            return $"`{name}`";
        }
    }
}
