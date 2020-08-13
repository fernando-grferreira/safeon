using System;

namespace Safeon.Systems.Utils.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converte uma data para utc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="deslocamento">Deslocamento em horas</param>
        /// <returns></returns>
        public static DateTime ConvertToUTC(this DateTime value,int deslocamento)
        {
            var datetimeKind = DateTime.SpecifyKind(value, DateTimeKind.Unspecified);
            var result = new DateTimeOffset(datetimeKind, TimeSpan.FromHours(deslocamento));

            return result.UtcDateTime;
        }
    }
}
