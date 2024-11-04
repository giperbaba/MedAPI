using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Core.Services.Interfaces;
using medicalInformationSystem.Models.Request;
using medicalInformationSystem.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace medicalInformationSystem.Api.Controllers;

[ApiController]
[Route("api/doctor")]
public class DoctorController(IAuthService authService, IProfileService profileService) : ControllerBase
{
    [HttpPost("register")]
    [SwaggerOperation(Summary = "Register new user")]
    public async Task<TokenResponseModel> Register(DoctorRegisterModel doctorRegisterModel)
    {
        var token = await authService.Register(doctorRegisterModel);
        return token;
    }
    
    [HttpPost("login")]
    [SwaggerOperation(Summary = "Login in to the system")]
    public async Task<TokenResponseModel> Login(DoctorLoginModel loginUser)
    {
        var token = await authService.Login(loginUser);
        return token;
    }

    [HttpPost("logout")]
    [SwaggerOperation(Summary = "Log out system user")]
    public async Task<ResponseModel> Logout()
    {
        return await authService.Logout();
    }
    
    [HttpGet("profile")]
    [SwaggerOperation(Summary = "Get user profile")]
    [Authorize]
    public async Task<DoctorModel> GetProfile()
    {
        return await profileService.GetProfile(GetDoctorId());
    }
    
    [HttpPut("profile")]
    [SwaggerOperation(Summary = "Edit user profile")]
    [Authorize]
    public async Task<ResponseModel> EditProfile(DoctorEditModel doctorEditModel)
    {
        return await profileService.EditProfile(doctorEditModel);
    }
    
    private Guid GetDoctorId()
    {
        var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

        if (doctorIdClaim == null)
        {
            throw new UnauthorizedAccessException();
        }

        if (!Guid.TryParse(doctorIdClaim.Value, out var doctorId))
        {
            throw new InvalidOperationException("Invalid Doctor ID.");
        }

        return doctorId;
    }
}