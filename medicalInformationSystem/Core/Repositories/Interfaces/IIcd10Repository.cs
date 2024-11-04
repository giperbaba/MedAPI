using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Repositories.Interfaces;

public interface IIcd10Repository
{
    public Boolean IsTableIcd10Empty();

    public Task Add(Icd10 icd10);
    public Task<Icd10> GetByIdInt(string? id);

    public Task UpdateGuidParent(Guid? idGuid, Guid? newParentGuid);

    public Task<List<Icd10>> GetListIcd10(int skip, int take, string nameFilter);

    public Task<int> GetLength();
}