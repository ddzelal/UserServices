using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRepository.Interfaces;
using System.Security.Cryptography;
using Microsoft.Extensions.Options;


namespace UserRepository.Helper
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly HashSettings _hashSettings;
        private static readonly HashAlgorithmName hashAlgorithmName = HashAlgorithmName.SHA256;
        public PasswordHasher(IOptions<HashSettings> hashSettings)
        {
            _hashSettings = hashSettings.Value;
        }
        public string HashPassword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(_hashSettings.SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, _hashSettings.Iterations, hashAlgorithmName, _hashSettings.KeySize);

            return string.Join(_hashSettings.Separator, Convert.ToBase64String(hash), Convert.ToBase64String(salt));
        }

        public bool Verify(string passwordHash, string inputPassword)
        {
            string[] elements = passwordHash.Split(_hashSettings.Separator);

            byte[] salt = Convert.FromBase64String(elements[1]);
            byte[] hash = Convert.FromBase64String(elements[0]);

            var hashedInput = Rfc2898DeriveBytes.Pbkdf2(inputPassword, salt, _hashSettings.Iterations, hashAlgorithmName, _hashSettings.KeySize);

            return CryptographicOperations.FixedTimeEquals(hash, hashedInput);
        }
    }
}