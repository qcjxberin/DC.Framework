using System;

namespace Ding.Web.FPTemplate.Configuration
{
    /// <summary>
    /// 模板配置
    /// </summary>
    public class EngineConfig : ConfigBase
    {
        /// <summary>
        /// 创建默认配置
        /// </summary>
        /// <returns></returns>
        public static EngineConfig CreateDefault()
        {
            EngineConfig conf = new EngineConfig();
            //conf.CachingProvider = "FivePower.Web.FPTemplate.Caching.MemoryCache";
            conf.ResourceDirectories = new String[0];
            conf.StripWhiteSpace = true;
            conf.TagFlag = '$';
            conf.TagPrefix = "${";
            conf.TagSuffix = "}";
            conf.ThrowExceptions = true;
            conf.IgnoreCase = true;
            conf.TagParsers = Field.RSEOLVER_TYPES;
            conf.Charset = "utf-8";
            return conf;
        }
    }
}