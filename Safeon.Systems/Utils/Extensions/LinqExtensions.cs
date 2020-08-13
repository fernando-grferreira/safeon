using System;
using System.Collections.Generic;
using System.Linq;

namespace Safeon.Systems.Utils.Extensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Agrupa um enumerador com base em uma função.
        /// (Método pode ser usado para identificar grupos sequenciais (dias consecutivos por exemplo em um range de datas)
        /// <code>
        ///             List<long> timeStamps = new List<long>();
        ///             timeStamps.Add(new DateTime(2018, 1, 1, 0, 0, 0, DateTimeKind.Utc).DateTimeToTimeStampInSeconds());
        ///             timeStamps.Add(new DateTime(2018, 1, 2, 0, 0, 0, DateTimeKind.Utc).DateTimeToTimeStampInSeconds());
        ///             timeStamps.Add(new DateTime(2018, 1, 3, 0, 0, 0, DateTimeKind.Utc).DateTimeToTimeStampInSeconds());
        ///             timeStamps.Add(new DateTime(2018, 1, 6, 0, 0, 0, DateTimeKind.Utc).DateTimeToTimeStampInSeconds());
        ///             timeStamps.Add(new DateTime(2018, 1, 8, 0, 0, 0, DateTimeKind.Utc).DateTimeToTimeStampInSeconds());
        ///             timeStamps.Add(new DateTime(2018, 1, 9, 0, 0, 0, DateTimeKind.Utc).DateTimeToTimeStampInSeconds());
        ///             
        ///             var secondsOneDay = TimeSpan.FromDays(1).TotalSeconds;
        /// 
        ///             var consecutiveDays = timeStamps.GroupWhile((x, y) => y - x == secondsOneDay)
        ///             .Select(x => new { First = x.First(), Count = x.Count(), Itens = x, Datas = x.Select(d => d.TimeStampInSecondsToDateTime()) })
        ///             .ToList();
        /// </code>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="seq"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <seealso cref="https://stackoverflow.com/questions/20469416/linq-to-find-series-of-consecutive-numbers"/>        
        public static IEnumerable<IEnumerable<T>> GroupWhile<T>(this IEnumerable<T> seq, Func<T, T, bool> condition)
        {
            T prev = seq.First();
            List<T> list = new List<T>() { prev };

            foreach (T item in seq.Skip(1))
            {
                if (condition(prev, item) == false)
                {
                    yield return list;
                    list = new List<T>();
                }
                list.Add(item);
                prev = item;
            }

            yield return list;
        }
    }
}
