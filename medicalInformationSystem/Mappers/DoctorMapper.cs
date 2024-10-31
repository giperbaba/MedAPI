using medicalInformationSystem.Entities;
using medicalInformationSystem.Models.Api;
using medicalInformationSystem.Models.Request;

namespace medicalInformationSystem.Mappers;

public class DoctorMapper
{
    public static Doctor MapFromRegisterModelToEntity(DoctorRegisterModel doctorModel, string hashPassword)
    {
        return new Doctor
        {
            Name = doctorModel.Name,
            Birthday = doctorModel.Birthday.ToUniversalTime(),
            CreateTime = DateTime.Now.ToUniversalTime(),
            Email = doctorModel.Email,
            Gender = doctorModel.Gender,
            Id = Guid.NewGuid(),
            Password = hashPassword,
            Phone = doctorModel.Phone,
            Speciality = doctorModel.Speciality,
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