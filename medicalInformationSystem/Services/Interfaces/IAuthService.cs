using medicalInformationSystem.Models.Api;
using medicalInformationSystem.Models.Request;
using medicalInformationSystem.Models.Response;

namespace medicalInformationSystem.Services.Interfaces;

public interface IAuthService
{
    Task<TokenResponseModel> Register(DoctorRegisterModel doctor);
    Task<TokenResponseModel> Login(DoctorLoginModel doctorLoginModel);

    Task<ResponseModel> Logout();
    Task<DoctorModel> GetProfile(Guid doctorId);
}
