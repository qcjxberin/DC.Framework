﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ding.Datas.Tests.Commons.Datas.Pos;

namespace Ding.Datas.Tests.Ef.SqlServer.Mappings {
    /// <summary>
    /// 商品持久化对象映射配置
    /// </summary>
    public class ProductPoMap : Util.Datas.Ef.SqlServer.AggregateRootMap<ProductPo> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<ProductPo> builder ) {
            builder.ToTable( "Products", "Productions" );
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<ProductPo> builder ) {
            base.MapProperties( builder );
            //商品编号
            builder.Property( t => t.Id )
                .HasColumnName( "ProductId" );
        }
    }
}
