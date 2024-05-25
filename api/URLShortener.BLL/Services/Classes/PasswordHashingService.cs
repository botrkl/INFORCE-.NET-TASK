using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using URLShortener.BLL.Services.Intefaces;

namespace URLShortener.BLL.Services.Classes
{
    public class PasswordHashingService : IPasswordHashingService
    {
        public async Task<string> HashPasswordAsync(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                await Task.Run(() => rng.GetBytes(salt));
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return $"{Convert.ToBase64String(salt)}:{hashed}";
        }

        public Task<bool> VerifyPasswordAsync(string password, string hashedPassword)
        {
            string[] parts = hashedPassword.Split(':');
            byte[] salt = Convert.FromBase64String(parts[0]);

            string hashedInputPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return Task.FromResult(hashedInputPassword == parts[1]);
        }
    }
}
