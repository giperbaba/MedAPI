using medicalInformationSystem.Services.Interfaces;

namespace medicalInformationSystem.Controllers;

public class AuthorizationController(IAuthService authService) : BaseController
{
    private readonly IAuthService _authService = authService;
    
    
}