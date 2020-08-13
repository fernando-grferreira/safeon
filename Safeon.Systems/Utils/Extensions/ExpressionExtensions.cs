using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Safeon.Systems.Utils.Extensions
{
    public static class ExpressionExtensions
    {
        /// <summary>
        /// Retorna o path de uma propriedade
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression"></param>
        /// <param name="excludeFirstLevel">Exclui o primeiro nível do path se true</param>
        /// <returns></returns>
        public static string PropertyPath<TProperty>(this Expression<Func<TProperty>> expression, bool excludeFirstLevel = true)
        {
            var memberNames = new List<string>();

            var memberExpression = expression.Body as MemberExpression;
            while (null != memberExpression)
            {
                memberNames.Add(memberExpression.Member.Name);
                memberExpression = memberExpression.Expression as MemberExpression;
            }

            memberNames.Reverse();
            if (excludeFirstLevel)
                memberNames.RemoveAt(0);
            string fullName = string.Join(".", memberNames.ToArray());
            return fullName;
        }

        /// <summary>
        /// Retorna o path de uma propriedade.
        /// </summary>
        /// <typeparam name="TModelo"></typeparam>
        /// <typeparam name="TPropriedade"></typeparam>
        /// <param name="expression"></param>
        /// <example>
        ///     //Uso PropertyPath<Person, string>(p => p.FirstName);
        ///     var caminho = ReflationExtensions.PropertyPath<Grupo, string>(p => p.Cliente.NomeFantasia); // retorna "Cliente.NomeFantasia"
        /// </example>
        /// <returns></returns>        
        public static string PropertyPath<TModelo, TPropriedade>(this Expression<Func<TModelo, TPropriedade>> expression)
        {
            var memberNames = new List<string>();

            var memberExpression = expression.Body as MemberExpression;
            while (null != memberExpression)
            {
                memberNames.Add(memberExpression.Member.Name);
                memberExpression = memberExpression.Expression as MemberExpression;
            }

            memberNames.Reverse();
            string fullName = string.Join(".", memberNames.ToArray());
            return fullName;
        }
    }
}
