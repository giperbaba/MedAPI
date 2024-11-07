using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Data.DBcontext;
using medicalInformationSystem.Data.Entities;
using medicalInformationSystem.Data.Enum;
using Microsoft.EntityFrameworkCore;

namespace medicalInformationSystem.Core.Repositories.Impls;

public class PatientRepository(MedicalDataContext context): IPatientRepository
{
    public async Task Add(Patient patient)
    {
        await context.Patients.AddAsync(patient);
        await context.SaveChangesAsync();
    }
    
    public async Task<Patient> GetPatientById(Guid id) => await context.Patients.FindAsync(id);

    public async Task<bool> ExistsPreviousInspection(Guid patientId, Guid? inspectionId, DateTime currentInspectionDate)
    {
        var patient = await context.Patients
            .Include(p => p.Inspections)
            .FirstOrDefaultAsync(p => p.Id == patientId);
        
        if (patient.Inspections == null || !patient.Inspections.Any())
            return false;
        
        var previousInspection = patient.Inspections
            .FirstOrDefault(i => i.Id == inspectionId 
                                 && i.Date < currentInspectionDate 
                                 && i.NextVisitDate.HasValue 
                                 && i.NextVisitDate.Value == currentInspectionDate);
        
        return previousInspection != null;
    }
    
    //TODO: доделоть валидацию 
    /*public async Task<bool> IsPatientDeceased(Guid patientId)
    {
        return await context.Inspections.AnyAsync(i => i.PatientId == patientId && i.Conclusion == Conclusion.Death);
    }*/
}