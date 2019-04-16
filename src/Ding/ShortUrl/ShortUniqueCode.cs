using System;
using System.Linq;
using System.Text;

namespace Ding.ShortUrl
{
    /// <summary>
    /// 生成短惟一码
    /// </summary>
    public class ShortUniqueCode
    {
        const string Seq = "s9LFkgy5RovixI1aOf8UhdY3r4DMplQZJXPqebE0WSjBn7wVzmN2Gc6THCAKut";

        public static string CreateCode(int Id)
        {
            string code = "";
            string source_string = "2YU9IP1ASDFG8QWERTHJ7KLZX4CV5B3ONM6"; //自定义35进制  
            int mod = 0;
            StringBuilder sb = new StringBuilder();
            while (Id > 0)
            {
                mod = Id % 35;
                Id = (Id - mod) / 35;
                code = source_string.ToCharArray()[mod] + code;
            }
            return code.PadRight(6, '0'); //不足6位补0
        }

        public static int Decode(string code)
        {
            code = new string((from s in code where s != '0' select s).ToArray());
            int num = 0;
            string source_string = "2YU9IP1ASDFG8QWERTHJ7KLZX4CV5B3ONM6";
            for (int i = 0; i < code.ToCharArray().Length; i++)
            {
                for (int j = 0; j < source_string.ToCharArray().Length; j++)
                {
                    if (code.ToCharArray()[i] == source_string.ToCharArray()[j])
                    {
                        num += j * Convert.ToInt32(Math.Pow(35, code.ToCharArray().Length - i - 1));
                    }
                }
            }
            return num;
        }

        /// <summary>
        /// 混淆id为字符串
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static string Mixup(long id)
        {
            string Key = Convert1(id);
            int s = 0;
            foreach (char c in Key)
            {
                s += (int)c;
            }
            int Len = Key.Length;
            int x = (s % Len);
            char[] arr = Key.ToCharArray();
            char[] newarr = new char[arr.Length];
            Array.Copy(arr, x, newarr, 0, Len - x);
            Array.Copy(arr, 0, newarr, Len - x, x);
            string NewKey = "";
            foreach (char c in newarr)
            {
                NewKey += c;
            }
            return NewKey;
        }

        /// <summary>
        /// 解开混淆字符串
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        private static long UnMixup(string Key)
        {
            int s = 0;
            foreach (char c in Key)
            {
                s += (int)c;
            }
            int Len = Key.Length;
            int x = (s % Len);
            x = Len - x;
            char[] arr = Key.ToCharArray();
            char[] newarr = new char[arr.Length];
            Array.Copy(arr, x, newarr, 0, Len - x);
            Array.Copy(arr, 0, newarr, Len - x, x);
            string NewKey = "";
            foreach (char c in newarr)
            {
                NewKey += c;
            }
            return Convert1(NewKey);
        }

        /// <summary>
        /// 10进制转换为62进制
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static string Convert1(long id)
        {
            if (id < 62)
            {
                return Seq[(int)id].ToString();
            }
            int y = (int)(id % 62);
            long x = (long)(id / 62);

            return Convert1(x) + Seq[y];
        }

        /// <summary>
        /// 将62进制转为10进制
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        private static long Convert1(string Num)
        {
            long v = 0;
            int Len = Num.Length;
            for (int i = Len - 1; i >= 0; i--)
            {
                int t = Seq.IndexOf(Num[i]);
                double s = (Len - i) - 1;
                long m = (long)(Math.Pow(62, s) * t);
                v += m;
            }
            return v;
        }

    }
}
