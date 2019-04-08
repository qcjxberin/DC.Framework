using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Ding.Utils.Helpers
{
    /// <summary>
    /// 安装帮助类
    /// </summary>
    public static class SecureHelper
    {
        /// <summary>
        /// AES密钥向量
        /// </summary>
        private static readonly byte[] _aeskeys = new byte[] { 18, 52, 86, 120, 144, 171, 205, 239, 18, 52, 86, 120, 144, 171, 205, 239 };
        //验证Base64字符串的正则表达式
        private static Regex _base64regex = new Regex("[A-Za-z0-9\\=\\/\\+]");
        //防SQL注入正则表达式1
        private static Regex _sqlkeywordregex1 = new Regex(@"(select|insert|delete|from|count\(|drop|table|update|truncate|asc\(|mid\(|char\(|xp_cmdshell|exec|master|net|local|group|administrators|user|or|and|-|;|,|\(|\)|\[|\]|\{|\}|%|\*|!|\')", RegexOptions.IgnoreCase);
        //防SQL注入正则表达式2
        private static Regex _sqlkeywordregex2 = new Regex(@"(select|insert|delete|from|count\(|drop|table|update|truncate|asc\(|mid\(|char\(|xp_cmdshell|exec|master|net|local|group|administrators|user|or|and|-|;|,|\(|\)|\[|\]|\{|\}|%|@|\*|!|\')", RegexOptions.IgnoreCase);

        public static string DecodeBase64(Encoding encode, string result)
        {
            string str = "";
            byte[] numArray = System.Convert.FromBase64String(result);
            try
            {
                str = encode.GetString(numArray);
            }
            catch
            {
                str = result;
            }
            return str;
        }

        public static string DecodeBase64(string result)
        {
            return DecodeBase64(Encoding.UTF8, result);
        }

        public static string EncodeBase64(Encoding encode, string source)
        {
            return System.Convert.ToBase64String(encode.GetBytes(source));
        }

        public static string EncodeBase64(string source)
        {
            return EncodeBase64(Encoding.UTF8, source);
        }

        public static bool IsBase64String(string str)
        {
            bool flag;
            flag = (str == null ? true : _base64regex.IsMatch(str));
            return flag;
        }

        public static bool IsSafeSqlString(string s)
        {
            return IsSafeSqlString(s, true);
        }

        /// <summary>
        /// 判断当前字符串是否存在SQL注入
        /// </summary>
        /// <returns></returns>
        public static bool IsSafeSqlString(string s, bool isStrict)
        {
            if (s != null)
            {
                if (isStrict)
                    return !_sqlkeywordregex2.IsMatch(s);
                else
                    return !_sqlkeywordregex1.IsMatch(s);
            }
            return true;
        }

        public static string MD5(this string inputStr)
        {
            MD5 mD5CryptoServiceProvider = System.Security.Cryptography.MD5.Create();
            byte[] numArray = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(inputStr));
            StringBuilder stringBuilder = new StringBuilder();
            byte[] numArray1 = numArray;
            for (int i = 0; i < numArray1.Length; i++)
            {
                byte num = numArray1[i];
                stringBuilder.Append(num.ToString("x").PadLeft(2, '0'));
            }
            return stringBuilder.ToString();
        }

    }
}
