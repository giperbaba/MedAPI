using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Models.Response;

namespace medicalInformationSystem.Core.Services.Interfaces;

public interface IAuthService
{
    Task<TokenResponseModel> Register(DoctorRegisterModel user);
    Task<TokenResponseModel> Login(DoctorLoginModel doctorLoginModel);
    Task<ResponseModel> Logout();
}
