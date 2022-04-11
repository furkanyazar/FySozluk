using Business.Constants;
using System.Text;

namespace WebApp.Helpers
{
    public class HashingHelper
    {
        public static string PasswordHash(string password)
        {
            byte[] key = Encoding.UTF8.GetBytes(Defaults.PASSWORD_HASH_KEY);

            using (var hmac = new System.Security.Cryptography.HMACSHA512(key))
            {
                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return Encoding.Default.GetString(passwordHash);
            }
        }
    }
}
