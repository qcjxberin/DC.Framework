using Ding.Datas.Stores;
using Ding.Datas.Tests.Commons.Datas.Pos;

namespace Ding.Datas.Tests.Ef.SqlServer.Stores {
    /// <summary>
    /// 商品持久化存储
    /// </summary>
    public interface IProductPoStore : IStore<ProductPo, int> {
    }
}
