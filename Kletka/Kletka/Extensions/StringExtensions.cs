using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Kletka.Extensions
{
    public static class StringExtensions
    {
        public static string GenerateSHA256Hash(this string input)
        {
            var bytes = Encoding.Unicode.GetBytes(input);
            using (var hashEngine = SHA256.Create())
            {
                var hashedBytes = hashEngine.ComputeHash(bytes, 0, bytes.Length);
                var sb = new StringBuilder();
                foreach (var b in hashedBytes)
                {
                    var hex = b.ToString("x2");
                    sb.Append(hex);
                }
                return sb.ToString();
            }
        }
    }
}