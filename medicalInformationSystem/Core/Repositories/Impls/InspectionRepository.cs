using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Data.DBcontext;
using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Repositories.Impls;

public class InspectionRepository(MedicalDataContext context): IInspectionRepository
{
    public async Task Add(Inspection inspection)
    {
        await context.Inspections.AddAsync(inspection);
        await context.SaveChangesAsync();
    }
}