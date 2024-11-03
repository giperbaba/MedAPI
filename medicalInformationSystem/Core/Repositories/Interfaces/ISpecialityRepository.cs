using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Repositories.Interfaces;

public interface ISpecialityRepository
{
    public Task<Speciality?> GetById(Guid id);
}