using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Api.Models.Request;

namespace medicalInformationSystem.Core.Services.Interfaces;

public interface IPatientService
{
    public Task<Guid> Register(PatientRegisterModel patientRegister, Guid doctorIdWhoRegistered);
    
    public Task<PatientModel> GetPatientById(Guid patientId);
}
