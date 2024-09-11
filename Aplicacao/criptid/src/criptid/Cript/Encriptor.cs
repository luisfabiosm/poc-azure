using criptid.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace criptid.Cript
{
    internal class Encriptor
    {
        internal string SecretKey { get; }

        public Encriptor()
        {
            this.SecretKey = Secret.SECRET_KEY;
        }

        public string EncryptInfo(string input, string key = null)
        {
            var _key = key is null ? this.SecretKey : key;

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = Encoding.UTF8.GetBytes(_key.Substring(0, 8));
                des.IV = Encoding.UTF8.GetBytes(_key.Substring(0, 8));

                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] encryptedBytes;

                using (ICryptoTransform encryptor = des.CreateEncryptor())
                {
                    encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                }

                string encryptedBase64 = Convert.ToBase64String(encryptedBytes);
                return encryptedBase64;//.Substring(0, 16);
                
            }
        }

        public string DecryptInfo(string encryptedInput, string key = null)
        {
            var _key = key is null ? this.SecretKey : key;

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = Encoding.UTF8.GetBytes(_key.Substring(0, 8));
                des.IV = Encoding.UTF8.GetBytes(_key.Substring(0, 8));

                byte[] encryptedBytes = Convert.FromBase64String(encryptedInput);
                byte[] decryptedBytes;

                using (ICryptoTransform decryptor = des.CreateDecryptor())
                {
                    decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                }

                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }

      
    }
}
