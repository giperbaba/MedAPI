using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Data;
using medicalInformationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace medicalInformationSystem.Core.Repositories.Impls;

public class Icd10Repository(MedicalDataContext context) : IIcd10Repository
{
    public Boolean IsTableIcd10Empty() => !context.Icd10s.Any();

    public async Task Add(Icd10 icd10)
    {
        await context.Icd10s.AddAsync(icd10);
        await context.SaveChangesAsync();
    }

    public async Task<Icd10> GetByIdInt(string id)
    {
        int intId = int.Parse(id);
        return await context.Icd10s.FirstOrDefaultAsync(e => e.IdInt == intId);
    }

    public async Task UpdateGuidParent(Guid? idGuid, Guid? newParentGuid)
    {
        var entity = await context.Icd10s.FirstOrDefaultAsync(e => e.IdGuid == idGuid);
        if (entity != null)
        {
            entity.IdParentGuid = newParentGuid;
            context.Icd10s.Update(entity);
            await context.SaveChangesAsync();
        }
    }

    public async Task<List<Icd10>> GetListIcd10(int skip, int take, string nameFilter)
    {
        IQueryable<Icd10> query = context.Icd10s;

        string lowerCaseFilter = nameFilter.ToLower();
        query = query.Where(icd =>
            icd.McbName.ToLower().Contains(lowerCaseFilter) ||
            icd.McbCode.ToLower().Contains(lowerCaseFilter)
        );

        return await query.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<int> GetLength()
    {
        return await context.Icd10s.CountAsync();
    }
}