using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Ding.Helpers
{
    /// <summary>
    /// 字符串助手类
    /// </summary>
    public static class StringHelper
    {
        #region Random

        public static readonly char[] UpperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        public static readonly char[] LowerChars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        public static readonly char[] NumberChars = "0123456789".ToCharArray();
        public static readonly char[] SpecialChars = "!@#$%^*&".ToCharArray();

        public static string Generate(int length, bool isIncludeUpper = true, bool isIncludeLower = true,
            bool isIncludeNumber = true, bool isIncludeSpecial = false)
        {
            var chars = new List<char>();

            if (isIncludeUpper)
            {
                chars.AddRange(UpperChars);
            }

            if (isIncludeLower)
            {
                chars.AddRange(LowerChars);
            }

            if (isIncludeNumber)
            {
                chars.AddRange(NumberChars);
            }

            if (isIncludeSpecial)
            {
                chars.AddRange(SpecialChars);
            }

            return GenerateRandom(length, chars.ToArray());
        }

        public static string GenerateRandom(int length, params char[] chars)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), $"{length} cannot be less than zero.");
            }

            if (chars?.Any() != true)
            {
                throw new ArgumentOutOfRangeException(nameof(chars), $"{nameof(chars)} cannot be empty.");
            }

            chars = chars.Distinct().ToArray();

            const int maxLength = 256;

            if (maxLength < chars.Length)
            {
                throw new ArgumentException($"{nameof(chars)} may contain more than {maxLength} chars.", nameof(chars));
            }

            var outOfRangeStart = maxLength - (maxLength % chars.Length);

            using (var rng = RandomNumberGenerator.Create())
            {
                var sb = new StringBuilder();

                var buffer = new byte[128];

                while (sb.Length < length)
                {
                    rng.GetBytes(buffer);

                    for (var i = 0; i < buffer.Length && sb.Length < length; ++i)
                    {
                        if (outOfRangeStart <= buffer[i])
                        {
                            continue;
                        }

                        sb.Append(chars[buffer[i] % chars.Length]);
                    }
                }

                return sb.ToString();
            }
        }

        #endregion

        #region Norm

        /// <summary>
        /// 标准化：UPPER情况下，删除所有变音符号(重音符号)并将边缘大小写转换为
        /// 字符串中的正常字符
        /// </summary>
        /// <param name="value"> </param>
        /// <returns> </returns>
        /// <remarks>
        /// <para>
        /// 如果value为<c>null</c>或<c>空白</c>将返回<c>空字符串</c>
        /// </para>
        /// <para>更多信息：https：//docs.microsoft.com/en-us/visualstudio/code-quality/ca1308-normalize-strings-to-uppercase </para>
        /// </remarks>
        public static string Normalize(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            value = value.Trim();

            // 转换边缘大小写
            value = string.Join(string.Empty, value.Select(ConvertEdgeCases));

            var normalizedString = RemoveAccents(value);

            return normalizedString.ToUpperInvariant();
        }

        public static string ConvertEdgeCases(char c)
        {
            if ("àåáâäãåąā".Contains(c))
                return "a";
            if ("èéêěëę".Contains(c))
                return "e";
            if ("ìíîïı".Contains(c))
                return "i";
            if ("òóôõöøőð".Contains(c))
                return "o";
            if ("ùúûüŭů".Contains(c))
                return "u";
            if ("çćčĉ".Contains(c))
                return "c";
            if ("żźž".Contains(c))
                return "z";
            if ("śşšŝ".Contains(c))
                return "c";
            if ("ñń".Contains(c))
                return "n";
            if ("ýÿ".Contains(c))
                return "y";
            if ("ğĝ".Contains(c))
                return "g";
            if ("ŕř".Contains(c))
                return "r";
            if ("ĺľł".Contains(c))
                return "l";
            if ("úů".Contains(c))
                return "u";
            if ("đď".Contains(c))
                return "d";
            if ('ť' == c)
                return "t";
            if ('ž' == c)
                return "z";
            if ('ß' == c)
                return "ss";
            if ('Þ' == c)
                return "th";
            if ('ĥ' == c)
                return "h";
            if ('ĵ' == c)
                return "j";

            return c.ToString();
        }

        /// <summary>
        /// 删除字符串中的所有变音符号(重音符号)
        /// </summary>
        /// <param name="value"> </param>
        /// <returns> </returns>
        /// <remarks>已经处理边缘案例<see cref="ConvertEdgeCases"/> </remarks>
        public static string RemoveAccents(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            var normalizedString = value.Normalize(NormalizationForm.FormD);

            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);

                if (unicodeCategory == UnicodeCategory.NonSpacingMark)
                {
                    continue;
                }

                var edgeCases = ConvertEdgeCases(c);

                stringBuilder.Append(edgeCases);
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        #endregion

        #region Base 64

        public static bool IsBase64(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            try
            {
                var byteArray = System.Convert.FromBase64String(value);

                return byteArray.Any();
            }
            catch
            {
                return false;
            }
        }

        public static string EncodeBase64Url(string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);

            string base64Encode = WebEncoders.Base64UrlEncode(bytes);

            return base64Encode;
        }

        public static string DecodeBase64Url(string value)
        {
            byte[] bytes = WebEncoders.Base64UrlDecode(value);

            string base64Decode = Encoding.UTF8.GetString(bytes);

            return base64Decode;
        }

        #endregion

        #region "Unicode编码转换"
        /// <summary>
        /// 字符串转Unicode
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>Unicode编码后的字符串</returns>
        public static string String2Unicode(string source)
        {
            var bytes = Encoding.Unicode.GetBytes(source);
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < bytes.Length; i += 2)
            {
                stringBuilder.AppendFormat(@"\u{0:x2}{1:x2}", bytes[i + 1], bytes[i]);
            }
            return stringBuilder.ToString();
        }

        /// <summary>  
        /// 字符串转为UniCode码字符串  
        /// </summary>  
        /// <param name="s"></param>  
        /// <returns></returns>  
        public static string StringToUnicode(string s)
        {
            char[] charbuffers = s.ToCharArray();
            byte[] buffer;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < charbuffers.Length; i++)
            {
                buffer = System.Text.Encoding.Unicode.GetBytes(charbuffers[i].ToString());
                sb.Append(string.Format(@"\u{0:X2}{1:X2}", buffer[1], buffer[0]));
            }
            return sb.ToString();
        }

        /// <summary>  
        /// Unicode字符串转为正常字符串  
        /// </summary>  
        /// <param name="srcText"></param>  
        /// <returns></returns>  
        public static string UnicodeToString(string srcText)
        {
            string dst = "";
            string src = srcText;
            int len = srcText.Length / 6;
            for (int i = 0; i <= len - 1; i++)
            {
                string str = "";
                str = src.Substring(0, 6).Substring(2);
                src = src.Substring(6);
                byte[] bytes = new byte[2];
                bytes[1] = byte.Parse(int.Parse(str.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                bytes[0] = byte.Parse(int.Parse(str.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                dst += Encoding.Unicode.GetString(bytes);
            }
            return dst;
        }
        #endregion
    }
}
