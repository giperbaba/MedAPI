using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using medicalInformationSystem.Configurations;
using medicalInformationSystem.Entities;
using medicalInformationSystem.Models.Request;
using medicalInformationSystem.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace medicalInformationSystem.Services.Impls;

public class TokenService(IOptions<JwtOptions> options): ITokenService
{
    private readonly JwtOptions _options = options.Value;
    public string GenerateAccessToken(Doctor doctor)
    {
        Claim[] claims =
        [
            new("doctorId", doctor.Id.ToString())
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