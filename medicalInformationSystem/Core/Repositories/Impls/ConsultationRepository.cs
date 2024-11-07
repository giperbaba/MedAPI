using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Data.DBcontext;
using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Repositories.Impls;

public class ConsultationRepository(MedicalDataContext context) : IConsultationRepository
{
    public async Task Add(Consultation consultation)
    {
        await context.Consultations.AddAsync(consultation);
        await context.SaveChangesAsync();
    }
}