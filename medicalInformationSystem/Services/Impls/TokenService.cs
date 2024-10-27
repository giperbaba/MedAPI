using System.Text;
using medicalInformationSystem.Entities;
using medicalInformationSystem.Services.Interfaces;

namespace medicalInformationSystem.Services.Impls;

public class TokenService: ITokenService
{
    public string GenerateAccessToken(Doctor doctor)
    {
        //TODO: create jwt token
        var jwt = string.Empty;
        return jwt;
    }
}