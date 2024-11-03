using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Core.Mappers;
using medicalInformationSystem.Core.Repositories.Impls;
using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Core.Services.Interfaces;
using medicalInformationSystem.core.utils;
using medicalInformationSystem.Models.Request;
using medicalInformationSystem.Models.Response;

namespace medicalInformationSystem.Core.Services.Impls;

public class AuthService (
    IDoctorRepository doctorRepository,
    ITokenService tokenService,
    ISpecialityRepository specialityRepository,
    IHttpContextAccessor httpContextAccessor) : IAuthService
{

    public async Task<TokenResponseModel> Register(DoctorRegisterModel user)
    {
        if (await doctorRepository.GetDoctorByEmail(user.Email) is not null)
            throw new Exception(); //TODO: Такой пользователь уже существует
        
        if (await specialityRepository.GetById(user.SpecialityId) is null) 
            throw new Exception("Специальность не существует");
        
        var newDoctor = DoctorMapper.MapFromRegisterModelToEntity(user, PasswordManager.Generate(user.Password));

        await doctorRepository.Add(newDoctor);
            
        var token = tokenService.GenerateAccessToken(newDoctor);
        var tokenResponseModel = new TokenResponseModel(token);
        
        httpContextAccessor.HttpContext?.Response.Cookies.Append("secret-cookies", token);
            
        return tokenResponseModel;
    }

    public async Task<TokenResponseModel> Login(DoctorLoginModel loginUser)
    {
        var doctorFromDatabase = await doctorRepository.GetDoctorByEmail(loginUser.Email);

        if (doctorFromDatabase is null)
        {
            throw new Exception(); //TODO: норм ошибка нет такого пользователя
        }

        var checkDoctorPassword = PasswordManager.Verify(loginUser.Password, doctorFromDatabase.Password);

        if (!checkDoctorPassword) {
            throw new Exception(); //TODO: норм ошибка пароль не тот
        }

        var token = tokenService.GenerateAccessToken(doctorFromDatabase);
        var tokenResponseModel = new TokenResponseModel(token);
            
        httpContextAccessor.HttpContext?.Response.Cookies.Append("secret-cookies", token);
        
        return tokenResponseModel;
    }

    public Task<ResponseModel> Logout()
    {
        httpContextAccessor.HttpContext?.Response.Cookies.Delete("secret-cookies"); 

        return Task.FromResult(new ResponseModel(null, "Logout successful"));
    }

    public async Task<ResponseModel> EditProfile(DoctorEditModel doctorEditModel)
    {
        var doctorFromDatabase = await doctorRepository.GetDoctorByEmail(doctorEditModel.Email);

        if (doctorFromDatabase is null)
        {
            throw new Exception(); //TODO: норм ошибка нет такого пользователя
        }
        
        doctorFromDatabase.Name = doctorEditModel.Name;
        doctorFromDatabase.Birthday = doctorEditModel.Birthday.ToUniversalTime();
        doctorFromDatabase.Phone = doctorEditModel.Phone;
        doctorFromDatabase.Gender = doctorEditModel.Gender;
        
        await doctorRepository.Edit(doctorFromDatabase);
        
        return new ResponseModel(null, "Edit successful");
    }

    public async Task<DoctorModel> GetProfile(Guid doctorId)
    {
        var doctor = await doctorRepository.GetDoctorById(doctorId);
        
        if (doctor is null)
        {
            throw new Exception(""); //TODO: ошибка нет профиля
        }

        return DoctorMapper.MapFromEntityToDoctorModel(doctor);
    }
}