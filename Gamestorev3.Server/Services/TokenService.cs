using Gamestore.Models;
using Gamestorev3.Server.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gamestorev3.Server.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            var tokenKey = config["TokenKey"];
            if (string.IsNullOrEmpty(tokenKey))
            {
                throw new ArgumentException("TokenKey is missing in configuration");
            }

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

        }
        public string CreateToken(Users User) 
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, User.EmailAddress)
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };
            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(TokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}
