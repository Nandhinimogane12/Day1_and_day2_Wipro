using BCrypt.Net;

namespace SecureBankingApp.Services
{
    public class SecurityService
    {
        // HASH PASSWORD
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // VERIFY PASSWORD
        public bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}