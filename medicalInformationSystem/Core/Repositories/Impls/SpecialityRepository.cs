using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Data;
using medicalInformationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace medicalInformationSystem.Core.Repositories.Impls;


public class SpecialityRepository(MedicalDataContext context): ISpecialityRepository
{
    public async Task<Speciality?> GetById(Guid id) => await context.Specialities.FirstOrDefaultAsync(s => s.Id == id);
}