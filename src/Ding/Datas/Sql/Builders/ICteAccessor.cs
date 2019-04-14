using System.Collections.Generic;
using Ding.Datas.Sql.Builders.Core;

namespace Ding.Datas.Sql.Builders {
    /// <summary>
    /// 公用表表达式CTE操作访问器
    /// </summary>
    public interface ICteAccessor {
        /// <summary>
        /// 公用表表达式CTE集合
        /// </summary>
        List<BuilderItem> CteItems { get; }
    }
}
