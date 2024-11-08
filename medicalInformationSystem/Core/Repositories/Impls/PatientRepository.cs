using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Data.DBcontext;
using medicalInformationSystem.Data.Entities;
using medicalInformationSystem.Data.Enum;
using medicalInformationSystem.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace medicalInformationSystem.Core.Repositories.Impls;

public class PatientRepository(MedicalDataContext context) : IPatientRepository
{
    public async Task Add(Patient patient)
    {
        await context.Patients.AddAsync(patient);
        await context.SaveChangesAsync();
    }

    public async Task<Patient?> GetPatientById(Guid id) => await context.Patients.FindAsync(id);

    public async Task<Guid?> CheckPreviouslyInspection(Guid patientId, Guid? inspectionId,
        DateTime currentInspectionDate)
    {
        var patient = await context.Patients
            .Include(patient => patient.Inspections)
            .FirstOrDefaultAsync(p => p.Id == patientId);

        if (patient.Inspections == null || !patient.Inspections.Any())
            throw new InspectionNotFoundException(ErrorConstants.InspectionNotFoundError);
        
        var specificInspection = patient.Inspections.FirstOrDefault(i => i.Id == inspectionId);
        if (specificInspection == null)
            throw new InspectionNotFoundException(ErrorConstants.InspectionNotFoundError);
            
        var previousInspection = patient.Inspections
            .FirstOrDefault(i => i.Id == inspectionId
                                 && i.Date < currentInspectionDate
                                 && i.NextVisitDate.HasValue);

        return previousInspection?.Id;
    }

    public async Task<bool> IsPatientDead(Guid patientId)
    {
        return await context.Inspections.AnyAsync(i => i.PatientId == patientId && i.Conclusion == Conclusion.Death);
    }
}