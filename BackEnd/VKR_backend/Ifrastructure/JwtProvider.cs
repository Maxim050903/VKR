using Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Infrastructure
{
    public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
    {
        private readonly JwtOptions _options = options.Value;

        public string GenerateToken(User user)
        {

            Claim[] claims = [new("UserId", user.Id.ToString()),new (ClaimTypes.Role, user.Role.ToString())];

            var signingCreadentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCreadentials,
                expires: DateTime.UtcNow.AddHours(_options.ExpiterHours)
                );

            var TokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return TokenValue;
        }
    }
}
