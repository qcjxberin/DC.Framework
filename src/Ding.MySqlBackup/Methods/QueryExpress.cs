﻿using System;
using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace MySql.Data.MySqlClient
{
    public class QueryExpress
    {
        static NumberFormatInfo _numberFormatInfo = new NumberFormatInfo()
        {
            NumberDecimalSeparator = ".",
            NumberGroupSeparator = string.Empty
        };

        static DateTimeFormatInfo _dateFormatInfo = new DateTimeFormatInfo()
        {
            DateSeparator = "-",
            TimeSeparator = ":"
        };

        public static NumberFormatInfo MySqlNumberFormat { get { return _numberFormatInfo; } }

        public static DateTimeFormatInfo MySqlDateTimeFormat { get { return _dateFormatInfo; } }

        public static DataTable GetTable(MySqlCommand cmd, string sql)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = sql;
            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public static string ExecuteScalarStr(MySqlCommand cmd, string sql)
        {
            cmd.CommandText = sql;
            object ob = cmd.ExecuteScalar();
            if (ob is byte[])
                return Encoding.UTF8.GetString((byte[])ob);
            else
                return ob + "";
        }

        public static string ExecuteScalarStr(MySqlCommand cmd, string sql, int columnIndex)
        {
            DataTable dt = GetTable(cmd, sql);

            if (dt.Rows[0][columnIndex] is byte[])
                return Encoding.UTF8.GetString((byte[])dt.Rows[0][columnIndex]);
            else
                return dt.Rows[0][columnIndex] + "";
        }

        public static string ExecuteScalarStr(MySqlCommand cmd, string sql, string columnName)
        {
            DataTable dt = GetTable(cmd, sql);

            if (dt.Rows[0][columnName] is byte[])
                return Encoding.UTF8.GetString((byte[])dt.Rows[0][columnName]);
            else
                return dt.Rows[0][columnName] + "";
        }

        public static long ExecuteScalarLong(MySqlCommand cmd, string sql)
        {
            long l = 0;
            cmd.CommandText = sql;
            long.TryParse(cmd.ExecuteScalar() + "", out l);
            return l;
        }

        public static string EscapeStringSequence(string data)
        {
            var builder = new StringBuilder();
            foreach (var ch in data)
            {
                switch (ch)
                {
                    case '\\': // Backslash
                        builder.AppendFormat("\\\\");
                        break;
                    case '\r': // Carriage return
                        builder.AppendFormat("\\r");
                        break;
                    case '\n': // New Line
                        builder.AppendFormat("\\n");
                        break;
                    //case '\a': // Vertical tab
                    //    builder.AppendFormat("\\a");
                    //    break;
                    case '\b': // Backspace
                        builder.AppendFormat("\\b");
                        break;
                    //case '\f': // Formfeed
                    //    builder.AppendFormat("\\f");
                    //    break;
                    case '\t': // Horizontal tab
                        builder.AppendFormat("\\t");
                        break;
                    //case '\v': // Vertical tab
                    //    builder.AppendFormat("\\v");
                    //    break;
                    case '\"': // Double quotation mark
                        builder.AppendFormat("\\\"");
                        break;
                    case '\'': // Single quotation mark
                        builder.AppendFormat("''");
                        break;
                    default:
                        builder.Append(ch);
                        break;
                }
            }

            return builder.ToString();
        }

        public static string EraseDefiner(string input)
        {
            StringBuilder sb = new StringBuilder();
            string definer = " DEFINER=";
            int dIndex = input.IndexOf(definer);

            sb.AppendFormat(definer);

            bool pointAliasReached = false;
            bool point3rdQuoteReached = false;

            for (int i = dIndex + definer.Length; i < input.Length; i++)
            {
                if (!pointAliasReached)
                {
                    if (input[i] == '@')
                        pointAliasReached = true;

                    sb.Append(input[i]);
                    continue;
                }

                if (!point3rdQuoteReached)
                {
                    if (input[i] == '`')
                        point3rdQuoteReached = true;

                    sb.Append(input[i]);
                    continue;
                }

                if (input[i] != '`')
                {
                    sb.Append(input[i]);
                    continue;
                }
                else
                {
                    sb.Append(input[i]);
                    break;
                }
            }

            return input.Replace(sb.ToString(), string.Empty);
        }

        public static string ConvertToSqlFormat(object ob, bool wrapStringWithSingleQuote, bool escapeStringSequence, MySqlColumn col)
        {
            StringBuilder sb = new StringBuilder();

            if (ob == null || ob is System.DBNull)
            {
                sb.AppendFormat("NULL");
            }
            else if (ob is System.String)
            {
                string str = (string)ob;

                if (escapeStringSequence)
                    str = QueryExpress.EscapeStringSequence(str);

                if (wrapStringWithSingleQuote)
                    sb.AppendFormat("'");

                sb.Append(str);

                if (wrapStringWithSingleQuote)
                    sb.AppendFormat("'");
            }
            else if (ob is System.Boolean)
            {
                sb.AppendFormat(Convert.ToInt32(ob).ToString());
            }
            else if (ob is System.Byte[])
            {
                if (((byte[])ob).Length == 0)
                {
                    if (wrapStringWithSingleQuote)
                        return "''";
                    else
                        return "";
                }
                else
                {
                    sb.AppendFormat(CryptoExpress.ConvertByteArrayToHexString((byte[])ob));
                }
            }
            else if (ob is short)
            {
                sb.AppendFormat(((short)ob).ToString(_numberFormatInfo));
            }
            else if (ob is int)
            {
                sb.AppendFormat(((int)ob).ToString(_numberFormatInfo));
            }
            else if (ob is long)
            {
                sb.AppendFormat(((long)ob).ToString(_numberFormatInfo));
            }
            else if (ob is ushort)
            {
                sb.AppendFormat(((ushort)ob).ToString(_numberFormatInfo));
            }
            else if (ob is uint)
            {
                sb.AppendFormat(((uint)ob).ToString(_numberFormatInfo));
            }
            else if (ob is ulong)
            {
                sb.AppendFormat(((ulong)ob).ToString(_numberFormatInfo));
            }
            else if (ob is double)
            {
                sb.AppendFormat(((double)ob).ToString(_numberFormatInfo));
            }
            else if (ob is decimal)
            {
                sb.AppendFormat(((decimal)ob).ToString(_numberFormatInfo));
            }
            else if (ob is float)
            {
                sb.AppendFormat(((float)ob).ToString(_numberFormatInfo));
            }
            else if (ob is byte)
            {
                sb.AppendFormat(((byte)ob).ToString(_numberFormatInfo));
            }
            else if (ob is sbyte)
            {
                sb.AppendFormat(((sbyte)ob).ToString(_numberFormatInfo));
            }
            else if (ob is TimeSpan)
            {
                TimeSpan ts = (TimeSpan)ob;

                if (wrapStringWithSingleQuote)
                    sb.AppendFormat("'");

                sb.AppendFormat(ts.Hours.ToString().PadLeft(2, '0'));
                sb.AppendFormat(":");
                sb.AppendFormat(ts.Minutes.ToString().PadLeft(2, '0'));
                sb.AppendFormat(":");
                sb.AppendFormat(ts.Seconds.ToString().PadLeft(2, '0'));

                if (wrapStringWithSingleQuote)
                    sb.AppendFormat("'");
            }
            else if (ob is System.DateTime)
            {
                if (wrapStringWithSingleQuote)
                    sb.AppendFormat("'");

                sb.AppendFormat(((DateTime)ob).ToString("yyyy-MM-dd HH:mm:ss", _dateFormatInfo));

                if (wrapStringWithSingleQuote)
                    sb.AppendFormat("'");
            }
            //else if (ob is Devart.Data.MySql.MySqlType.)
            //{
            //    Devart.Data.MySql.MySqlType.MySqlDateTime mdt = (Devart.Data.MySql.MySqlType.MySqlDateTime)ob;

            //    if (mdt.IsNull)
            //    {
            //        sb.AppendFormat("NULL");
            //    }
            //    else
            //    {
            //        if (mdt.IsValidDateTime)
            //        {
            //            DateTime dtime = mdt.Value;

            //            if (wrapStringWithSingleQuote)
            //                sb.AppendFormat("'");

            //            if (col.MySqlDataType == "datetime")
            //                sb.AppendFormat(dtime.ToString("yyyy-MM-dd HH:mm:ss", _dateFormatInfo));
            //            else if (col.MySqlDataType == "date")
            //                sb.AppendFormat(dtime.ToString("yyyy-MM-dd", _dateFormatInfo));
            //            else if (col.MySqlDataType == "time")
            //                sb.AppendFormat(dtime.ToString("HH:mm:ss", _dateFormatInfo));
            //            else
            //                sb.AppendFormat(dtime.ToString("yyyy-MM-dd HH:mm:ss", _dateFormatInfo));

            //            if (dtime.Millisecond > 0)
            //            {
            //                sb.Append(".");
            //                sb.Append(dtime.Millisecond);
            //            }

            //            if (wrapStringWithSingleQuote)
            //                sb.AppendFormat("'");
            //        }
            //        else
            //        {
            //            if (wrapStringWithSingleQuote)
            //                sb.AppendFormat("'");

            //            if (col.MySqlDataType == "datetime")
            //                sb.AppendFormat("0000-00-00 00:00:00");
            //            else if (col.MySqlDataType == "date")
            //                sb.AppendFormat("0000-00-00");
            //            else if (col.MySqlDataType == "time")
            //                sb.AppendFormat("00:00:00");
            //            else
            //                sb.AppendFormat("0000-00-00 00:00:00");

            //            if (wrapStringWithSingleQuote)
            //                sb.AppendFormat("'");
            //        }
            //    }
            //}
            else if (ob is System.Guid)
            {
                if (col.MySqlDataType == "binary(16)")
                {
                    sb.Append(CryptoExpress.ConvertByteArrayToHexString(((Guid)ob).ToByteArray()));
                }
                else if (col.MySqlDataType == "char(36)")
                {
                    if (wrapStringWithSingleQuote)
                        sb.AppendFormat("'");

                    sb.Append(ob);

                    if (wrapStringWithSingleQuote)
                        sb.AppendFormat("'");
                }
                else
                {
                    if (wrapStringWithSingleQuote)
                        sb.AppendFormat("'");

                    sb.Append(ob);

                    if (wrapStringWithSingleQuote)
                        sb.AppendFormat("'");
                }
            }
            else
            {
                throw new Exception("Unhandled data type. Current processing data type: " + ob.GetType().ToString() + ". Please report this bug with this message to the development team.");
            }
            return sb.ToString();
        }

        public static string ConvertToSqlFormat(MySqlDataReader rdr, int colIndex, bool wrapStringWithSingleQuote, bool escapeStringSequence, MySqlColumn col)
        {
            object ob = rdr[colIndex];

            StringBuilder sb = new StringBuilder();

            if (ob == null || ob is System.DBNull)
            {
                sb.AppendFormat("NULL");
            }
            else if (ob is System.String)
            {
                string str = (string)ob;

                if (escapeStringSequence)
                    str = QueryExpress.EscapeStringSequence(str);

                if (wrapStringWithSingleQuote)
                    sb.AppendFormat("'");

                sb.Append(str);

                if (wrapStringWithSingleQuote)
                    sb.AppendFormat("'");
            }
            else if (ob is System.Boolean)
            {
                sb.AppendFormat(Convert.ToInt32(ob).ToString());
            }
            else if (ob is System.Byte[])
            {
                if (((byte[])ob).Length == 0)
                {
                    if (wrapStringWithSingleQuote)
                        return "''";
                    else
                        return "";
                }
                else
                {
                    sb.AppendFormat(CryptoExpress.ConvertByteArrayToHexString((byte[])ob));
                }
            }
            else if (ob is short)
            {
                sb.AppendFormat(((short)ob).ToString(_numberFormatInfo));
            }
            else if (ob is int)
            {
                sb.AppendFormat(((int)ob).ToString(_numberFormatInfo));
            }
            else if (ob is long)
            {
                sb.AppendFormat(((long)ob).ToString(_numberFormatInfo));
            }
            else if (ob is ushort)
            {
                sb.AppendFormat(((ushort)ob).ToString(_numberFormatInfo));
            }
            else if (ob is uint)
            {
                sb.AppendFormat(((uint)ob).ToString(_numberFormatInfo));
            }
            else if (ob is ulong)
            {
                sb.AppendFormat(((ulong)ob).ToString(_numberFormatInfo));
            }
            else if (ob is double)
            {
                sb.AppendFormat(((double)ob).ToString(_numberFormatInfo));
            }
            else if (ob is decimal)
            {
                sb.AppendFormat(((decimal)ob).ToString(_numberFormatInfo));
            }
            else if (ob is float)
            {
                sb.AppendFormat(((float)ob).ToString(_numberFormatInfo));
            }
            else if (ob is byte)
            {
                sb.AppendFormat(((byte)ob).ToString(_numberFormatInfo));
            }
            else if (ob is sbyte)
            {
                sb.AppendFormat(((sbyte)ob).ToString(_numberFormatInfo));
            }
            else if (ob is TimeSpan)
            {
                TimeSpan ts = (TimeSpan)ob;

                if (wrapStringWithSingleQuote)
                    sb.AppendFormat("'");

                sb.AppendFormat(ts.Hours.ToString().PadLeft(2, '0'));
                sb.AppendFormat(":");
                sb.AppendFormat(ts.Minutes.ToString().PadLeft(2, '0'));
                sb.AppendFormat(":");
                sb.AppendFormat(ts.Seconds.ToString().PadLeft(2, '0'));

                if (wrapStringWithSingleQuote)
                    sb.AppendFormat("'");
            }
            else if (ob is System.DateTime)
            {
                if (wrapStringWithSingleQuote)
                    sb.AppendFormat("'");

                sb.AppendFormat(((DateTime)ob).ToString("yyyy-MM-dd HH:mm:ss", _dateFormatInfo));

                //if (col.TimeFractionLength > 0)
                //{
                //    sb.Append(".");
                //    string _microsecond = rdr.GetMySqlDateTime(colIndex).Microsecond.ToString();
                //    if (_microsecond.Length < col.TimeFractionLength)
                //    {
                //        _microsecond = _microsecond.PadLeft(col.TimeFractionLength, '0');
                //    }
                //    else if (_microsecond.Length > col.TimeFractionLength)
                //    {
                //        _microsecond = _microsecond.Substring(0, col.TimeFractionLength);
                //    }
                //    sb.Append(_microsecond.ToString().PadLeft(col.TimeFractionLength, '0'));
                //}

                if (wrapStringWithSingleQuote)
                    sb.AppendFormat("'");
            }
            //else if (ob is Devart.Data.MySql.MySqlType.MySqlDateTime)
            //{
            //    Devart.Data.MySql.MySqlType.MySqlDateTime mdt = (Devart.Data.MySql.MySqlType.MySqlDateTime)ob;

            //    if (mdt.IsNull)
            //    {
            //        sb.AppendFormat("NULL");
            //    }
            //    else
            //    {
            //        if (mdt.IsValidDateTime)
            //        {
            //            DateTime dtime = mdt.Value;

            //            if (wrapStringWithSingleQuote)
            //                sb.AppendFormat("'");

            //            if (col.MySqlDataType == "datetime")
            //                sb.AppendFormat(dtime.ToString("yyyy-MM-dd HH:mm:ss", _dateFormatInfo));
            //            else if (col.MySqlDataType == "date")
            //                sb.AppendFormat(dtime.ToString("yyyy-MM-dd", _dateFormatInfo));
            //            else if (col.MySqlDataType == "time")
            //                sb.AppendFormat(dtime.ToString("HH:mm:ss", _dateFormatInfo));
            //            else
            //                sb.AppendFormat(dtime.ToString("yyyy-MM-dd HH:mm:ss", _dateFormatInfo));

            //            if(col.TimeFractionLength > 0)
            //            {
            //                sb.Append(".");
            //                sb.Append(((Devart.Data.MySql.MySqlType.MySqlDateTime)ob).Microsecond.ToString().PadLeft(col.TimeFractionLength, '0'));
            //            }

            //            if (wrapStringWithSingleQuote)
            //                sb.AppendFormat("'");
            //        }
            //        else
            //        {
            //            if (wrapStringWithSingleQuote)
            //                sb.AppendFormat("'");

            //            if (col.MySqlDataType == "datetime")
            //                sb.AppendFormat("0000-00-00 00:00:00");
            //            else if (col.MySqlDataType == "date")
            //                sb.AppendFormat("0000-00-00");
            //            else if (col.MySqlDataType == "time")
            //                sb.AppendFormat("00:00:00");
            //            else
            //                sb.AppendFormat("0000-00-00 00:00:00");

            //            if (col.TimeFractionLength > 0)
            //            {
            //                sb.Append(".".PadRight(col.TimeFractionLength, '0'));
            //            }

            //            if (wrapStringWithSingleQuote)
            //                sb.AppendFormat("'");
            //        }
            //    }
            //}
            else if (ob is System.Guid)
            {
                if (col.MySqlDataType == "binary(16)")
                {
                    sb.Append(CryptoExpress.ConvertByteArrayToHexString(((Guid)ob).ToByteArray()));
                }
                else if (col.MySqlDataType == "char(36)")
                {
                    if (wrapStringWithSingleQuote)
                        sb.AppendFormat("'");

                    sb.Append(ob);

                    if (wrapStringWithSingleQuote)
                        sb.AppendFormat("'");
                }
                else
                {
                    if (wrapStringWithSingleQuote)
                        sb.AppendFormat("'");

                    sb.Append(ob);

                    if (wrapStringWithSingleQuote)
                        sb.AppendFormat("'");
                }
            }
            else
            {
                throw new Exception("Unhandled data type. Current processing data type: " + ob.GetType().ToString() + ". Please report this bug with this message to the development team.");
            }
            return sb.ToString();
        }
    }
}
