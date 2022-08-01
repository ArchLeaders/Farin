using System.Text;

namespace System.Security.Cryptography
{
    internal static class HashExtension
    {
        public static string Md5Hash(this string value)
        {
            using MD5 md5 = MD5.Create();
            return Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(value)));
        }
    }
}
