using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Security.Cryptography;


namespace ConsoleDBTest
{
    public class PCoder
    {
        public string EncryptByKey(string text, string key)
        {
            byte[] TextBytes;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = aes.Key;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] plainBytes = Encoding.UTF8.GetBytes(text);
                        cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                        cryptoStream.FlushFinalBlock();

                        TextBytes = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(TextBytes);
        }

        public string DecryptByKey(string text, string key)
        {
            byte[] TextBytes = Convert.FromBase64String(text);
            string ResultText;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = aes.Key; // Используем ключ как вектор инициализации (IV) для простоты примера. Не рекомендуется использовать такой подход в реальных сценариях.

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(TextBytes))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            ResultText = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return ResultText;
        }
    }
}
