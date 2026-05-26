using System.Security.Cryptography;
using System.Text;

namespace SecureBankingApp.Services
{
    public class HmacService
    {
        private readonly string secretKey = "MySecretKey";

        public string GenerateHMAC(string data)
        {
            using var hmac = new HMACSHA256(
                Encoding.UTF8.GetBytes(secretKey));

            byte[] hash = hmac.ComputeHash(
                Encoding.UTF8.GetBytes(data));

            return Convert.ToBase64String(hash);
        }
    }
}