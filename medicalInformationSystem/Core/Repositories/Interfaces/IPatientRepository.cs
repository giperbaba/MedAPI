using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Repositories.Interfaces;

public interface IPatientRepository
{
    public Task Add(Patient patient);
    public Task<Patient> GetPatientById(Guid id);
    public Task<bool> ExistsPreviousInspection(Guid patientId, Guid? inspectionId, DateTime currentInspectionDate);
}