using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Api.Models.Response;
using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Mappers;

public static class Icd10Mapper
{
    public static Icd10 MapFromModelToEntity(Icd10Model icd10Model, Guid idGuid, Guid? idParentGuid = null)
    {
        return new Icd10
        {
            IdInt = icd10Model.idInt,
            IdGuid = idGuid,
            IdParent = icd10Model.idParent,
            IdParentGuid = idParentGuid,
            RecCode = icd10Model.recCode,
            McbCode = icd10Model.mkbCode,
            McbName = icd10Model.mkbName,
            Actual = icd10Model.actual
        };
    }

    public static Icd10RecordModel MapFromEntityToModel(Icd10 entity)
    {
        return new Icd10RecordModel
        {
            Id = entity.IdGuid,
            CreateTime = entity.CreateTime,
            Code = entity.McbCode,
            Name = entity.McbName,
        };
    }
}