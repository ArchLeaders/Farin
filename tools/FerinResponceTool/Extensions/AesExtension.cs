using System.Text;

namespace System.Security.Cryptography
{
    public static class AesExtension
    {
        /// <summary>
        /// Get an AES hashed key from a string key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte[] ToAesKey(this string key)
        {
            string hash = "";
            using (MD5 md5 = MD5.Create())
                hash = string.Concat(md5.ComputeHash(Encoding.UTF8.GetBytes(key)).Select(x => x.ToString("x2")));

            return Encoding.UTF8.GetBytes(hash);
        }

        /// <summary>
        /// Decrypt a AES encrypted byte array.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static byte[] DecryptBytes(this byte[] data, string password)
        {
            byte[] decrypted = Array.Empty<byte>();

            using (Aes aes = Aes.Create()) {

                int buffer = 0;

                aes.Key = password.ToAesKey();
                aes.IV = new byte[16];

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using MemoryStream decryptedStream = new();
                using MemoryStream encryptedStream = new(data);
                using CryptoStream cryptoStream = new(encryptedStream, decryptor, CryptoStreamMode.Read);
                while ((buffer = cryptoStream.ReadByte()) != -1)
                    decryptedStream.WriteByte((byte)buffer);

                decrypted = decryptedStream.ToArray();
            }

            return decrypted;
        }

        /// <summary>
        /// Encrypt a byte array using the AES algorithm.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static byte[] EncryptBytes(this byte[] data, string password)
        {
            byte[] encrypted = Array.Empty<byte>();

            using (Aes aes = Aes.Create()) {

                int buffer = 0;

                aes.Key = password.ToAesKey();
                aes.IV = new byte[16];

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using MemoryStream encryptedStream = new();
                using MemoryStream decryptedStream = new(data);
                using CryptoStream cryptoStream = new(decryptedStream, encryptor, CryptoStreamMode.Read);
                while ((buffer = cryptoStream.ReadByte()) != -1)
                    encryptedStream.WriteByte((byte)buffer);

                encrypted = encryptedStream.ToArray();
            }

            return encrypted;
        }
    }
}
