using CodingJournal.API.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CodingJournal.API.Services.TokenServices
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration conf)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(conf["TokenKey"]));
        }

        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.NameId,user.UserName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHanlder = new JwtSecurityTokenHandler();

            var token = tokenHanlder.CreateToken(tokenDescriptor);

            return tokenHanlder.WriteToken(token);
        }
    }
}
