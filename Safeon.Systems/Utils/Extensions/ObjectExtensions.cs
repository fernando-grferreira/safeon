using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Safeon.Systems.Utils.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Copia todas as propriedades de um objeto para outro de outro tipo qualquer que tenha as mesmas propriedades (mesmos nomes).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myobj"></param>
        /// <seealso cref="https://stackoverflow.com/questions/3672742/cast-class-into-another-class-or-convert-class-to-another"/>
        /// <returns></returns>
        /// <remarks>
        /// TODO: filtrar propriedades que não podem ser setadas (não tem set)
        /// </remarks>
        public static T Cast<T>(this Object myobj)
        {
            Type objectType = myobj.GetType();
            Type target = typeof(T);
            var x = Activator.CreateInstance(target, false);
            var z = from source in objectType.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            var d = from source in target.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            List<MemberInfo> members = d.Where(memberInfo => d.Select(c => c.Name)
               .ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in members)
            {
                propertyInfo = typeof(T).GetProperty(memberInfo.Name);                

                try
                {
                    value = myobj.GetType().GetProperty(memberInfo.Name).GetValue(myobj, null);
                    propertyInfo.SetValue(x, value, null);
                }
                catch (Exception)
                {

                }

            }
            return (T)x;
        }

        public static List<T> Cast<T>(this IEnumerable<Object> itens)
        {
            List<T> list = new List<T>();
            foreach(var item in itens)
            {
                list.Add(item.Cast<T>());
            }

            return list;
        }
    }
}
