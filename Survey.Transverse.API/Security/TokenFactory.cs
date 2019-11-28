using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Survey.API._Helpers;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Survey.API.Security
{
    public class TokenFactory : ITokenFactory
    {
        private readonly AppSettings _appSettings;

        public TokenFactory(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public string createToken(string userId,out SecurityToken securityToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", userId)
               

                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            securityToken = token;
            return tokenString;
        }
    }
}
