using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using medicalInformationSystem.Configurations;
using medicalInformationSystem.Core.Services.Interfaces;
using medicalInformationSystem.Data.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace medicalInformationSystem.Core.Services.Impls;

public class TokenService(IOptions<JwtOptions> options): ITokenService
{
    private readonly JwtOptions _options = options.Value;
    public string GenerateAccessToken(Doctor user)
    {
        Claim[] claims =
        [
            new("doctorId", user.Id.ToString())
        ];
        
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddHours(_options.ExpiresHours));
        
        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        
        return tokenValue;
    }
}