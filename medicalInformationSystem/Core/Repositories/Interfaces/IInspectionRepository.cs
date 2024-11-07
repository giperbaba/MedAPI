using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Repositories.Interfaces;

public interface IInspectionRepository
{
    public Task Add(Inspection inspection);
}