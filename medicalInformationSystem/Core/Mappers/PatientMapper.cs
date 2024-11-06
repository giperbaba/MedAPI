using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Mappers;

public static class PatientMapper
{
    public static Patient MapRegisterModelToEntity(PatientRegisterModel registrationModel, Guid doctorId)
    {
        return new Patient
        {
            Birthday = registrationModel.Birthday.ToUniversalTime(),
            CreateTime = DateTime.Now.ToUniversalTime(),
            DoctorId = doctorId,
            Gender = registrationModel.Gender,
            Id = Guid.NewGuid(),
            Name = registrationModel.Name
        };
    }

    public static PatientModel MapEntityToModel(Patient patient)
    {
        return new PatientModel
        {
            Id = patient.Id,
            Birthday = patient.Birthday,
            CreateTime = patient.CreateTime,
            Gender = patient.Gender,
            Name = patient.Name,
        };
    }
}