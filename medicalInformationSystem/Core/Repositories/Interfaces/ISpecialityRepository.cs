using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Repositories.Interfaces;

public interface ISpecialityRepository
{
    public Task<Speciality?> GetById(Guid id);

    public Task<int> GetLength();
    
    public Task<List<Speciality>> GetAllSpecialities();
    
    public Task<List<Speciality>> GetListSpeciality(int skip, int take, string nameFilter);
}