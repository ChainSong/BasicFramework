using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BasicFramework.Common
{
    public class AES
    {
        private const char cSlashZero = '\0';
        private static string _key = "PZ4I8458bMuM5C8trm6Yj/iGk+jF7sOoJZwft26Ndb8=";
        private static string _iv = "l6NAuirNhjouRKtgNlVv/A==";

        public static string DefaultKey
        {
            private get { return _key; }
            set { _key = value; }
        }

        public static string DefaultIV
        {
            private get { return _iv; }
            set { _iv = value; }
        }

        /// <summary>
        /// Generate Secret Key
        /// </summary>
        /// <returns>Secret Key</returns>
        public static string GenerateSecretKey()
        {
            using (AesManaged aesManaged = new AesManaged())
            {
                aesManaged.GenerateKey();

                return Convert.ToBase64String(aesManaged.Key);
            }
        }

        /// <summary>
        /// Generate Vector
        /// </summary>
        /// <returns>Vector String</returns>
        public static string GenerateVector()
        {
            using (AesManaged aesManaged = new AesManaged())
            {
                aesManaged.GenerateIV();

                return Convert.ToBase64String(aesManaged.IV);
            }
        }

        public static string Encrypt(string sData, string skey, string sIV)
        {
            byte[] key = null;
            byte[] IV = null;
            byte[] encrypted = null;
            byte[] toEncrypt = null;

            using (AesManaged aesManaged = new AesManaged())
            {
                key = Convert.FromBase64CharArray(skey.ToCharArray(), 0, skey.Length);
                IV = Convert.FromBase64CharArray(sIV.ToCharArray(), 0, sIV.Length);
                using (ICryptoTransform encryptor = aesManaged.CreateEncryptor(key, IV))
                {
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            toEncrypt = UnicodeEncoding.Unicode.GetBytes(sData);
                            csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
                            csEncrypt.FlushFinalBlock();
                            encrypted = msEncrypt.ToArray();
                            return Convert.ToBase64String(encrypted);
                        }
                    }
                }
            }
        }

        public static string Encrypt(string sData)
        {
            return Encrypt(sData, DefaultKey, DefaultIV);
        }

        public static string Decrypt(string sData, string skey, string sIV)
        {
            byte[] key = null;
            byte[] IV = null;
            byte[] decrypted = null;
            byte[] toDecrypt = null;

            using (AesManaged aesManaged = new AesManaged())
            {
                key = Convert.FromBase64CharArray(skey.ToCharArray(), 0, skey.Length);
                IV = Convert.FromBase64CharArray(sIV.ToCharArray(), 0, sIV.Length);
                using (ICryptoTransform decryptor = aesManaged.CreateDecryptor(key, IV))
                {
                    toDecrypt = Convert.FromBase64String(sData);

                    using (MemoryStream msDecrypt = new MemoryStream(toDecrypt))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            decrypted = new byte[toDecrypt.Length];
                            csDecrypt.Read(decrypted, 0, toDecrypt.Length);
                            return UnicodeEncoding.Unicode.GetString(decrypted, 0, decrypted.Length).TrimEnd(cSlashZero);
                        }
                    }
                }
            }
        }

        public static string Decrypt(string sData)
        {
            return Decrypt(sData, DefaultKey, DefaultIV);
        }
    }
}