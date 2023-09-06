using System.Security.Cryptography;
using System.Text;

namespace WebApplication.Utils
{
    public static class CommonUtils
    {
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes);
        }
    }
}
