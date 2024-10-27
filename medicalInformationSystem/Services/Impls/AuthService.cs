using medicalInformationSystem.Mappers;
using medicalInformationSystem.Models.Request;
using medicalInformationSystem.Models.Response;
using medicalInformationSystem.Services.Interfaces;

namespace medicalInformationSystem.Services.Impls;

public class AuthService : IAuthService
{
    public Task<TokenResponseModel> Register(DoctorRegisterModel doctor)
    {
       
    }

    public Task<TokenResponseModel> Login(DoctorLoginModel doctor)
    {
        
    }
}
