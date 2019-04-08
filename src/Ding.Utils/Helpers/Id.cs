using Ding.Utils.IdGenerators.Abstractions;
using Ding.Utils.IdGenerators.Core;
using System;

namespace Ding.Utils.Helpers {
    /// <summary>
    /// 标识生成器
    /// </summary>
    public static class Id {
        /// <summary>
        /// 标识
        /// </summary>
        private static string _id;

        /// <summary>
        /// Guid 生成器
        /// </summary>
        public static IGuidGenerator GuidGenerator { get; set; } = SequentialGuidGenerator.Current;

        /// <summary>
        /// Long 生成器
        /// </summary>
        public static ILongGenerator LongGenerator { get; set; } = SnowflakeIdGenerator.Current;

        /// <summary>
        /// String 生成器
        /// </summary>
        public static IStringGenerator StringGenerator { get; set; } = TimestampIdGenerator.Current;

        /// <summary>
        /// 设置标识
        /// </summary>
        /// <param name="id">Id</param>
        public static void SetId( string id ) {
            _id = id;
        }

        /// <summary>
        /// 重置标识
        /// </summary>
        public static void Reset() {
            _id = null;
        }

        /// <summary>
        /// 创建标识
        /// </summary>
        public static string ObjectId() {
            return string.IsNullOrWhiteSpace( _id ) ? Ding.Utils.IdGenerators.Ids.ObjectId.GenerateNewStringId() : _id;
        }

        /// <summary>
        /// 用Guid创建标识,去掉分隔符
        /// </summary>
        public static string Guid() {
            return string.IsNullOrWhiteSpace( _id ) ? System.Guid.NewGuid().ToString( "N" ) : _id;
        }

        /// <summary>
        /// 获取Guid
        /// </summary>
        public static Guid GetGuid() {
            return string.IsNullOrWhiteSpace( _id ) ? System.Guid.NewGuid() : _id.ToGuid();
        }

        /// <summary>
        /// 创建有序 Guid ID
        /// </summary>
        /// <returns></returns>
        public static Guid SequentialGuid()
        {
            return GuidGenerator.Create();
        }

        /// <summary>
        /// 创建 Long ID
        /// </summary>
        /// <returns></returns>
        public static long GetLong()
        {
            return LongGenerator.Create();
        }

        /// <summary>
        /// 创建 String ID
        /// </summary>
        /// <returns></returns>
        public static string GetString()
        {
            return StringGenerator.Create();
        }

        /// <summary>
        /// 获取13位Id字符串
        /// </summary>
        /// <returns></returns>
        public static string GetIdString()
        {
            return IDGenerator.Instance.Generate;
        }

        /// <summary>
        /// 生成sessionid
        /// </summary>
        /// <returns></returns>
        public static string GenerateSid()
        {
            long i = 1;
            byte[] byteArray = System.Guid.NewGuid().ToByteArray();
            foreach (byte b in byteArray)
            {
                i *= b + 1;
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
    }
}
