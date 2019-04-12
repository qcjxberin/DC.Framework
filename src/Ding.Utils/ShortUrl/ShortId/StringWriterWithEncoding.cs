using System;
using System.IO;
using System.Text;

namespace Ding.Utils.ShortUrl
{
    /// <summary>
    /// <para>
    /// <see cref="T:System.IO.StringWriter"/> class始终输出UTF-16编码
    /// 字符串。 要使用不同的编码，我们必须从<see cref="T:System.IO.StringWriter"/>继承。
    /// </para>
    /// </summary>
    public class StringWriterWithEncoding : StringWriter
    {
        private readonly Encoding _encoding;

        public StringWriterWithEncoding()
        {
        }

        public StringWriterWithEncoding(IFormatProvider formatProvider) : base(formatProvider)
        {
        }

        public StringWriterWithEncoding(StringBuilder stringBuilder) : base(stringBuilder)
        {
        }

        public StringWriterWithEncoding(StringBuilder stringBuilder, IFormatProvider formatProvider) : base(stringBuilder, formatProvider)
        {
        }

        public StringWriterWithEncoding(Encoding encoding)
        {
            _encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));
        }

        public StringWriterWithEncoding(IFormatProvider formatProvider, Encoding encoding) : base(formatProvider)
        {
            _encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));
        }

        public StringWriterWithEncoding(StringBuilder stringBuilder, Encoding encoding) : base(stringBuilder)
        {
            _encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));
        }

        public StringWriterWithEncoding(StringBuilder stringBuilder, IFormatProvider formatProvider, Encoding encoding) : base(stringBuilder, formatProvider)
        {
            _encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));
        }

        public override Encoding Encoding => _encoding ?? base.Encoding;
    }
}
