using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Core.Services.Interfaces;
using medicalInformationSystem.Models.Request;
using medicalInformationSystem.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using medicalInformationSystem.Configurations.Constants;

namespace medicalInformationSystem.Api.Controllers;

[ApiController]
[Route("api/doctor")]
public class DoctorController(IAuthService authService, IProfileService profileService) : BaseController
{
    [HttpPost("register")]
    [SwaggerOperation(Summary = SwaggerOperationConstants.UserRegister)]
    public async Task<TokenResponseModel> Register(DoctorRegisterModel doctorRegisterModel)
    {
        var token = await authService.Register(doctorRegisterModel);
        return token;
    }

    [HttpPost("login")]
    [SwaggerOperation(Summary = SwaggerOperationConstants.UserLogin)]
    public async Task<TokenResponseModel> Login(LoginCredentialsModel loginCredentialsUser)
    {
        var token = await authService.Login(loginCredentialsUser);
        return token;
    }

    [HttpPost("logout")]
    [SwaggerOperation(Summary = SwaggerOperationConstants.UserLogout)]
    [Authorize]
    public async Task<ResponseModel> Logout()
    {
        return await authService.Logout();
    }

    [HttpGet("profile")]
    [SwaggerOperation(Summary = SwaggerOperationConstants.UserGetProfile)]
    [Authorize]
    public async Task<DoctorModel> GetProfile()
    {
        return await profileService.GetProfile(GetDoctorId());
    }

    [HttpPut("profile")]
    [SwaggerOperation(Summary = SwaggerOperationConstants.UserEditProfile)]
    [Authorize]
    public async Task<ResponseModel> EditProfile(DoctorEditModel doctorEditModel)
    {
        return await profileService.EditProfile(doctorEditModel);
    }
}