using System.Security.Cryptography;
using System.Text;

namespace WebApplication3.Utils
{
    public static class CommonUtils
    {
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.Unicode.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes);
        }
    }
}
