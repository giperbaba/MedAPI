using medicalInformationSystem.Configurations;
using medicalInformationSystem.Data;
using medicalInformationSystem.Mappers;
using medicalInformationSystem.Models.Request;
using medicalInformationSystem.Models.Response;
using medicalInformationSystem.Repositorories.Interfaces;
using medicalInformationSystem.Services.Interfaces;

namespace medicalInformationSystem.Services.Impls;

public class AuthService(
    IDoctorRepository doctorRepository,
    ITokenService tokenService) : IAuthService
{
    public async Task Register(DoctorRegisterModel doctor)
    {
        if (await doctorRepository.GetDoctorByEmail(doctor.Email) is null)
        {
            var newDoctor = DoctorMapper.Map(doctor, PasswordHasher.Generate(doctor.Password));

            await doctorRepository.Add(newDoctor);
        }
    }

    public async Task<TokenResponseModel> Login(DoctorLoginModel doctorLoginModel)
    {
        var doctor = await doctorRepository.GetDoctorByEmail(doctorLoginModel.Email);

        if (doctor is null)
        {
            throw new Exception(); //TODO: норм ошибка нет такого пользователя
        }

        var checkDoctorPassword = PasswordHasher.Verify(doctorLoginModel.Password, doctor.Password);

        if (!checkDoctorPassword) {
            throw new Exception(); //TODO: норм ошибка пароль не тот
        }

        var token = tokenService.GenerateAccessToken(doctor);
        var tokenResponseModel = new TokenResponseModel(token);
            
        return tokenResponseModel;
    }
}