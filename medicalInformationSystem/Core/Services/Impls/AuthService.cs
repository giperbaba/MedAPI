using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Core.Mappers;
using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Core.Services.Interfaces;
using medicalInformationSystem.core.utils;
using medicalInformationSystem.Exceptions;
using medicalInformationSystem.Models.Request;
using medicalInformationSystem.Models.Response;

namespace medicalInformationSystem.Core.Services.Impls;

public class AuthService (
    IDoctorRepository doctorRepository,
    ITokenService tokenService,
    ISpecialityRepository specialityRepository,
    HttpContext httpContext) : IAuthService
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
        
        httpContext?.Response.Cookies.Append("secret-cookies", token);
            
        return tokenResponseModel;
    }

    public async Task<TokenResponseModel> Login(DoctorLoginModel loginUser)
    {
        var doctorFromDatabase = await doctorRepository.GetDoctorByEmail(loginUser.Email);

        if (doctorFromDatabase is null)
        {
            throw new ProfileNotFoundException(ErrorConstants.ProfileNotFoundError);
        }

        var checkDoctorPassword = PasswordManager.Verify(loginUser.Password, doctorFromDatabase.Password);

        if (!checkDoctorPassword) {
            throw new InvalidPasswordException(ErrorConstants.InvalidPasswordError);
        }

        var token = tokenService.GenerateAccessToken(doctorFromDatabase);
        var tokenResponseModel = new TokenResponseModel(token);
            
        httpContext?.Response.Cookies.Append("secret-cookies", token);
        
        return tokenResponseModel;
    }

    public Task<ResponseModel> Logout()
    {
        httpContext?.Response.Cookies.Delete("secret-cookies"); 

        return Task.FromResult(new ResponseModel(null, "Logout successful"));
    }
}