using medicalInformationSystem.Api.Models.Api;

namespace medicalInformationSystem.Core.Services.Interfaces;

public interface IConsultationService
{
    public Task<ConsultationModel> GetConcreteConsultation(Guid id);
}