using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using PoznajRzeszow.Domain.Interfaces.Services;
using System;
using System.Security.Cryptography;
using System.Text;

namespace PoznajRzeszow.Application.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string GenerateHash(string password, string salt)
        {
            var bytes = KeyDerivation.Pbkdf2(
                            password: password,
                            salt: Encoding.UTF8.GetBytes(salt),
                            prf: KeyDerivationPrf.HMACSHA512,
                            iterationCount: 10000,
                            numBytesRequested: 256 / 8);
            return Convert.ToBase64String(bytes);
        }

        public string GenerateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            var generator = RandomNumberGenerator.Create();
            generator.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        public bool Validate(string password, string salt, string hashedPassword)
            => GenerateHash(password, salt) == hashedPassword;
    }
}
