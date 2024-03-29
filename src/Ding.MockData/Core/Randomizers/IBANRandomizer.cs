﻿using Ding.MockData.Abstractions.Randomizers;
using Ding.MockData.Core.Options;
using Ding.MockData.Datas;
using Ding.MockData.Datas.Models;
using Ding.MockData.Extensions;
using Ding.MockData.Internals.Generators;
using System;
using System.Linq;

namespace Ding.MockData.Core.Randomizers
{
    /// <summary>
    /// 银行账号随机生成器
    /// </summary>
    public class IBANRandomizer : RandomizerBase<IBANFieldOptions>, IStringRandomizer
    {
        /// <summary>
        /// 项生成器
        /// </summary>
        private readonly RandomItemFromListGenerator<IBAN> _itemGenerator;

        /// <summary>
        /// 初始化一个<see cref="IBANRandomizer"/>类型的实例
        /// </summary>
        /// <param name="options">银行账号配置</param>
        public IBANRandomizer(IBANFieldOptions options) : base(options)
        {
            Func<IBAN, bool> predicate = null;
            if (!string.IsNullOrEmpty(options.CountryCode))
            {
                predicate = (iban) => iban.CountryCode == options.CountryCode;
            }

            var list = CommonData.Instance.IBANs;
            switch (options.Type)
            {
                case "BBAN":
                    list = CommonData.Instance.BBANs;
                    break;
                case "BOTH":
                    list = list.Union(CommonData.Instance.BBANs);
                    break;
            }

            _itemGenerator = new RandomItemFromListGenerator<IBAN>(list, predicate);
        }

        /// <summary>
        /// 生成
        /// </summary>
        /// <returns></returns>
        public string Generate()
        {
            if (IsNull())
            {
                return null;
            }

            var iban = _itemGenerator.Generate();
            return iban.Generator.Generate();
        }

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="upperCase">是否大写</param>
        /// <returns></returns>
        public string Generate(bool upperCase)
        {
            return Generate().ToCasedInvariant(upperCase);
        }
    }
}
