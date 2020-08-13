using System;
using System.Text;

namespace Safeon.Systems.Utils.Extensions
{
    public static class ByteSizeExtensions
    {
        /// <summary>
        /// Quantidade de bytes considerado como unidade de conversão e igual a 1 KB.
        /// </summary>
        /// <seealso cref="https://www.google.com.br/search?ei=3LVMWseaO8OZwQSgj77ICA&q=byte+to+kilobyte&oq=byte+to+kilo&gs_l=psy-ab.3.0.0j0i22i30k1l4j0i22i10i30k1j0i22i30k1l4.2883913.2888301.0.2890938.8.8.0.0.0.0.223.987.0j5j1.6.0....0...1c.1.64.psy-ab..2.6.984...0i7i30i19k1j0i8i30i19k1j0i8i10i30i19k1j0i10i19k1j0i7i30k1j0i7i10i30k1j0i67k1.0.GzxZlo98cc0"/>
        /// <seealso cref="https://blogs.gnome.org/cneumair/2008/09/30/1-kb-1024-bytes-no-1-kb-1000-bytes/comment-page-1/"/>
        public const int ByteConversion = 1024;

        public static string ToFileSize(this int source)
        {
            return ToFileSize(Convert.ToInt64(source));
        }

        public static string ToFileSize(this long source)
        {
            double bytes = Convert.ToDouble(source);

            if (bytes >= Math.Pow(ByteConversion, 3)) //GB Range
            {
                return string.Concat(Math.Round(bytes / Math.Pow(ByteConversion, 3), 2), " GB");
            }
            else if (bytes >= Math.Pow(ByteConversion, 2)) //MB Range
            {
                return string.Concat(Math.Round(bytes / Math.Pow(ByteConversion, 2), 2), " MB");
            }
            else if (bytes >= ByteConversion) //KB Range
            {
                return string.Concat(Math.Round(bytes / ByteConversion, 2), " KB");
            }
            else //Bytes
            {
                return string.Concat(bytes, " Bytes");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static decimal BytesToKb(this decimal bytes)
        {
            var calcBytes = bytes / ByteConversion;
            return Math.Round(calcBytes, 2);
        }

        public static decimal BytesToKb(this long source)
        {
            var bytes = Convert.ToDecimal(source);
            return bytes.BytesToKb();
        }

        public static decimal BytesToKb(this int source)
        {
            return BytesToKb(Convert.ToInt64(source));
        }


        public static decimal BytesToMb(this decimal bytes)
        {
            var calcBytes = bytes / Convert.ToDecimal(Math.Pow(ByteConversion, 2));
            return Math.Round(calcBytes, 2);
        }

        public static decimal BytesToMb(this long source)
        {
            var bytes = Convert.ToDecimal(source);
            return bytes.BytesToMb();
        }

        public static decimal BytesToMb(this int source)
        {
            return BytesToMb(Convert.ToInt64(source));
        }


        public static decimal BytesToGb(this decimal bytes)
        {
            var calcBytes = bytes / Convert.ToDecimal(Math.Pow(ByteConversion, 3));
            return Math.Round(calcBytes, 2);
        }

        public static decimal BytesToGb(this long source)
        {
            var bytes = Convert.ToDecimal(source);
            return bytes.BytesToGb();
        }

        public static decimal BytesToGb(this int source)
        {
            return BytesToGb(Convert.ToInt64(source));
        }


        public static decimal MbToBytes(this int source)
        {
            var bytes = Convert.ToDecimal(source);
            return bytes.MbToBytes();
        }

        public static decimal MbToBytes(this long source)
        {
            var bytes = Convert.ToDecimal(source);
            return bytes.MbToBytes();
        }

        public static decimal MbToBytes(this decimal bytes)
        {
            var calcBytes = bytes * Convert.ToDecimal(Math.Pow(ByteConversion, 2));
            return Math.Round(calcBytes);
        }


        public static decimal KbToBytes(this decimal bytes)
        {
            var calcBytes = bytes * ByteConversion;
            return Math.Round(calcBytes);
        }

        public static decimal KbToBytes(this long source)
        {
            var bytes = Convert.ToDecimal(source);
            return bytes.KbToBytes();
        }

        public static decimal KbToBytes(this int source)
        {
            var bytes = Convert.ToDecimal(source);
            return bytes.KbToBytes();
        }


        public static decimal GetBytesLength(this string text, Encoding encoding = null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;

            return Convert.ToDecimal(encoding.GetBytes(text).LongLength);
        }

        public static decimal GetKbLength(this string text, Encoding encoding = null)
        {
            return text.GetBytesLength(encoding).BytesToKb();
        }

        public static decimal GetMbLength(this string text, Encoding encoding = null)
        {
            return text.GetBytesLength(encoding).BytesToMb();
        }
    }
}
