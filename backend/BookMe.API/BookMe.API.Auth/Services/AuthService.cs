using BookMe.API.Auth.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BookMe.API.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly string _secretKey;
        private readonly int _keySize;
        private readonly int _iterations;
        private readonly IUserService _userService;

        public AuthService(IConfiguration configuration, IUserService userService)
        {
            _secretKey = configuration.GetValue<string>("SecretKey");
            _keySize = configuration.GetValue<int>("KeySize");
            _iterations = configuration.GetValue<int>("Iterations");
            _userService = userService;
        }

        public async Task <string> Authenticate(string email, string password)
        {
            var user = await _userService.GetByEmailAsync(email);

            if (user == null)
                return null;


            var passwordMatch = await VerifyPasswordAsync(password, user.PasswordHash, user.PasswordSalt);

            if (!passwordMatch)
            {
                throw new Exception("Invalid Credentials");
            }

            //Token Creation
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("FirstName", user.FirstName),
                    new Claim("LastName", user.LastName),
                    new Claim("Email", user.Email),
                    new Claim("RgDate", user.RegistrationDate.ToString("yyyy-MM-ddTHH:mm:ss")),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



        //Helper Methods
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        async Task<bool> VerifyPasswordAsync(string password, string hash, byte[] salt)
        {
            var hashToCompare = await Task.Run(() => Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, hashAlgorithm, _keySize));

            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }

    }
}
