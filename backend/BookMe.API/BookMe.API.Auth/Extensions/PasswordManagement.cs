using System.Security.Cryptography;
using System.Text;

namespace BookMe.API.Auth.Extensions
{
    public class PasswordManagement
    {
        public class HashResult
        {
            public string Hash { get; set; }
            public byte[] Salt { get; set; }
        }

        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        async Task<HashResult> HashPasswordAsync(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = await Task.Run(() => Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize));

            return new HashResult { Hash = Convert.ToHexString(hash), Salt = salt };
        }

        async Task<bool> VerifyPasswordAsync(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);

            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }
    }

}
