using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Core.Mappers;
using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Core.Services.Interfaces;
using medicalInformationSystem.core.utils;
using medicalInformationSystem.Exceptions;
using medicalInformationSystem.Models.Response;

namespace medicalInformationSystem.Core.Services.Impls;

public class DoctorAuthService (
    IDoctorRepository doctorRepository,
    ITokenService tokenService,
    ISpecialityRepository specialityRepository,
    IHttpContextAccessor httpContextAccessor) : IAuthService
{

    public async Task<TokenResponseModel> Register(DoctorRegisterModel user)
    {
        if (await doctorRepository.GetDoctorByEmail(user.Email) is not null)
            throw new ProfileAlreadyExistsException(ErrorConstants.ProfileAlreadyExistsError);
        
        if (await specialityRepository.GetById(user.SpecialityId) is null) 
            throw new SpecialityNotFoundException(ErrorConstants.SpecialityNotFoundError); 
        
        var newDoctor = DoctorMapper.MapFromRegisterModelToEntity(user, PasswordManager.Generate(user.Password));

        await doctorRepository.Add(newDoctor);
            
        var token = tokenService.GenerateAccessToken(newDoctor);
        var tokenResponseModel = new TokenResponseModel(token);
        
        httpContextAccessor.HttpContext?.Response.Cookies.Append("secret-cookies", token);
            
        return tokenResponseModel;
    }

    public async Task<TokenResponseModel> Login(LoginCredentialsModel user)
    {
        var userFromDb = await doctorRepository.GetDoctorByEmail(user.Email);
        
        Console.WriteLine(userFromDb);

        if (userFromDb is null)
        {
            throw new ProfileNotFoundException(ErrorConstants.ProfileNotFoundError);
        }

        var isPasswordTrue = PasswordManager.Verify(user.Password, userFromDb.Password);

        if (!isPasswordTrue) {
            throw new InvalidPasswordException(ErrorConstants.InvalidPasswordError);
        }

        var token = tokenService.GenerateAccessToken(userFromDb);
        var tokenResponseModel = new TokenResponseModel(token);
            
        httpContextAccessor.HttpContext?.Response.Cookies.Append("secret-cookies", token);
        
        return tokenResponseModel;
    }

    public Task<ResponseModel> Logout()
    {
        httpContextAccessor.HttpContext?.Response.Cookies.Delete("secret-cookies"); 

        return Task.FromResult(new ResponseModel(null, "Logout successful"));
    }
}