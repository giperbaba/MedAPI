using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Repositories.Interfaces;

public interface IConsultationRepository
{
    public Task Add(Consultation consultation);
    
    public Task<Consultation?> GetById(Guid id);
}