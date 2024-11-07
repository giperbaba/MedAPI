using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Data.DBcontext;
using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Repositories.Impls;

public class DiagnosisRepository(MedicalDataContext context): IDiagnosisRepository
{
    public async Task Add(Diagnosis diagnosis)
    {
        await context.Diagnoses.AddAsync(diagnosis);
        await context.SaveChangesAsync();
    }
}