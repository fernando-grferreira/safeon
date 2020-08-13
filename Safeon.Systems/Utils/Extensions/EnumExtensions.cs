using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Safeon.Systems.Utils.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            if (value == null)
                return null;
            var desc = value.GetAttribute<System.ComponentModel.DescriptionAttribute>();
            if (desc != null)
                return desc.Description;
            var nome = value.ToString();
            return nome;
        }

        public static List<string> GetDescriptions(this Enum value)
        {
            var values = Enum.GetValues(value.GetType());
            List<string> descriptions = new List<string>();

            foreach(var item in values)
            {
                var description = EnumExtensions.GetDescription((Enum)item);
                descriptions.Add(description);
            }

            return descriptions;
        }

        public static T GetAttribute<T>(this Enum enumValue)
            where T : Attribute
        {
            T attribute;

            if (enumValue == null)
                return null;

            var memberInfo = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();

            if (memberInfo != null)
            {
                attribute = (T)memberInfo.GetCustomAttributes(typeof(T), false).FirstOrDefault();
                return attribute;
            }
            return null;
        }

        public static T GetEnumFrom<T>(this string value)
            where T : IComparable, IFormattable, IConvertible
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static T GetEnumFrom<T>(this int value)
            where T : IComparable, IFormattable, IConvertible
        {
            var res = (T)Enum.ToObject(typeof(T), value);
            return res;
        }

        public static string GetDescriptionFrom<T>(this int value)
            where T : IComparable, IFormattable, IConvertible
        {
            if (Enum.IsDefined(typeof(T), value))
            {
                var enumValue = (Enum)Enum.ToObject(typeof(T), value);
                var res = GetDescription(enumValue);
                return res;
            }
            return string.Empty;
        }

        public static bool IsDefinedInEnum<T>(this object value)
            where T : IComparable, IFormattable, IConvertible
        {
            var res = Enum.IsDefined(typeof(T), value);
            return res;
        }

        public static int ToInt<T>(this T value)
            where T : IComparable, IFormattable, IConvertible
        {
            int res = Convert.ToInt32(value);
            return res;
        }

        public static long ToLong<T>(this T value)
            where T : IComparable, IFormattable, IConvertible
        {
            long res = Convert.ToInt64(value);
            return res;
        }

        public static bool IsInto(this Enum value, params Enum[] listOfValues)
        {
            bool isinto = listOfValues.Contains(value);
            return isinto;
        }

        public static bool IsNotInto(this Enum value, params Enum[] listOfValues)
        {
            return !IsInto(value, listOfValues);
        }

        public static string GetDescription2(this Enum enumValue)
        {
            Type enumType = enumValue.GetType();
            FieldInfo fieldInfo = enumType.GetField(enumValue.ToString());
            var descAttr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute)) as DescriptionAttribute;

            if (descAttr == null)
                return enumValue.ToString();

            return descAttr.Description;
        }
    }
}