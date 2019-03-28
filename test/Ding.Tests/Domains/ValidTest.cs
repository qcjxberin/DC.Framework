﻿using System;
using Autofac;
using Ding.Dependency;
using Ding.Exceptions;
using Ding.Helpers;
using Ding.Tests.Samples;
using Ding.Tests.XUnitHelpers;
using Xunit;
using IContainer = Ding.Dependency.IContainer;

namespace Ding.Tests.Domains {
    /// <summary>
    /// 验证测试
    /// </summary>
    public class ValidTest : IDisposable{
        /// <summary>
        /// 容器
        /// </summary>
        private readonly IContainer _container;
        /// <summary>
        /// 测试初始化
        /// </summary>
        public ValidTest() {
            _container = Ioc.CreateContainer( new IocConfig() );
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            _container.Dispose();
        }

        /// <summary>
        /// 测试添加时验证无效
        /// </summary>
        [Fact]
        public void TestAdd_Invalid() {
            EntitySample entity = new EntitySample();
            var repository = _container.Create<IRepositorySample>();
            AssertHelper.Throws<Warning> ( () => repository.Add( entity ), "名称不能为空" );
        }

        /// <summary>
        /// 测试添加时验证有效
        /// </summary>
        [Fact]
        public void TestAdd_Valid() {
            EntitySample entity = new EntitySample{Name = "a"};
            var repository = _container.Create<IRepositorySample>();
            repository.Add( entity );
        }
    }

    /// <summary>
    /// Ioc配置
    /// </summary>
    public class IocConfig : ConfigBase {
        protected override void Load( ContainerBuilder builder ) {
            builder.AddScoped<IRepositorySample, RepositorySample>();
        }
    }
}
