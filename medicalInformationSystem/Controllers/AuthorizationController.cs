using medicalInformationSystem.Models.Api;
using medicalInformationSystem.Models.Request;
using medicalInformationSystem.Models.Response;
using medicalInformationSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace medicalInformationSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorizationController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(DoctorRegisterModel doctorRegisterModel)
    {
        await authService.Register(doctorRegisterModel);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<TokenResponseModel> Login(DoctorLoginModel doctorLoginModel)
    {
        var token = await authService.Login(doctorLoginModel);
        return token;
    }
}