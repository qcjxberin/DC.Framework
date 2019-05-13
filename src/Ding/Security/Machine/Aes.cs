using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Ding.Security
{
    public class Aes
    {
#pragma warning disable CS1573 // 参数“iv”在“Aes.Encrypt(string, byte[], byte[])”的 XML 注释中没有匹配的 param 标记(但其他参数有)
#pragma warning disable CS1573 // 参数“key”在“Aes.Encrypt(string, byte[], byte[])”的 XML 注释中没有匹配的 param 标记(但其他参数有)
        /// <summary>
        /// 以RC2格式编码。
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>加密字符串</returns>
        public static string Encrypt(string value, byte[] key, byte[] iv)
#pragma warning restore CS1573 // 参数“key”在“Aes.Encrypt(string, byte[], byte[])”的 XML 注释中没有匹配的 param 标记(但其他参数有)
#pragma warning restore CS1573 // 参数“iv”在“Aes.Encrypt(string, byte[], byte[])”的 XML 注释中没有匹配的 param 标记(但其他参数有)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            byte[] objInputByteArray = Encoding.UTF8.GetBytes(value);
            AesCryptoServiceProvider objRC2CryptoServiceProvider = new AesCryptoServiceProvider();


            ICryptoTransform objICryptoTransform = objRC2CryptoServiceProvider.CreateEncryptor(key, iv);

            using (MemoryStream objMemoryStream = new MemoryStream())
            using (CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objICryptoTransform, CryptoStreamMode.Write))
            {
                objCryptoStream.Write(objInputByteArray, 0, objInputByteArray.Length);
                objCryptoStream.FlushFinalBlock();
                objRC2CryptoServiceProvider.Clear();
                return Convert.ToBase64String(objMemoryStream.ToArray());
            }
        }

#pragma warning disable CS1573 // 参数“iv”在“Aes.Decrypt(string, byte[], byte[])”的 XML 注释中没有匹配的 param 标记(但其他参数有)
#pragma warning disable CS1573 // 参数“key”在“Aes.Decrypt(string, byte[], byte[])”的 XML 注释中没有匹配的 param 标记(但其他参数有)
        /// <summary>
        /// 用RC2格式解码。
        /// </summary>
        /// <param name="value">要解码的字符串</param>
        /// <returns>解码字符串</returns>
        public static string Decrypt(string value, byte[] key, byte[] iv)
#pragma warning restore CS1573 // 参数“key”在“Aes.Decrypt(string, byte[], byte[])”的 XML 注释中没有匹配的 param 标记(但其他参数有)
#pragma warning restore CS1573 // 参数“iv”在“Aes.Decrypt(string, byte[], byte[])”的 XML 注释中没有匹配的 param 标记(但其他参数有)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            byte[] objInputByteArray = Convert.FromBase64String(value);
            AesCryptoServiceProvider objRC2CryptoServiceProvider = new AesCryptoServiceProvider();
            ICryptoTransform objICryptoTransform = objRC2CryptoServiceProvider.CreateDecryptor(key, iv);

            using (MemoryStream objMemoryStream = new MemoryStream())
            using (CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objICryptoTransform, CryptoStreamMode.Write))
            {
                objCryptoStream.Write(objInputByteArray, 0, objInputByteArray.Length);
                objCryptoStream.FlushFinalBlock();
                objRC2CryptoServiceProvider.Clear();
                return Encoding.UTF8.GetString(objMemoryStream.ToArray());
            }
        }

        public static RCSIVKey GetKeyIV()
        {
            AesCryptoServiceProvider rc2CryptoServiceProvider = new AesCryptoServiceProvider();
            rc2CryptoServiceProvider.GenerateIV();
            rc2CryptoServiceProvider.GenerateKey();
            return new RCSIVKey(rc2CryptoServiceProvider.Key, rc2CryptoServiceProvider.IV);
        }

    }

    public struct RCSIVKey
    {
        public RCSIVKey(byte[] key, byte[] iv)
        {
            IV = iv;
            Key = key;
        }

        public byte[] IV { get; }

        public byte[] Key { get; }
    }
}
