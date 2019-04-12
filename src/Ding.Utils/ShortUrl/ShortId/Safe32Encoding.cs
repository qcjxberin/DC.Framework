using System;
using System.Text;

namespace Ding.Utils.ShortUrl
{
    /// <summary>
    /// 用于在字节数组和Base32符号之间进行转换的类
    /// </summary>
    public static class Safe32Encoding
    {
        /// <summary>
        /// 常规字节的大小(以位为单位)
        /// </summary>
        private const int InByteSize = 8;

        /// <summary>
        /// 转换的字节的大小(以位为单位)
        /// </summary>
        private const int OutByteSize = 5;

        /// <summary>
        /// 字母
        /// </summary>
        private const string Base32Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

        /// <summary>
        /// 将字节数组转换为Base32格式
        /// </summary>
        /// <param name="bytes">要转换为Base32格式</param>的字节数组
        /// <returns>返回表示字节数组的字符串</returns>
        public static string EncodeBytes(byte[] bytes)
        {
            //检查字节数组是否为空
            if (bytes == null)
            {
                return null;
            }
            // 检查是否空
            else if (bytes.Length == 0)
            {
                return string.Empty;
            }

            // 为最终值准备容器
            StringBuilder builder = new StringBuilder(bytes.Length * InByteSize / OutByteSize);

            // 在输入缓冲区中的位置
            int bytesPosition = 0;

            //在<bytesPosition>指向的单个字节内偏移（从左到右）0 - 
            //最高位，7 - 最低位
            int bytesSubPosition = 0;

            // Byte在字典中查找
            byte outputBase32Byte = 0;

            // 当前输出字节中填充的位数
            int outputBase32BytePosition = 0;

            // 循环访问输入缓冲区, 直到到达它的末尾
            while (bytesPosition < bytes.Length)
            {
                // 计算我们可以从当前输入字节提取的位数以填充
                // 输出字节中缺少位
                int bitsAvailableInByte =
                    Math.Min(InByteSize - bytesSubPosition, OutByteSize - outputBase32BytePosition);

                // 在输出字节中留出空间
                outputBase32Byte <<= bitsAvailableInByte;

                // 提取输入字节的部分并将其移动到输出字节
                outputBase32Byte |=
                    (byte)(bytes[bytesPosition] >> (InByteSize - (bytesSubPosition + bitsAvailableInByte)));

                // 更新当前的子字节位置
                bytesSubPosition += bitsAvailableInByte;

                // 检查溢出
                if (bytesSubPosition >= InByteSize)
                {
                    // 移到下一个字节
                    bytesPosition++;
                    bytesSubPosition = 0;
                }

                // 更新当前base32字节的完成
                outputBase32BytePosition += bitsAvailableInByte;

                // 检查输入数组的溢出或结束
                if (outputBase32BytePosition >= OutByteSize)
                {
                    // 除去溢出位
                    outputBase32Byte &= 0x1F; // 0x1F = 00011111 in binary

                    // 添加当前 Base32 字节并将其转换为字符
                    builder.Append(Base32Alphabet[outputBase32Byte]);

                    // 移动到下一个字节
                    outputBase32BytePosition = 0;
                }
            }

            // 检查是否有剩余的
            if (outputBase32BytePosition > 0)
            {
                // 移动到正确的位
                outputBase32Byte <<= (OutByteSize - outputBase32BytePosition);

                // 除去溢出位
                outputBase32Byte &= 0x1F; // 0x1F = 00011111 in binary

                // 添加当前 Base32 字节并将其转换为字符
                builder.Append(Base32Alphabet[outputBase32Byte]);
            }

            return builder.ToString();
        }

        /// <summary>
        /// 将base32字符串转换为字节数组
        /// </summary>
        /// <param name="base32String"> Base32要转换的字符串</param>
        /// <returns>返回从字符串</returns>转换的字节数组
        public static byte[] DecodeBytes(string base32String)
        {
            // 检查字符串是否为空
            if (base32String == null)
            {
                return null;
            }
            // 检查是否空
            else if (base32String == string.Empty)
            {
                return new byte[0];
            }

            // 转换为大写
            string base32StringUpperCase = base32String.ToUpperInvariant();

            // 准备输出字节数组
            byte[] outputBytes = new byte[base32StringUpperCase.Length * OutByteSize / InByteSize];

            // 检查大小
            if (outputBytes.Length == 0)
            {
                throw new ArgumentException(
                    "Specified string is not valid Base32 format because it doesn't have enough data to construct a complete byte array");
            }

            // 在字符串中的位置
            int base32Position = 0;

            // 字符串中字符的偏移量
            int base32SubPosition = 0;

            // 在outputBytes数组中的位置
            int outputBytePosition = 0;

            // 当前输出字节中填充的位数
            int outputByteSubPosition = 0;

            //通常我们会迭代输入数组，但在这种情况下，我们实际上是迭代的
            //输出数组我们这样做是因为输入数组没有溢出位
            //如果我们不及时停止，它会导致输出数组溢出
            while (outputBytePosition < outputBytes.Length)
            {
                // 查找字典中的当前字符以将其转换为字节
                int currentBase32Byte = Base32Alphabet.IndexOf(base32StringUpperCase[base32Position]);

                // 检查是否找到
                if (currentBase32Byte < 0)
                {
                    throw new ArgumentException(
                        $"指定的字符串无效 Base32 格式, 因为字符 \"{base32String[base32Position]}\" 在 Base32 字母表中不存在");
                }

                //计算我们可以从当前输入字符中提取的位数来填充
                //丢失输出字节中的位
                int bitsAvailableInByte =
                    Math.Min(OutByteSize - base32SubPosition, InByteSize - outputByteSubPosition);

                //在输出字节中留出空间
                outputBytes[outputBytePosition] <<= bitsAvailableInByte;

                //提取输入字符的一部分并将其移至输出字节
                outputBytes[outputBytePosition] |=
                    (byte)(currentBase32Byte >> (OutByteSize - (base32SubPosition + bitsAvailableInByte)));

                //更新当前的子字节位置
                outputByteSubPosition += bitsAvailableInByte;

                //检查溢出
                if (outputByteSubPosition >= InByteSize)
                {
                    //移动到下一个字节
                    outputBytePosition++;
                    outputByteSubPosition = 0;
                }

                //更新当前base32字节的完成
                base32SubPosition += bitsAvailableInByte;

                //检查输入数组的溢出或结束
                if (base32SubPosition >= OutByteSize)
                {
                    //移至下一个字符
                    base32Position++;
                    base32SubPosition = 0;
                }
            }

            return outputBytes;
        }
    }
}
