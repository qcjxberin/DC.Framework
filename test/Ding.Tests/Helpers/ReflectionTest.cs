using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Ding.Domains;
using Ding.Utils.Helpers;
using Ding.Tests.Samples;
using Xunit;

namespace Ding.Tests.Helpers {
    /// <summary>
    /// 测试反射操作
    /// </summary>
    public class ReflectionTest {
        /// <summary>
        /// 初始化测试
        /// </summary>
        public ReflectionTest() {
            _sample = new Sample();
        }

        /// <summary>
        /// 测试样例
        /// </summary>
        private readonly Sample _sample;

        /// <summary>
        /// 测试获取类成员描述
        /// </summary>
        [Fact]
        public void TestGetDescription() {
            Assert.Equal( "", Ding.Utils.Helpers.Reflection.GetDescription<EnumSample>( "X" ) );
            Assert.Equal( "A", Ding.Utils.Helpers.Reflection.GetDescription<EnumSample>( "A" ) );
            Assert.Equal( "B2", Ding.Utils.Helpers.Reflection.GetDescription<EnumSample>( "B" ) );
            Assert.Equal( "IntValue", Ding.Utils.Helpers.Reflection.GetDescription<Sample>( "IntValue" ) );
        }

        /// <summary>
        /// 测试获取类描述
        /// </summary>
        [Fact]
        public void TestGetDescription_Class() {
            Assert.Equal( "测试样例", Ding.Utils.Helpers.Reflection.GetDescription<Sample>() );
            Assert.Equal( "Sample2", Ding.Utils.Helpers.Reflection.GetDescription<Sample2>() );
        }

        /// <summary>
        /// 测试显示名
        /// </summary>
        [Fact]
        public void TestGetDisplayName() {
            Assert.Equal( "", Ding.Utils.Helpers.Reflection.GetDisplayName<Sample>() );
            Assert.Equal( "测试样例2", Ding.Utils.Helpers.Reflection.GetDisplayName<Sample2>() );
        }

        /// <summary>
        /// 测试获取类描述或显示名
        /// </summary>
        [Fact]
        public void TestGetDescriptionOrDisplayName() {
            Assert.Equal( "测试样例", Ding.Utils.Helpers.Reflection.GetDisplayNameOrDescription<Sample>() );
            Assert.Equal( "测试样例2", Ding.Utils.Helpers.Reflection.GetDisplayNameOrDescription<Sample2>() );
            Assert.Equal( "测试样例", Ding.Utils.Helpers.Reflection.GetDisplayNameOrDescription<Sample>() );
        }

        /// <summary>
        /// 测试是否布尔类型
        /// </summary>
        [Fact]
        public void TestIsBool() {
            Assert.True( Ding.Utils.Helpers.Reflection.IsBool( _sample.BoolValue.GetType().GetTypeInfo() ), "BoolValue GetType" );
            Assert.True( Ding.Utils.Helpers.Reflection.IsBool( _sample.GetType().GetMember( "BoolValue" )[0] ), "BoolValue" );
            Assert.True( Ding.Utils.Helpers.Reflection.IsBool( _sample.GetType().GetMember( "NullableBoolValue" )[0] ), "NullableBoolValue" );
            Assert.False( Ding.Utils.Helpers.Reflection.IsBool( _sample.GetType().GetMember( "EnumValue" )[0] ), "EnumValue" );
        }

        /// <summary>
        /// 测试是否枚举类型
        /// </summary>
        [Fact]
        public void TestIsEnum() {
            Assert.True( Ding.Utils.Helpers.Reflection.IsEnum( _sample.EnumValue.GetType().GetTypeInfo() ), "EnumValue GetType" );
            Assert.True( Ding.Utils.Helpers.Reflection.IsEnum( _sample.GetType().GetMember( "EnumValue" )[0] ), "EnumValue" );
            Assert.True( Ding.Utils.Helpers.Reflection.IsEnum( _sample.GetType().GetMember( "NullableEnumValue" )[0] ), "NullableEnumValue" );
            Assert.False( Ding.Utils.Helpers.Reflection.IsEnum( _sample.GetType().GetMember( "BoolValue" )[0] ), "BoolValue" );
            Assert.False( Ding.Utils.Helpers.Reflection.IsEnum( _sample.GetType().GetMember( "NullableBoolValue" )[0] ), "NullableBoolValue" );
        }

        /// <summary>
        /// 测试是否日期类型
        /// </summary>
        [Fact]
        public void TestIsDate() {
            Assert.True( Ding.Utils.Helpers.Reflection.IsDate( _sample.DateValue.GetType().GetTypeInfo() ), "DateValue GetType" );
            Assert.True( Ding.Utils.Helpers.Reflection.IsDate( _sample.GetType().GetMember( "DateValue" )[0] ), "DateValue" );
            Assert.True( Ding.Utils.Helpers.Reflection.IsDate( _sample.GetType().GetMember( "NullableDateValue" )[0] ), "NullableDateValue" );
            Assert.False( Ding.Utils.Helpers.Reflection.IsDate( _sample.GetType().GetMember( "EnumValue" )[0] ), "EnumValue" );
        }

        /// <summary>
        /// 测试是否整型
        /// </summary>
        [Fact]
        public void TestIsInt() {
            Assert.True( Ding.Utils.Helpers.Reflection.IsInt( _sample.IntValue.GetType().GetTypeInfo() ), "IntValue GetType" );
            Assert.True( Ding.Utils.Helpers.Reflection.IsInt( _sample.GetType().GetMember( "IntValue" )[0] ), "IntValue" );
            Assert.True( Ding.Utils.Helpers.Reflection.IsInt( _sample.GetType().GetMember( "NullableIntValue" )[0] ), "NullableIntValue" );

            Assert.True( Ding.Utils.Helpers.Reflection.IsInt( _sample.ShortValue.GetType().GetTypeInfo() ), "ShortValue GetType" );
            Assert.True( Ding.Utils.Helpers.Reflection.IsInt( _sample.GetType().GetMember( "ShortValue" )[0] ), "ShortValue" );
            Assert.True( Ding.Utils.Helpers.Reflection.IsInt( _sample.GetType().GetMember( "NullableShortValue" )[0] ), "NullableShortValue" );

            Assert.True( Ding.Utils.Helpers.Reflection.IsInt( _sample.LongValue.GetType().GetTypeInfo() ), "LongValue GetType" );
            Assert.True( Ding.Utils.Helpers.Reflection.IsInt( _sample.GetType().GetMember( "LongValue" )[0] ), "LongValue" );
            Assert.True( Ding.Utils.Helpers.Reflection.IsInt( _sample.GetType().GetMember( "NullableLongValue" )[0] ), "NullableLongValue" );
        }

        /// <summary>
        /// 测试是否数值类型
        /// </summary>
        [Fact]
        public void TestIsNumber() {
            Assert.True( Ding.Utils.Helpers.Reflection.IsNumber( _sample.DoubleValue.GetType().GetTypeInfo() ), "DoubleValue GetType" );
            Assert.True( Ding.Utils.Helpers.Reflection.IsNumber( _sample.GetType().GetMember( "DoubleValue" )[0] ), "DoubleValue" );
            Assert.True( Ding.Utils.Helpers.Reflection.IsNumber( _sample.GetType().GetMember( "NullableDoubleValue" )[0] ), "NullableDoubleValue" );

            Assert.True( Ding.Utils.Helpers.Reflection.IsNumber( _sample.DecimalValue.GetType().GetTypeInfo() ), "DecimalValue GetType" );
            Assert.True( Ding.Utils.Helpers.Reflection.IsNumber( _sample.GetType().GetMember( "DecimalValue" )[0] ), "DecimalValue" );
            Assert.True( Ding.Utils.Helpers.Reflection.IsNumber( _sample.GetType().GetMember( "NullableDecimalValue" )[0] ), "NullableDecimalValue" );

            Assert.True( Ding.Utils.Helpers.Reflection.IsNumber( _sample.FloatValue.GetType().GetTypeInfo() ), "FloatValue GetType" );
            Assert.True( Ding.Utils.Helpers.Reflection.IsNumber( _sample.GetType().GetMember( "FloatValue" )[0] ), "FloatValue" );
            Assert.True( Ding.Utils.Helpers.Reflection.IsNumber( _sample.GetType().GetMember( "NullableFloatValue" )[0] ), "NullableFloatValue" );

            Assert.True( Ding.Utils.Helpers.Reflection.IsNumber( _sample.IntValue.GetType().GetTypeInfo() ), "IntValue GetType" );
            Assert.True( Ding.Utils.Helpers.Reflection.IsNumber( _sample.GetType().GetMember( "IntValue" )[0] ), "IntValue" );
            Assert.True( Ding.Utils.Helpers.Reflection.IsNumber( _sample.GetType().GetMember( "NullableIntValue" )[0] ), "NullableIntValue" );
        }

        /// <summary>
        /// 测试是否集合
        /// </summary>
        [Fact]
        public void TestIsCollection() {
            Assert.True( Ding.Utils.Helpers.Reflection.IsCollection( _sample.StringArray.GetType() ) );
        }

        /// <summary>
        /// 测试是否泛型集合
        /// </summary>
        [Fact]
        public void TestIsGenericCollection() {
            Assert.True( Ding.Utils.Helpers.Reflection.IsGenericCollection( _sample.StringList.GetType() ) );
        }

        /// <summary>
        /// 测试获取公共属性列表
        /// </summary>
        [Fact]
        public void TestGetPublicProperties() {
            Sample4 sample = new Sample4 {
                A = "1",
                B = "2"
            };
            var items = Ding.Utils.Helpers.Reflection.GetPublicProperties( sample );
            Assert.Equal( 2, items.Count );
            Assert.Equal( "A", items[0].Text );
            Assert.Equal( "1", items[0].Value );
            Assert.Equal( "B", items[1].Text );
            Assert.Equal( "2", items[1].Value );
        }

        /// <summary>
        /// 获取顶级基类
        /// </summary>
        [Fact]
        public void TestGetTopBaseType() {
            Assert.Null( Reflection.GetTopBaseType( null ) );
            Assert.Contains("Ding.Domains.DomainBase", Reflection.GetTopBaseType<User>().FullName );
            Assert.Contains("Ding.Domains.DomainBase", Reflection.GetTopBaseType<Ding.Domains.DomainBase<User>>().FullName );
            Assert.Contains("Ding.Domains.IEntity", Reflection.GetTopBaseType<IEntity>().FullName );
        }
    }
}
