using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Data.DBcontext;
using medicalInformationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace medicalInformationSystem.Core.Repositories.Impls;

public class InspectionRepository(MedicalDataContext context): IInspectionRepository
{
    public async Task Add(Inspection inspection)
    {
        await context.Inspections.AddAsync(inspection);
        await context.SaveChangesAsync();
    }
    
    public async Task<Guid?> GetLastGeneralInspectionForPatient(Guid patientId)
    {
        var lastInspection = await context.Inspections
            .Where(i => i.PatientId == patientId)
            .OrderByDescending(i => i.Date) 
            .FirstOrDefaultAsync(); 
    
        return lastInspection?.Id;
    }
}