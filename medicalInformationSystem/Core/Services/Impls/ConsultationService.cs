using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Configurations.Constants;
using medicalInformationSystem.Core.Mappers;
using medicalInformationSystem.Core.Repositories.Interfaces;
using medicalInformationSystem.Core.Services.Interfaces;
using medicalInformationSystem.Data.Entities;
using medicalInformationSystem.Exceptions;

namespace medicalInformationSystem.Core.Services.Impls;

public class ConsultationService(
    IConsultationRepository consultationRepository,
    ISpecialityRepository specialityRepository) : IConsultationService
{
    public async Task<ConsultationModel> GetConcreteConsultation(Guid id)
    {
        Consultation consultation = await consultationRepository.GetById(id);

        if (consultation == null)
            throw new ConsultationNotFoundException(ErrorConstants.ConsultationNotFoundError);

        ConsultationModel consultationModel = ConsultationMapper.MapEntityToModel(consultation);

        SpecialityModel specialityModel =
            SpecialityMapper.MapFromEntityToModel(await specialityRepository.GetById(consultation.SpecialityId));
        consultationModel.Speciality = specialityModel;

        return consultationModel;
    }
}