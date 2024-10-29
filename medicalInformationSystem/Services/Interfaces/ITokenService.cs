using medicalInformationSystem.Entities;
using medicalInformationSystem.Models.Request;

namespace medicalInformationSystem.Services.Interfaces;

public interface ITokenService
{
    public string GenerateAccessToken(Doctor doctor);

}