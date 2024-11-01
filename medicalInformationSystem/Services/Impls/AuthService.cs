using medicalInformationSystem.Entities;
using medicalInformationSystem.Mappers;
using medicalInformationSystem.Models.Api;
using medicalInformationSystem.Models.Request;
using medicalInformationSystem.Models.Response;
using medicalInformationSystem.Repositories.Interfaces;
using medicalInformationSystem.Services.Interfaces;

namespace medicalInformationSystem.Services.Impls;

public class AuthService(
    IDoctorRepository doctorRepository,
    ITokenService tokenService,
    IHttpContextAccessor httpContextAccessor) : IAuthService
{

    public async Task<TokenResponseModel> Register(DoctorRegisterModel doctor)
    {
        if (await doctorRepository.GetDoctorByEmail(doctor.Email) is not null)
            throw new Exception(); //TODO: Такой пользователь уже существует
        
        var newDoctor = DoctorMapper.MapFromRegisterModelToEntity(doctor, PasswordHasher.Generate(doctor.Password));

        await doctorRepository.Add(newDoctor);
            
        var token = tokenService.GenerateAccessToken(newDoctor);
        var tokenResponseModel = new TokenResponseModel(token);
        
        httpContextAccessor.HttpContext?.Response.Cookies.Append("secret-cookies", token);
            
        return tokenResponseModel;
    }

    public async Task<TokenResponseModel> Login(DoctorLoginModel doctorLoginModel)
    {
        var doctorFromDatabase = await doctorRepository.GetDoctorByEmail(doctorLoginModel.Email);

        if (doctorFromDatabase is null)
        {
            throw new Exception(); //TODO: норм ошибка нет такого пользователя
        }

        var checkDoctorPassword = PasswordHasher.Verify(doctorLoginModel.Password, doctorFromDatabase.Password);

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
            throw new Exception(); //TODO: ошибка нет профиля
        }

        return DoctorMapper.MapFromEntityToDoctorModel(doctor);
    }
}