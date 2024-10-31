using System.Security.Claims;
using medicalInformationSystem.Models.Api;
using medicalInformationSystem.Models.Request;
using medicalInformationSystem.Models.Response;
using medicalInformationSystem.Services.Impls;
using medicalInformationSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace medicalInformationSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorizationController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<TokenResponseModel> Register(DoctorRegisterModel doctorRegisterModel)
    {
        var token = await authService.Register(doctorRegisterModel);
        return token;
    }

    [HttpPost("login")]
    public async Task<TokenResponseModel> Login(DoctorLoginModel doctorLoginModel)
    {
        var token = await authService.Login(doctorLoginModel);
        return token;
    }

    [HttpPost("logout")]
    public async Task<ResponseModel> Logout()
    {
        return await authService.Logout();
    }

    [HttpGet("profile")]
    [Authorize]
    public async Task<DoctorModel> GetProfile()
    {
        return await authService.GetProfile(GetDoctorId());
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