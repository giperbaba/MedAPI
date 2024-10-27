using medicalInformationSystem.Models.Api;
using medicalInformationSystem.Models.Request;
using medicalInformationSystem.Models.Response;
using Microsoft.AspNetCore.Identity.Data;

namespace medicalInformationSystem.Services.Interfaces;

public interface IAuthService
{
    Task<TokenResponseModel> Register(DoctorRegisterModel doctor);
    Task<TokenResponseModel> Login(DoctorLoginModel doctor);
}
