using System.Text;

namespace Safeon.Systems.Utils.Extensions
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendIfNotNull(this StringBuilder stringBuilder, string separator, params string[] args)
        {
            if (args == null || args.Length == 0)
                return stringBuilder;

            foreach(var arg in args)
            {
                stringBuilder.AppendIfNotNull(arg, separator);
            }

            return stringBuilder;
        }

        /// <summary>
        /// Faz append de text em stringBuilder se text não for nulo nem espaços em brancos.
        /// Faz append de separator antes de fazer append de text.
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <param name="text"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static StringBuilder AppendIfNotNull(this StringBuilder stringBuilder, string text, string separator = " ")
        {
            if (string.IsNullOrWhiteSpace(text) == false)
            {
                if(stringBuilder.Length > 0)
                    stringBuilder.Append(separator);

                stringBuilder.Append(text);
            }

            return stringBuilder;
        }
    }
}
