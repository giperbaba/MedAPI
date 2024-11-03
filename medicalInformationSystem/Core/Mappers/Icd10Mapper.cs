using medicalInformationSystem.Api.Models.Api;
using medicalInformationSystem.Data.Entities;

namespace medicalInformationSystem.Core.Mappers;

public class Icd10Mapper
{
    public static Icd10 MapIcd10ModelToEntity(Icd10Model icd10Model, Guid? idGuid, Guid? idParentGuid = null)
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
}