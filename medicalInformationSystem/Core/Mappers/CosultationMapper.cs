using medicalInformationSystem.Api.Models.Request;
using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Mappers;

public static class ConsultationMapper
{
    public static Consultation MapCreateModelToEntity(ConsultationCreateModel consultationModel)
    {
        return new Consultation
        {
            Id = Guid.NewGuid(),
            CreateTime = DateTime.Now.ToUniversalTime(),
            SpecialityId = consultationModel.SpecialityId,
            Comment = consultationModel.Comment.Content,
        };
    }
}