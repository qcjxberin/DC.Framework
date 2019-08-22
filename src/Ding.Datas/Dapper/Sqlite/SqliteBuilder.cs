using Ding.Datas.Sql;
using Ding.Datas.Sql.Builders;
using Ding.Datas.Sql.Builders.Core;
using Ding.Datas.Sql.Matedatas;

namespace Ding.Datas.Dapper.Sqlite
{
    /// <summary>
    /// Sqlite Sql生成器
    /// </summary>
    public class SqliteBuilder : SqlBuilderBase
    {
        /// <summary>
        /// 初始化Sql生成器
        /// </summary>
        /// <param name="matedata">实体元数据解析器</param>
        /// <param name="tableDatabase">表数据库</param>
        /// <param name="parameterManager">参数管理器</param>
        public SqliteBuilder(IEntityMatedata matedata = null, ITableDatabase tableDatabase = null, IParameterManager parameterManager = null)
            : base(matedata, tableDatabase, parameterManager)
        {
        }

        /// <summary>
        /// 复制Sql生成器
        /// </summary>
        public override ISqlBuilder Clone()
        {
            var sqlBuilder = new SqliteBuilder();
            sqlBuilder.Clone(this);
            return sqlBuilder;
        }

        /// <summary>
        /// 获取Sql方言
        /// </summary>
        protected override IDialect GetDialect()
        {
            return new SqliteDialect();
        }

        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        public override ISqlBuilder New()
        {
            return new SqliteBuilder(EntityMatedata, TableDatabase, ParameterManager);
        }

        /// <summary>
        /// 创建From子句
        /// </summary>
        protected override IFromClause CreateFromClause()
        {
            return new SqliteFromClause(this, GetDialect(), EntityResolver, AliasRegister, TableDatabase);
        }

        /// <summary>
        /// 创建Join子句
        /// </summary>
        protected override IJoinClause CreateJoinClause()
        {
            return new SqliteJoinClause(this, GetDialect(), EntityResolver, AliasRegister, ParameterManager, TableDatabase);
        }

        /// <summary>
        /// 创建分页Sql
        /// </summary>
        protected override string CreateLimitSql()
        {
            return $"Limit {GetLimitParam()} OFFSET {GetOffsetParam()}";
        }

        /// <summary>
        /// 获取CTE关键字
        /// </summary>
        protected override string GetCteKeyWord() {
            return "With Recursive";
        }
    }
}
