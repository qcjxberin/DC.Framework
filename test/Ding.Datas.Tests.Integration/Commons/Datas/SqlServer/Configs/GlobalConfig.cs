using Xunit;

namespace Ding.Datas.Tests.Commons.Datas.SqlServer.Configs {
    /// <summary>
    /// 全局测试配置
    /// </summary>
    [CollectionDefinition( "GlobalConfig" )]
    public class GlobalConfig : ICollectionFixture<GlobalFixture> {
    }
}
