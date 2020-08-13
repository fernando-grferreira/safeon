using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;

namespace Safeon.Systems.Utils.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt(this string value)
        {
            return int.TryParse(value, out int result) ? result : default(int);
        }

        public static string RemoveDocumentSpecialCharacters(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            return value.Replace("-", string.Empty).Replace(".", string.Empty).Replace("/", string.Empty);
        }

        public static bool IsValidEmail(this string email)
        {
            bool valid = false;

            try
            {
                new MailAddress(email);
                valid = true;
            }
            catch (Exception)
            {
                valid = false;
            }

            return valid;
        }

        public static bool IsDigit(this string document)
        {
            return document.All(Char.IsDigit);
        }

        public static bool IsValidCpfCnpj(this string document)
        {
            var cpfcnpj = document.RemoveDocumentSpecialCharacters();
            if (cpfcnpj.Length == 11)
                return IsValidCpf(cpfcnpj);
            else if (cpfcnpj.Length == 14)
                return IsValidCnpj(cpfcnpj);
            else
                return false;
        }

        public static bool IsValidCnpj(this string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        public static string ToCamelCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return str[0].ToString().ToLower() + str.Substring(1, str.Length - 1);
        }

        public static string ToTitleCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            var firstLetter = str.ToArray().First();
            var remainingLetters = str.Substring(1, str.Length - 1);
            var result = $"{firstLetter.ToString().ToUpper()}{remainingLetters.ToLower()}";

            return result;
        }

        public static bool IsValidCpf(this string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="text"></param>
        /// <param name="separator"></param>
        /// <param name="culture">Padrão en-US</param>
        /// <returns></returns>
        public static IEnumerable<T> ToIEnumerable<T>(this string text, char separator = ',', CultureInfo culture = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new List<T>().AsEnumerable();

            var list = text.Split(separator);

            if (list == null || list.Length == 0)
                return new List<T>().AsEnumerable();

            if (culture == null)
                culture = new CultureInfo("en-US");

            return list.Select(x => (T)(Convert.ChangeType(x, typeof(T), culture)));
        }
    }
}
