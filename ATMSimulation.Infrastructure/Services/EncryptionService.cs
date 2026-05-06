using ATMSimulation.Application.Abstraction;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace ATMSimulation.Infrastructure.Services
{
    public class EncryptionService : IEncryptionService
    {
        private readonly string _key;

        public EncryptionService(IConfiguration config)
        {
            _key = config["EncryptionKey"];
        }

        public string Decrypt(string cipherText)
        {
            var fullCipher = Convert.FromBase64String(cipherText);

            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(_key);

            var iv = new byte[16];
            Array.Copy(fullCipher, iv, iv.Length);

            aes.IV = iv;

            var decryptor = aes.CreateDecryptor();

            using var ms = new MemoryStream(fullCipher, iv.Length, fullCipher.Length - iv.Length);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);

            return sr.ReadToEnd();
        }

        public string Encrypt(string plainText)
        {

            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(_key);
            aes.GenerateIV();

            var encryptor = aes.CreateEncryptor();

            using var ms = new MemoryStream();
            ms.Write(aes.IV, 0, aes.IV.Length);

            using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            using var sw = new StreamWriter(cs);

            sw.Write(plainText);

            return Convert.ToBase64String(ms.ToArray()); 
        }
    }
}
