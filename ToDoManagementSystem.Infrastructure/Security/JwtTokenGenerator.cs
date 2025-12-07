using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ToDoManagementSystem.Application.Interfaces.Security;
using ToDoManagementSystem.Infrastructure.Configuration;

namespace ToDoManagementSystem.Infrastructure.Security
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _settings;

        public JwtTokenGenerator(IOptions<JwtSettings> settings)
        {
            _settings = settings.Value;
        }
        public string GenerateJwtToken(string employeeId, string employeeEmail, string employeeName)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, employeeId),
                new Claim(JwtRegisteredClaimNames.Email, employeeEmail),
                new Claim(JwtRegisteredClaimNames.UniqueName, employeeName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
