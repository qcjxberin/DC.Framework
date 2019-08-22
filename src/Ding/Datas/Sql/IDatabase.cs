using System.Data;

namespace Ding.Datas.Sql {
    /// <summary>
    /// 数据库
    /// </summary>
    [Ding.Aspects.Ignore]
    public interface IDatabase {
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        IDbConnection GetConnection();
    }
}
