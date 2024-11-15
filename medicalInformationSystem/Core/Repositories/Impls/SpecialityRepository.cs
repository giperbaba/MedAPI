using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Data;
using medicalInformationSystem.Data.DBcontext;
using medicalInformationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace medicalInformationSystem.Core.Repositories.Impls;

public class SpecialityRepository(MedicalDataContext context): ISpecialityRepository
{
    public async Task<Speciality?> GetById(Guid id) => await context.Specialities.FirstOrDefaultAsync(s => s.Id == id);
    
    public async Task<int> GetLength() => await context.Specialities.CountAsync();

    public async Task<List<Speciality>> GetAllSpecialities() => await context.Specialities.ToListAsync();
    
    public async Task<List<Speciality>> GetListSpeciality(int skip, int take, string nameFilter)
    {
        IQueryable<Speciality> query = context.Specialities;

        if (!string.IsNullOrEmpty(nameFilter))
        {
            query = query.Where(s => s.Name.ToLower().Contains(nameFilter.Trim().ToLower()));
        }

        return await query.Skip(skip).Take(take).ToListAsync();
    }
}