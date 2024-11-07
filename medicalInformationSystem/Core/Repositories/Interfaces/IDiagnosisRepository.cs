using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Repositories.Interfaces;

public interface IDiagnosisRepository
{
    public Task Add(Diagnosis diagnosis);
}