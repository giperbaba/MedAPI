using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Data.DBcontext;
using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Repositories.Impls;

public class PatientRepository(MedicalDataContext context): IPatientRepository
{
    public async Task Add(Patient patient)
    {
        await context.Patients.AddAsync(patient);
        await context.SaveChangesAsync();
    }
    
    public async Task<Patient> GetById(Guid id) => await context.Patients.FindAsync(id);
}