using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Mappers;

public abstract class DoctorMapper
{
    public static Doctor MapFromRegisterModelToEntity(DoctorRegisterModel userModel, string hashPassword)
    {
        return new Doctor
        {
            Name = userModel.Name,
            Birthday = userModel.Birthday.ToUniversalTime(),
            CreateTime = DateTime.Now.ToUniversalTime(),
            Email = userModel.Email,
            Gender = userModel.Gender,
            Id = Guid.NewGuid(),
            Password = hashPassword,
            Phone = userModel.Phone,
            SpecialityId = userModel.SpecialityId,
        };
    }

    public static DoctorModel MapFromEntityToDoctorModel(Doctor doctor)
    {
        return new DoctorModel(
            doctor.Id,
            DateTime.Now.ToUniversalTime(),
            doctor.Name,
            doctor.Birthday,
            doctor.Gender,
            doctor.Email,
            doctor.Phone
        );
    }
}