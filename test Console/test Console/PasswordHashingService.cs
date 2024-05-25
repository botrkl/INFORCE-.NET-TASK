using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace test_Console
{
    public class PasswordHashingService
    {
        public string HashPassword(string password)
        {
            // Генерация соли
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            // Хеширование пароля
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            // Возвращаем хэшированный пароль и соль, чтобы сохранить их в базе данных
            return $"{Convert.ToBase64String(salt)}:{hashed}";
        }

        // Метод для проверки пароля
        public bool VerifyPassword(string password, string hashedPassword)
        {
            // Получение соли из хэшированного пароля
            string[] parts = hashedPassword.Split(':');
            byte[] salt = Convert.FromBase64String(parts[0]);

            // Хеширование введенного пароля с использованием той же соли
            string hashedInputPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            // Сравнение хэшированного введенного пароля с хэшированным паролем в базе данных
            return hashedInputPassword == parts[1];
        }
    }
}
