using medicalInformationSystem.Entities;

namespace medicalInformationSystem.Services.Interfaces;

public interface ITokenService
{
    public string GenerateAccessToken(Doctor doctor);

}