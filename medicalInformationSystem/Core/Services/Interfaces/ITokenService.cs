using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Services.Interfaces;

public interface ITokenService
{
    public string GenerateAccessToken(Doctor doctor);

}