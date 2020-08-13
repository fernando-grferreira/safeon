using System.Collections.Generic;
using System.Linq;

namespace Safeon.Systems.Utils.Extensions
{
    public static class ListExtensions
    {
        public static bool IsInList(this List<string> list, List<string> listToValidate)
        {
            foreach (var value in listToValidate)
            {
                if (list.Contains(value) == false)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsInList(this List<string> list, List<int> listToValidate)
        {
            foreach (var value in listToValidate)
            {
                if (list.Contains(value.ToString()) == false)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsInList(this List<string> list, int[] listToValidate)
        {
            return list.IsInList(listToValidate.ToList());
        }

        public static bool IsInList(this string[] list, List<int> listToValidate)
        {
            return list.ToList().IsInList(listToValidate.ToList());
        }

        public static bool IsInList(this List<string> list, string[] listToValidate)
        {
            return list.IsInList(listToValidate.ToList());
        }

        public static bool IsInList(this string[] list, string[] listToValidate)
        {
            return list.ToList().IsInList(listToValidate.ToList());
        }

        #region ChunkBy
        /// <summary>
        /// Quebra a lista em listas do tamanho especificado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="chunkSize">Tamanho de cada lista quebrada (exceto última que pode ser menor)</param>
        /// <returns></returns>
        public static IEnumerable<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            var res = source.Select((x, i) => new { Index = i, Value = x })
                            .GroupBy(x => x.Index / chunkSize)
                            .Select(x => x.Select(v => v.Value).ToList());

            return res;
        }

        public static IEnumerable<List<T>> ChunkBy<T>(this IList<T> source, int chunkSize)
        {
            var res = source.Select((x, i) => new { Index = i, Value = x })
                            .GroupBy(x => x.Index / chunkSize)
                            .Select(x => x.Select(v => v.Value).ToList());

            return res;
        }

        public static IEnumerable<IDictionary<T, V>> ChunkBy<T, V>(this Dictionary<T, V> source, int chunkSize)
        {
            var result = source.Select((x, i) => new { Index = i, KeyValuePair = x })
                               .GroupBy(x => x.Index / chunkSize)
                               .Select(x => x.ToDictionary(k => k.KeyValuePair.Key,
                                                           v => v.KeyValuePair.Value));

            return result;
        }
        #endregion ChunkBy
    }
}
