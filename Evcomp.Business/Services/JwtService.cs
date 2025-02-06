using Evcomp.API.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Evcomp.Business.Services
{
    public class JwtService
    {
        private readonly IOptions<AuthSettings> _options;

        public JwtService(IOptions<AuthSettings> options)
        {
            _options = options;
        }

        public string GenerateToken(UserEntity user)
        {
            var claims = new List<Claim>
            {
                new Claim("userName", user.UserName),
                new Claim("fullName", user.FirstName),
                new Claim("role", user.Role),
                new Claim("id", user.Id.ToString()),
            };

            var jwtToken = new JwtSecurityToken(
                expires: DateTime.UtcNow.Add(_options.Value.Expires),
                claims: claims,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_options.Value.SecretKey)),
                    SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
