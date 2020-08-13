using System;

namespace Safeon.Systems.Utils.Extensions
{
    public static class TimeStampExtensions
    {
        /// <summary>
        /// Converte um time stamp unix para datetime utc fuso zero.
        /// </summary>
        /// <param name="timeStampInMilliseconds"></param>
        /// <returns></returns>
        public static DateTime TimeStampToUtcDateTime(this long timeStampInMilliseconds)
        {
            // timestamp is milliseconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(timeStampInMilliseconds);
            return dtDateTime;
        }

        /// <summary>
        /// Converte um time stamp unix para datetime utc fuso zero.
        /// </summary>
        /// <param name="timeStampInMilliseconds"></param>
        /// <returns></returns>
        public static DateTime TimeStampToUtcDateTime(this string timeStampInMilliseconds)
        {
            // timestamp is milliseconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(long.Parse(timeStampInMilliseconds));
            return dtDateTime;
        }

        /// <summary>
        /// Converte data para time stamp unix em milisegundos (UTC Fuso Zero).
        /// </summary>
        /// <param name="data">data em um fuso qualquer</param>
        /// <returns></returns>
        public static long DateTimeToTimeStampUnixMilliseconds(this DateTime data)
        {
            var inicio = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return (long)(data.ToUniversalTime() - inicio).TotalMilliseconds;
        }

        /// <summary>
        /// Converte uma data para timestamp
        /// </summary>
        /// <param name="utcDateTime"></param>
        /// <returns>retorna um timestamp unix em segundos</returns>
        /// <seealso cref="https://www.epochconverter.com/"/>
        public static long DateTimeToTimeStampInSeconds(this DateTime utcDateTime)
        {
            if (utcDateTime.Kind != DateTimeKind.Utc)
                throw new ArgumentException("utcDateTime precisa estar em UTC");

            var epoch = (utcDateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            return (long)epoch;
        }

        /// <summary>
        /// Converte um timestamp para data.
        /// </summary>
        /// <param name="timeStampInSeconds">Timestamp unix em segundos</param>
        /// <returns></returns>
        public static DateTime TimeStampInSecondsToDateTime(this long timeStampInSeconds)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timeStampInSeconds);
        }
    }
}
