﻿using Ding.Helpers;
using Microsoft.Extensions.Options;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ding.Captcha.Extensions
{
    /// <summary>
    /// DES加密解密
    /// </summary>
    public static class DesExtension
    {
        /// <summary>
        /// 加密密钥
        /// </summary>
        private static string SecretKey = "GICISKYNET";

        /// <summary>
        /// 默认UTF8编码
        /// </summary>
        private static readonly Encoding Default = Encoding.UTF8;

        static DesExtension()
        {
            var options = Ioc.Create<IOptions<CaptchaOptions>>();
            SecretKey = options.Value.SecretKey;
        }

        /// <summary>
        /// DES 加密
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static async Task<string> EncryptAsync(this string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return string.Empty;
            }

            using (var p = new DESCryptoServiceProvider())
            {
                p.IV = Default.GetBytes(SecretKey);
                p.Key = Default.GetBytes(SecretKey);
                using (var ct = p.CreateEncryptor(p.IV, p.Key))
                {
                    var temp = Default.GetBytes(val);
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write))
                        {
                            await cs.WriteAsync(temp, 0, temp.Length);
                            await cs.FlushAsync();
                            cs.Close();
                        }

                        return System.Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        /// <summary>
        /// DES 解密
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static async Task<string> DecryptAsync(this string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return string.Empty;
            }

            using (var p = new DESCryptoServiceProvider())
            {
                p.IV = Default.GetBytes(SecretKey);
                p.Key = Default.GetBytes(SecretKey);
                using (var ct = p.CreateDecryptor(p.IV, p.Key))
                {
                    val = WebUtility.UrlDecode(val);
                    val = WebUtility.UrlDecode(val);
                    var temp = System.Convert.FromBase64String(val);
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write))
                        {
                            await cs.WriteAsync(temp, 0, temp.Length);
                            await cs.FlushAsync();
                            cs.Close();
                        }
                        return Default.GetString(ms.ToArray());
                    }
                }
            }
        }
    }
}
