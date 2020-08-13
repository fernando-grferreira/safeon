using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Safeon.Systems.Utils
{
    public class Security
    {
        private static byte[] mBytes = new byte[] { 60, 123, 40, 21, 213, 49, 224, 90 };

        public static string GenerateSalt()
        {
            Random rd = new Random();
            int size = 8;

            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rd.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        public static string GenerateCryptoPass(string salt, string password)
        {
            SHA256Managed crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(salt + password), 0, Encoding.ASCII.GetByteCount(salt + password));
            foreach (byte bit in crypto)
            {
                hash += bit.ToString("x2");
            }
            return hash;
        }

        public static string GenerateToken(string newstring)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(newstring));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));

            return sBuilder.ToString();
        }

        public static string Encrypt(string value)
        {
            string ret = string.Empty;

            if (String.IsNullOrEmpty(value))
                return ret;

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(mBytes, mBytes), CryptoStreamMode.Write);

            using (StreamWriter writer = new StreamWriter(cryptoStream))
            {
                writer.Write(value);
                writer.Flush();
                cryptoStream.FlushFinalBlock();
                writer.Flush();

                ret = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }
            return ret;
        }

        public static string Decrypt(string value)
        {
            string ret = string.Empty;

            if (String.IsNullOrEmpty(value))
                return ret;

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(value));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(mBytes, mBytes), CryptoStreamMode.Read);

            using (StreamReader reader = new StreamReader(cryptoStream))
            {
                ret = reader.ReadToEnd();
            }
            return ret;
        }

        public static string GenerateHash(int size)
        {
            string charsvalids = "abcdefghijklmnopqrstuvwxyz0123456789";
            var hash = new char[size];
            var random = new Random();

            for (int i = 0; i < size; i++)
            {
                char charGenerate;

                do
                {
                    charGenerate = charsvalids[random.Next(0, charsvalids.Length)];
                }
                while (hash.Contains(charGenerate));

                hash[i] = charGenerate;
            }

            return new String(hash);
        }
    }
}
