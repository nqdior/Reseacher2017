using System;
using System.Security.Cryptography;

namespace newtype.Common
{
    public static class EncryptService
    {
        // https://gist.github.com/kankikuchi/a96d5b47ae83b380b83a

        public static string PASS = "newtype";

        public static string EncryptString(string sourceString)
        {
            if (string.IsNullOrEmpty(sourceString)) { return ""; }

            RijndaelManaged rijndael = new RijndaelManaged();

            byte[] key, iv;
            GenerateKeyFromPassword(
            rijndael.KeySize, out key, rijndael.BlockSize, out iv);
            rijndael.Key = key;
            rijndael.IV = iv;

            byte[] strBytes = System.Text.Encoding.UTF8.GetBytes(sourceString);
            ICryptoTransform encryptor = rijndael.CreateEncryptor();

            byte[] encBytes = encryptor.TransformFinalBlock(strBytes, 0, strBytes.Length);
            encryptor.Dispose();

            return System.Convert.ToBase64String(encBytes);
        }

        public static string DecryptString(string sourceString)
        {
            if (string.IsNullOrEmpty(sourceString)) { return ""; }
            RijndaelManaged rijndael = new RijndaelManaged();

            byte[] key, iv;
            GenerateKeyFromPassword(
              rijndael.KeySize, out key, rijndael.BlockSize, out iv);
            rijndael.Key = key;
            rijndael.IV = iv;

            byte[] strBytes = Convert.FromBase64String(sourceString);
            ICryptoTransform decryptor = rijndael.CreateDecryptor();

            byte[] decBytes = decryptor.TransformFinalBlock(strBytes, 0, strBytes.Length);
            decryptor.Dispose();

            return System.Text.Encoding.UTF8.GetString(decBytes);
        }

        private static void GenerateKeyFromPassword(int keySize, out byte[] key, int blockSize, out byte[] iv)
        {
            byte[] salt = System.Text.Encoding.UTF8.GetBytes("saltは必ず8バイト以上");
            Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(PASS, salt);

            deriveBytes.IterationCount = 1000;

            key = deriveBytes.GetBytes(keySize / 8);
            iv = deriveBytes.GetBytes(blockSize / 8);
        }

    }
}
