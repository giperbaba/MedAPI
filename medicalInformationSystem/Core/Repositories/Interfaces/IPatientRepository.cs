using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Repositories.Interfaces;

public interface IPatientRepository
{
    public Task Add(Patient patient);
    public Task<Patient> GetById(Guid id);
}