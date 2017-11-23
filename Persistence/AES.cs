using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    internal class AES
    {
        internal void test_Cryptografy()
        {

            // Create a new instance of the RijndaelManaged
            // class.  This generates a new key and initialization 
            // vector (IV).
            using (RijndaelManaged myRijndael = new RijndaelManaged())
            {
                string str_Key = string.Empty;
                string str_IV = string.Empty;

                myRijndael.GenerateKey();
                myRijndael.GenerateIV();
                foreach (var item in myRijndael.Key)
                {
                    str_Key += "[" + item.ToString() + "],";
                }

                foreach (var item in myRijndael.IV)
                {
                    str_IV += "[" + item.ToString() + "],";
                }

                // Encrypt the string to an array of bytes.

            }
        }
        internal static string Encrypt(string iPlainStr, string Key, string IV, int iKeySize)
        {
            RijndaelManaged aesEncryption = new RijndaelManaged();
            aesEncryption.KeySize = iKeySize;
            aesEncryption.BlockSize = 128;
            aesEncryption.Mode = CipherMode.CBC;
            aesEncryption.Padding = PaddingMode.PKCS7;

            List<string> strIV = IV.Split(',').ToList();
            List<string> strKey = Key.Split(',').ToList();


            aesEncryption.IV = ListaStringToByteArray(strIV);
            aesEncryption.Key = ListaStringToByteArray(strKey);
            byte[] plainText = ASCIIEncoding.UTF8.GetBytes(iPlainStr);
            ICryptoTransform crypto = aesEncryption.CreateEncryptor();
            byte[] cipherText = crypto.TransformFinalBlock(plainText, 0, plainText.Length);
            return Convert.ToBase64String(cipherText);
        }



        //internal static string Encrypt<T>(string value, string password)
        //       where T : SymmetricAlgorithm, new()
        //{
        //    byte[] vectorBytes = GetBytes<ASCIIEncoding>(_vector);
        //    byte[] saltBytes = GetBytes<ASCIIEncoding>(_salt);
        //    byte[] valueBytes = GetBytes<UTF8Encoding>(value);

        //    byte[] encrypted;
        //    using (T cipher = new T())
        //    {
        //        PasswordDeriveBytes _passwordBytes =
        //            new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
        //        byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

        //        cipher.Mode = CipherMode.CBC;

        //        using (ICryptoTransform encryptor = cipher.CreateEncryptor(keyBytes, vectorBytes))
        //        {
        //            using (MemoryStream to = new MemoryStream())
        //            {
        //                using (CryptoStream writer = new CryptoStream(to, encryptor, CryptoStreamMode.Write))
        //                {
        //                    writer.Write(valueBytes, 0, valueBytes.Length);
        //                    writer.FlushFinalBlock();
        //                    encrypted = to.ToArray();
        //                }
        //            }
        //        }
        //        cipher.Clear();
        //    }
        //    return Convert.ToBase64String(encrypted);
        //}

        /// <summary>
        /// Decrypt
        /// From : www.chapleau.info/blog/2011/01/06/usingsimplestringkeywithaes256encryptioninc.html
        /// </summary>
        internal static string Decrypt(string iEncryptedText, string Key, string IV, int iKeySize)
        {
            RijndaelManaged aesEncryption = new RijndaelManaged();
            aesEncryption.KeySize = iKeySize;
            aesEncryption.BlockSize = 128;
            aesEncryption.Mode = CipherMode.CBC;
            aesEncryption.Padding = PaddingMode.PKCS7;

            List<string> strIV = IV.Split(',').ToList();
            List<string> strKey = Key.Split(',').ToList();


            aesEncryption.IV = ListaStringToByteArray(strIV);
            aesEncryption.Key = ListaStringToByteArray(strKey);

            ICryptoTransform decrypto = aesEncryption.CreateDecryptor();
            byte[] encryptedBytes = Convert.FromBase64CharArray(iEncryptedText.ToCharArray(), 0, iEncryptedText.Length);
            return ASCIIEncoding.UTF8.GetString(decrypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length));
        }

        //internal static string Decrypt<T>(string value, string password) where T : SymmetricAlgorithm, new()
        //{
        //    byte[] vectorBytes = GetBytes<ASCIIEncoding>(_vector);
        //    byte[] saltBytes = GetBytes<ASCIIEncoding>(_salt);
        //    byte[] valueBytes = Convert.FromBase64String(value);

        //    byte[] decrypted;
        //    int decryptedByteCount = 0;

        //    using (T cipher = new T())
        //    {
        //        PasswordDeriveBytes _passwordBytes = new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
        //        byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

        //        cipher.Mode = CipherMode.CBC;

        //        try
        //        {
        //            using (ICryptoTransform decryptor = cipher.CreateDecryptor(keyBytes, vectorBytes))
        //            {
        //                using (MemoryStream from = new MemoryStream(valueBytes))
        //                {
        //                    using (CryptoStream reader = new CryptoStream(from, decryptor, CryptoStreamMode.Read))
        //                    {
        //                        decrypted = new byte[valueBytes.Length];
        //                        decryptedByteCount = reader.Read(decrypted, 0, decrypted.Length);
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            return String.Empty;
        //        }

        //        cipher.Clear();
        //    }
        //    return Encoding.UTF8.GetString(decrypted, 0, decryptedByteCount);
        //}
        private static byte[] ListaStringToByteArray(List<string> listaStringhe)
        {
            byte[] objout = new byte[listaStringhe.Count()];
            int i = 0;
            foreach (string item in listaStringhe)
            {
                objout[i] = Convert.ToByte(item);
                i++;
            }

            return objout;

        }
    }
}
