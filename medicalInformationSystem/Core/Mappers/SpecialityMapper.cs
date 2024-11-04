using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Mappers;

public static class SpecialityMapper
{
    public static SpecialityModel MapFromEntityToModel(Speciality entity)
    {
        return new SpecialityModel
        {
            Id = entity.Id,
            CreateTime = entity.CreateTime,
            Name = entity.Name
        };
    }
}