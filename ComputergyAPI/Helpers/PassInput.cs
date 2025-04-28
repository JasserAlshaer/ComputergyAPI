using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace ComputergyAPI.Helpers
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            byte[] key = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100_000,
                numBytesRequested: 32);

            byte[] result = new byte[16 + 32];
            Buffer.BlockCopy(salt, 0, result, 0, 16);
            Buffer.BlockCopy(key, 0, result, 16, 32);

            return Convert.ToBase64String(result);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            byte[] decoded = Convert.FromBase64String(hashedPassword);

            byte[] salt = new byte[16];
            byte[] storedSubkey = new byte[32];
            Buffer.BlockCopy(decoded, 0, salt, 0, 16);
            Buffer.BlockCopy(decoded, 16, storedSubkey, 0, 32);

            byte[] actualSubkey = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100_000,
                numBytesRequested: 32);

            return CryptographicOperations.FixedTimeEquals(storedSubkey, actualSubkey);
        }
    }
}
