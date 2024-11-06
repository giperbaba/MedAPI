using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Core.Mappers;
using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Core.Services.Interfaces;
using medicalInformationSystem.Data.Entities;
using medicalInformationSystem.Exceptions;

namespace medicalInformationSystem.Core.Services.Impls;

public class PatientService(IPatientRepository patientRepository): IPatientService
{
    public async Task<Guid> Register(PatientRegisterModel patientRegister, Guid doctorIdWhoRegistered)
    {
        Patient patient = PatientMapper.MapRegisterModelToEntity(patientRegister, doctorIdWhoRegistered);
        await patientRepository.Add(patient);
        return patient.Id;
    }

    public async Task<PatientModel> GetPatientById(Guid patientId)
    {
        Patient patient = await patientRepository.GetById(patientId);
        
        if (patient is null)
        {
            throw new ProfileNotFoundException(ErrorConstants.ProfileNotFoundError);
        }
        
        return PatientMapper.MapEntityToModel(patient);
    }
}